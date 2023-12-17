import { useState, useEffect, useContext } from "react";
import React from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import ReactStars from "react-rating-stars-component";
import BreadCrumb from "../components/BreadCrumb";
import Meta from "../components/Meta";
import ProductCard from "../components/ProductCard";
import Color from "../components/Color";
import { TbGitCompare } from "react-icons/tb";
import { AiOutlineHeart } from "react-icons/ai";
import { Link } from "react-router-dom";
// import watch from "../assets/images/watch.jpg";
import Container from "../components/Container";
import { CartContext } from "../CartContext";
import StarRatings from "react-star-ratings";
import { MyContext } from "../encryptionKey";
import CryptoJS from "crypto-js";

const SingleProduct = () => {
  const [product, setProduct] = useState([]);

  const [orderedProduct, setorderedProduct] = useState(true);

  const { addToCart } = useContext(CartContext);

  const [quantity, setQuantity] = useState(1);

  const [available, setAvailable] = useState("");
  const { encryptionKey } = useContext(MyContext);
  const decryptedId = CryptoJS.AES.decrypt(
    localStorage.getItem("id"),
    encryptionKey
  ).toString(CryptoJS.enc.Utf8);

  // const [modalData, setModalData] = useState(null);

  const handleQuantityChange = (event) => {
    setQuantity(event.target.value);
  };
  const handleAddCart = async (
    event,
    productid,
    quantity,
    totalmoney,
    price
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
            totalMoney: 0,
            note: "",
          },
          {
            params: {
              code: null,
            },
          }
        );

        await axios.post("https://localhost:7295/api/OrderDetail/createCart", {
          billId: result.data.data.id,
          price: price,
          productId: productid,
          quantity: quantity,
          totalMoney: totalmoney,
        });
      } catch (error) {
        console.error(error);
      }
    }
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
      <Meta title={"Product Name"} />
      <BreadCrumb title="Product Name" />
      <Container class1="main-product-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-6">
            <div className="main-product-image">
              <div>
                <img src={product?.image} alt="image" />
              </div>
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
          <div className="col-6">
            <div className="main-product-details">
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
                  <p className="mb-0 t-review">( 2 Reviews )</p>
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
                          product.price
                        )
                      }
                      disabled={product?.quantity === 0 ? true : false}
                    >
                      Thêm Vào Giỏ Hàng
                    </button>
                    <button className="button signup">Mua Ngay</button>
                  </div>
                </div>
                <div className="d-flex align-items-center gap-15">
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
                </div>
                <div className="d-flex gap-10 flex-column  my-3">
                  <h3 className="product-heading">Shipping & Returns :</h3>
                  <p className="product-data">
                    Free shipping and returns available on all orders! <br /> We
                    ship all US domestic orders within
                    <b>5-10 business days!</b>
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </Container>
      <Container class1="description-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-12">
            <h4>Mô tả</h4>
            <div className="bg-white p-3">
              <p>{product?.describe}</p>
            </div>
          </div>
        </div>
      </Container>
      <Container class1="reviews-wrapper home-wrapper-2">
        <div className="row">
          <div className="col-12">
            <h3 id="review">Reviews</h3>
            <div className="review-inner-wrapper">
              <div className="review-head d-flex justify-content-between align-items-end">
                <div>
                  <h4 className="mb-2">Customer Reviews</h4>
                  <div className="d-flex align-items-center gap-10">
                    <ReactStars
                      count={5}
                      size={24}
                      value={4}
                      edit={false}
                      activeColor="#ffd700"
                    />
                    <p className="mb-0">Based on 2 Reviews</p>
                  </div>
                </div>
                {orderedProduct && (
                  <div>
                    <Link
                      className="text-dark text-decoration-underline"
                      to="#"
                    >
                      Write a Review
                    </Link>
                  </div>
                )}
              </div>
              <div className="review-form py-4">
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
              </div>
              <div className="reviews mt-4">
                <div className="review">
                  <div className="d-flex gap-10 align-items-center">
                    <h6 className="mb-0">Navdeep</h6>
                    <ReactStars
                      count={5}
                      size={24}
                      value={4}
                      edit={false}
                      activeColor="#ffd700"
                    />
                  </div>
                  <p className="mt-3">
                    Lorem ipsum dolor sit amet consectetur, adipisicing elit.
                    Consectetur fugit ut excepturi quos. Id reprehenderit
                    voluptatem placeat consequatur suscipit ex. Accusamus dolore
                    quisquam deserunt voluptate, sit magni perspiciatis quas
                    iste?
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </Container>
      <Container class1="popular-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-12">
            <h3 className="section-heading">Our Popular Products</h3>
          </div>
        </div>
        <div className="row">
          <ProductCard />
        </div>
      </Container>

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
