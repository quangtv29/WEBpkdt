import { useState, useEffect, useContext } from "react";
import React from "react";
import Slider from "react-slick";
import { useParams } from "react-router-dom";
import axios from "axios";
import BreadCrumb from "../components/BreadCrumb";
import Meta from "../components/Meta";
import Color from "../components/Color";
import Container from "../components/Container";
import { CartContext } from "../CartContext";
import StarRatings from "react-star-ratings";
import { MyContext } from "../encryptionKey";
import CryptoJS from "crypto-js";
import Avatar from "../components/Avatar";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";

const MaskedString = ({ originalString }) => {
  const visibleCharacters = 1;

  const hiddenCharacters = originalString.length - 2 * visibleCharacters;

  const maskedString =
    originalString.substring(0, visibleCharacters) +
    "*".repeat(hiddenCharacters) +
    originalString.substring(originalString.length - visibleCharacters);

  return <span className="mt-2">{maskedString}</span>;
};
const SingleProduct = () => {
  const [product, setProduct] = useState([]);

  const { addToCart } = useContext(CartContext);
  const [review, setReview] = useState([]);
  const [quantity, setQuantity] = useState(1);
  const [available, setAvailable] = useState("");
  const { encryptionKey } = useContext(MyContext);
  const decryptedId = CryptoJS.AES.decrypt(
    localStorage.getItem("id"),
    encryptionKey
  ).toString(CryptoJS.enc.Utf8);
  const [state, setState] = useState([true, false, false, false, false, false]);

  const handleFeedback = (e, a) => {
    e.preventDefault();
    var hi = [...state];
    for (let i = 0; i < hi.length; i++) {
      hi[i] = i === a;
    }

    setState(hi);
    if (product?.id) {
      axios
        .post(
          "https://localhost:7295/api/Feedback/getFeedbackByProduct",
          {
            pageNumber: 1,
            pageSize: 5,
          },
          {
            params: {
              ProductId: product?.id,
              star: a,
            },
          }
        )
        .then((res) => {
          setReview(res.data);
        });
    }
  };

  const handleQuantityChange = (event) => {
    setQuantity(event.target.value);
  };
  const handleAddCart = async (
    event,
    productid,
    quantity,
    totalmoney,
    price,
    a
  ) => {
    event.preventDefault();
    if (product?.quantity === 0) {
      alert("Sản phẩm trong kho không đủ!");
    } else {
      try {
        const result = await axios.post(
          `https://localhost:7295/api/Bill/createBill`,
          {
            customerId: decryptedId,
            address: "",
            phoneNumber: "",
            totalMoney: totalmoney,
            note: "",
          },
          {
            params: {
              code: null,
            },
          }
        );

        await axios.post(
          "https://localhost:7295/api/OrderDetail/createCart",
          {
            billId: result.data.data.id,
            price: price,
            productId: productid,
            quantity: quantity,
            totalMoney: totalmoney,
          },
          {
            params: {
              customerid: decryptedId,
            },
          }
        );
        if (a === 1) {
          localStorage.setItem("billid1", result.data.data.id);
          window.location.href = "/checkout";
        }
      } catch (error) {
        console.error(error);
      }
    }
  };
  const settings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 1,
    slidesToScroll: 1,
  };
  const { id } = useParams();
  useEffect(() => {
    axios
      .get(`https://localhost:7295/api/Product/${id}`)
      .then((response) => {
        setProduct(response.data.data);
        if (response.data.data.quantity === 0) {
          setAvailable("Hết Hàng");
        } else {
          setAvailable(response.data.data.quantity);
        }
      })
      .catch((error) => console.error(error));
  }, [id]);
  const [photo, setPhoto] = useState([]);
  useEffect(() => {
    axios
      .get("https://localhost:7295/api/Photo/getPhotoByProduct", {
        params: { Id: id },
      })
      .then((res) => {
        setPhoto(res.data);
      });
  }, [id]);
  useEffect(() => {
    if (product?.id) {
      axios
        .post(
          "https://localhost:7295/api/Feedback/getFeedbackByProduct",
          {
            pageNumber: 1,
            pageSize: 5,
          },
          {
            params: {
              ProductId: product?.id,
              star: 0,
            },
          }
        )
        .then((res) => {
          setReview(res.data);
        });
    }
  }, [product?.id]);
  if (!product) {
    return <div>Loading...</div>;
  }
  // const props = {
  //   width: 594,
  //   height: 600,
  //   zoomWidth: 600,
  //   img: product?.image,
  // };

  // const copyToClipboard = (text) => {
  //   console.log("text", text);
  //   var textField = document.createElement("textarea");
  //   textField.innerText = text;
  //   document.body.appendChild(textField);
  //   textField.select();
  //   document.execCommand("copy");
  //   textField.remove();
  // };
  const closeModal = () => {};

  const handleAddToCart = () => {
    addToCart({
      ...product,
      quantity: quantity,
      prices: quantity * product?.price,
    });
  };

  return (
    <>
      <Meta title={product?.name} />
      <BreadCrumb title="Product Name" />
      <Container class1="main-product-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-6">
            <div className="main-product-image">
              <Slider {...settings}>
                {photo.map((image, index) => (
                  <div key={index}>
                    <img src={image.image} alt={`productImage-${index}`} />
                  </div>
                ))}
              </Slider>
            </div>
            <div className="other-product-images d-flex flex-wrap gap-15">
              {/* {product.map(image => (
              <div>
                <img
                  src={`${image.FileName}`}
                  className="img-fluid"
                  alt=""
                />
              </div>
            ))} */}
            </div>
          </div>
          <div className="col-6" style={{ boxSizing: "border-box" }}>
            <div className="main-product-details" style={{ minHeight: 682 }}>
              <div className="border-bottom">
                <h3 className="title">{product?.name}</h3>
              </div>
              <div className="border-bottom py-3">
                <p className="price">
                  {product?.price?.toLocaleString("vi-VN", {
                    style: "currency",
                    currency: "VND",
                  })}
                </p>
                <div className="d-flex align-items-center gap-10">
                  <StarRatings
                    rating={product?.starRating}
                    starRatedColor="#ffd700"
                    starEmptyColor="#e4e5e9"
                    numberOfStars={5}
                    starDimension="22px"
                    starSpacing="2px"
                    isSelectable={false}
                  />
                </div>
              </div>
              <div className=" py-3">
                {/* <div className="d-flex gap-10 align-items-center my-2">
                  <h3 className="product-heading">Type :</h3>
                  <p className="product-data">Watch</p>
                </div>
                <div className="d-flex gap-10 align-items-center my-2">
                  <h3 className="product-heading">Brand :</h3>
                  <p className="product-data">Havells</p>
                </div>
                <div className="d-flex gap-10 align-items-center my-2">
                  <h3 className="product-heading">Category :</h3>
                  <p className="product-data">Watch</p>
                </div>
                <div className="d-flex gap-10 align-items-center my-2">
                  <h3 className="product-heading">Tags :</h3>
                  <p className="product-data">Watch</p>
                </div> */}
                <div className="d-flex gap-10 align-items-center my-2">
                  <h3 className="product-heading">Kho:</h3>
                  <p className="product-data">{available}</p>
                </div>

                <div className="d-flex gap-10 flex-column mt-2 mb-3">
                  <h3 className="product-heading">Color :</h3>
                  <Color />
                </div>
                <div className="d-flex align-items-center gap-15 flex-row mt-2 mb-3">
                  <h3 className="product-heading">Số lượng :</h3>
                  <div className="">
                    <input
                      type="number"
                      name=""
                      min={1}
                      max={product?.quantity}
                      className="form-control"
                      style={{ width: "70px" }}
                      value={quantity}
                      onChange={handleQuantityChange}
                      id=""
                    />
                  </div>
                  <div className="d-flex align-items-center gap-30 ms-5">
                    <button
                      className="button border-0"
                      data-bs-toggle="modal"
                      data-bs-target="#staticBackdrop"
                      type="button"
                      onClick={(event) =>
                        handleAddCart(
                          event,
                          product.id,
                          quantity,
                          quantity * product.price,
                          product.price,
                          0
                        )
                      }
                      disabled={product?.quantity === 0 ? true : false}
                    >
                      Thêm Vào Giỏ Hàng
                    </button>
                    <button
                      onClick={(event) =>
                        handleAddCart(
                          event,
                          product.id,
                          quantity,
                          quantity * product.price,
                          product.price,
                          1
                        )
                      }
                      className="button signup"
                    >
                      Mua Ngay
                    </button>
                  </div>
                </div>
                {/* <div className="d-flex align-items-center gap-15">
                  <div>
                    <Link>
                      <TbGitCompare className="fs-5 me-2" /> Add to Compare
                    </Link>
                  </div>
                  <div>
                    <Link>
                      <AiOutlineHeart className="fs-5 me-2" /> Add to Wishlist
                    </Link>
                  </div>
                </div> */}
                {/* <div className="d-flex gap-10 flex-column  my-3">
                  <h3 className="product-heading">Shipping & Returns :</h3>
                  <p className="product-data">
                    Free shipping and returns available on all orders! <br /> We
                    ship all US domestic orders within
                    <b>5-10 business days!</b>
                  </p>
                </div> */}
                <div
                  class1="description-wrapper py-5 home-wrapper-2"
                  style={{ height: 280 }}
                >
                  <div className="row">
                    <div className="col-12">
                      <h4>Mô tả</h4>
                      <div className="bg-white p-3">
                        <p>{product?.describe}</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </Container>

      <Container class1="reviews-wrapper home-wrapper-2">
        <div className="row">
          <div className="col-12">
            <div className="review-inner-wrapper">
              <div
                style={{
                  backgroundColor: "#fffbf8",
                  border: "1px solid #f9ede5",
                  minHeight: 120,
                  height: 120,
                }}
                className="review-head d-flex  align-items-end row"
              >
                <div className="col-4">
                  <h4 className="mb-2">Đánh giá sản phẩm</h4>
                  <div className="d-flex align-items-center gap-10">
                    <StarRatings
                      rating={product?.starRating}
                      starRatedColor="#ffd700"
                      starEmptyColor="#e4e5e9"
                      numberOfStars={5}
                      starDimension="22px"
                      starSpacing="2px"
                      isSelectable={false}
                    />
                    <p className="mb-0">
                      {" "}
                      {product?.starRating?.toFixed(1)}/5 ( {review?.length}{" "}
                      đánh giá )
                    </p>
                  </div>
                </div>
                <div className="d-flex col-8 ">
                  <button
                    className="ml-5"
                    style={{
                      backgroundColor: "#fff",
                      width: 80,
                      border: !state[0]
                        ? "1px solid rgba(0,0,0,.09)"
                        : "1px solid #ee4d2d",
                    }}
                    onClick={(e) => handleFeedback(e, 0)}
                  >
                    Tất cả
                  </button>
                  <button
                    className="ml-5"
                    style={{
                      backgroundColor: "#fff",
                      width: 80,
                      border: !state[5]
                        ? "1px solid rgba(0,0,0,.09)"
                        : "1px solid #ee4d2d",
                    }}
                    onClick={(e) => handleFeedback(e, 5)}
                  >
                    5 Sao
                  </button>
                  <button
                    className="ml-5"
                    style={{
                      backgroundColor: "#fff",
                      width: 80,
                      border: !state[4]
                        ? "1px solid rgba(0,0,0,.09)"
                        : "1px solid #ee4d2d",
                    }}
                    onClick={(e) => handleFeedback(e, 4)}
                  >
                    4 Sao
                  </button>
                  <button
                    className="ml-5"
                    style={{
                      backgroundColor: "#fff",
                      width: 80,
                      border: !state[3]
                        ? "1px solid rgba(0,0,0,.09)"
                        : "1px solid #ee4d2d",
                    }}
                    onClick={(e) => handleFeedback(e, 3)}
                  >
                    3 Sao
                  </button>
                  <button
                    className="ml-5"
                    style={{
                      backgroundColor: "#fff",
                      width: 80,
                      border: !state[2]
                        ? "1px solid rgba(0,0,0,.09)"
                        : "1px solid #ee4d2d",
                    }}
                    onClick={(e) => handleFeedback(e, 2)}
                  >
                    2 Sao
                  </button>
                  <button
                    className="ml-5"
                    style={{
                      backgroundColor: "#fff",
                      width: 80,
                      border: !state[1]
                        ? "1px solid rgba(0,0,0,.09)"
                        : "1px solid #ee4d2d",
                    }}
                    onClick={(e) => handleFeedback(e, 1)}
                  >
                    1 Sao
                  </button>
                </div>
              </div>
              <div className=" w-100">
                {review?.map((item) => (
                  <div
                    key={item?.id}
                    style={{ borderBottom: "1px solid rgba(0,0,0,.09)" }}
                    className="d-flex mt-1"
                  >
                    <div className="w-100">
                      <div className="m-0 d-flex">
                        <Avatar Image={item?.avatar} />
                        <div className="mt-2 ml-2">
                          {item?.isShow ? (
                            <MaskedString originalString={item?.fixName} />
                          ) : (
                            item?.fixName
                          )}
                        </div>
                      </div>
                      <StarRatings
                        rating={item?.star}
                        starRatedColor="#ffd700"
                        starEmptyColor="#e4e5e9"
                        numberOfStars={5}
                        starDimension="22px"
                        starSpacing="2px"
                        isSelectable={false}
                      />
                      <div className="mt-2" style={{ fontSize: 14 }}>
                        {item?.convert}
                      </div>
                      <p className="mt-3">{item?.comment}</p>
                      {item?.image && (
                        <img
                          src={item?.image}
                          style={{ maxHeight: 150, maxWidth: 200 }}
                          alt="imageMobile"
                        />
                      )}
                    </div>
                  </div>
                ))}
              </div>
              {/* <div className="review-form py-4">
                <h4>Write a Review</h4>
                <form action="" className="d-flex flex-column gap-15">
                  <div>
                    <StarRatings
                      rating={product?.starRating}
                      starRatedColor="#ffd700"
                      starEmptyColor="#e4e5e9"
                      numberOfStars={5}
                      starDimension="22px"
                      starSpacing="2px"
                      isSelectable={false}
                    />
                  </div>
                  <div>
                    <textarea
                      name=""
                      id=""
                      className="w-100 form-control"
                      cols="30"
                      rows="4"
                      placeholder="Comments"
                    ></textarea>
                  </div>
                  <div className="d-flex justify-content-end">
                    <button className="button border-0">Submit Review</button>
                  </div>
                </form>
              </div> */}
            </div>
          </div>
        </div>
      </Container>
      {/* <Container class1="popular-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-12">
            <h3 className="section-heading">Our Popular Products</h3>
          </div>
        </div>
        <div className="row">
          <ProductCard />
        </div>
      </Container> */}

      <div
        className="modal fade"
        id="staticBackdrop"
        data-bs-backdrop="static"
        data-bs-keyboard="false"
        aria-labelledby="staticBackdropLabel"
        aria-hidden="true"
      >
        <div className="modal-dialog modal-dialog-centered ">
          <div className="modal-content">
            <div className="modal-header py-0 border-0">
              <button
                type="button"
                className="btn-close"
                data-bs-dismiss="modal"
                aria-label="Close"
                onClick={(e) =>
                  handleAddToCart(
                    e,
                    product.id,
                    quantity,
                    quantity * product.price,
                    product.price
                  )
                }
              ></button>
            </div>
            <div className="modal-body py-0">
              <div className="d-flex align-items-center">
                <div className="flex-grow-1 w-50">
                  <img
                    src={product?.image}
                    className="img-fluid"
                    alt="product img"
                  />
                </div>
                <div className="d-flex flex-column flex-grow-1 w-50">
                  <h6 className="mb-3">{product?.name}</h6>
                  <p className="mb-1">Số lượng: {quantity}</p>
                  <p className="mb-1">Màu: Không có</p>
                  <p className="mb-1">Size: Không có</p>
                </div>
              </div>
            </div>
            <div className="modal-footer border-0 py-0 justify-content-center gap-30">
              <h4>Thêm sản phẩm vào giỏ hàng thành công</h4>
            </div>
            <div className="d-flex justify-content-center py-3">
              <button type="button" className="button text-light ">
                <a
                  className="text-light"
                  href="/product"
                  onClick={() => {
                    closeModal();
                  }}
                >
                  Tiếp tục mua sắm
                </a>
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default SingleProduct;
