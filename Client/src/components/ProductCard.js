import React, { useContext, useState, useEffect } from "react";
import axios from "axios";
import { Link, useLocation } from "react-router-dom";
import prodcompare from "../assets/images/prodcompare.svg";
import wish from "../assets/images/wish.svg";
// import wishlist from '../assets/images/wishlist.svg';
// import watch from '../assets/images/watch.jpg';
// import watch2 from '../assets/images/watch-1.avif';
import iconcart from "../assets/images/icon-cart.png";
import addcart from "../assets/images/add-cart.svg";
import view from "../assets/images/view.svg";
import { CartContext } from "../CartContext";
import _ from "lodash";
import LoadingBox from "./LoadingBox";
import StarRatings from "react-star-ratings";
import { SearchContext } from "../SearchContext";

const ProductCard = (props) => {
  const { grid } = props;
  const { condition } = props;
  let location = useLocation();
  const [products, setProducts] = useState([]);
  const { currentPage } = props;
  const { searchTerm } = useContext(CartContext);
  const [topSeller, setTopSeller] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const { search, setRecord, status, setStatus } = useContext(SearchContext);

  // const fetchTopSeller = async () => {
  //   await axios.get('/api/sanpham/topseller').then((response) => {
  //     setTopSeller(response.data);
  //   });
  // };

  const fetchProducts = async () => {
    let url = "https://localhost:7295/api/Product/searchByName";
    const pageNumber = currentPage;
    const pageSize = 6;
    const response = await axios.post(
      url,
      { pageNumber, pageSize },
      {
        params: {
          name: search,
        },
      }
    );
    setIsLoading(false);

    let data = response.data.item1;
    setRecord(response.data.item2);

    switch (condition) {
      case "Bán Chạy":
        data = topSeller;
        break;
      case "Giá, Thấp đến Cao":
        data = _.sortBy(data, "price");
        break;
      case "Giá, Cao đến Thấp":
        data = _.sortBy(data, "price").reverse();
        break;
      case "Theo Thứ Tự, A-Z":
        data = _.sortBy(data, "name");
        break;
      case "Theo Thứ Tự, Z-A":
        data = _.sortBy(data, "name").reverse();
        break;
      // Thêm các case cho các trường hợp khác
      default:
        // Xử lý cho trường hợp mặc định nếu không có case nào khớp với giá trị của biến condition
        break;
    }
    setProducts(data);
  };

  useEffect(() => {
    if (condition === "Liên Quan") {
      setIsLoading(true);
    }
    fetchProducts();
    // fetchTopSeller();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [status, condition, currentPage]);
  setStatus(false);
  if (isLoading) {
    return <LoadingBox />;
  }

  return (
    <>
      {products.map((item) => (
        <div
          key={item.id}
          className={` ${location.pathname === "/" ? "col-3" : `gr-${grid}`} `}
          style={{ minHeight: 460 }}
        >
          <Link
            to={`${
              location.pathname === "/"
                ? `/product/${item.id}`
                : location.pathname === `/product/${item.id}`
                ? `/product/${item.id}`
                : `${item.id}`
            }`}
            className="product-card position-relative"
          >
            <div className="wishlist-icon position-absolute">
              <button className="border-0 bg-transparent">
                <img src={wish} alt="wishlist" />
              </button>
            </div>
            <div className="product-image">
              <img
                src={item?.image}
                className="img-fluid"
                aria-hidden
                alt="product image meo"
              />
              <img
                src={iconcart}
                className="img-fluid"
                aria-hidden
                alt="product image"
              />
            </div>
            <div className="product-details" style={{ marginTop: 20 }}>
              <h5
                style={{ fontFamily: "Roboto, sans-serif" }}
                className="product-title"
              >
                <p style={{ minHeight: 40 }}>{item.name}</p>
              </h5>
              <h6>Kho {item?.quantity}</h6>
              <div className="d-flex">
                {/* <ReactStars
                  count={5}
                  size={24}
                  value={parseFloat(item.starRating)}
                  edit={false}
                  activeColor="#ffd700"
                /> */}
                <StarRatings
                  rating={item.starRating}
                  starRatedColor="#ffd700"
                  starEmptyColor="#e4e5e9"
                  numberOfStars={5}
                  starDimension="22px"
                  starSpacing="2px"
                  isSelectable={false}
                />
                <p style={{ marginTop: 4, marginLeft: 35, color: "black" }}>
                  Đã bán {item.sold}
                </p>
              </div>
              <div
                className="price-wrapper"
                style={{ display: "flex", alignItems: "center" }}
              >
                <p className="price">
                  {item.price?.toLocaleString("vi-VN", {
                    style: "currency",
                    currency: "VND",
                  })}
                </p>
                {condition === "Bán Chạy" ? (
                  <p
                    style={{
                      position: "absolute",
                      left: "110px",
                      marginLeft: "110px",
                    }}
                  >
                    {" "}
                    Đã bán {item.topseller}
                  </p>
                ) : null}
              </div>
            </div>
            <div className="action-bar position-absolute">
              <div className="d-flex flex-column gap-15">
                <button className="border-0 bg-transparent">
                  <img src={prodcompare} alt="compare" />
                </button>
                <button className="border-0 bg-transparent">
                  <img src={view} alt="view" />
                </button>
                <button className="border-0 bg-transparent">
                  <img src={addcart} alt="addcart" />
                </button>
              </div>
            </div>
          </Link>
        </div>
      ))}
    </>
  );
};

export default ProductCard;
