import React from "react";
import { Link, useLocation } from "react-router-dom";
import prodcompare from "../assets/images/prodcompare.svg";
import wish from "../assets/images/wish.svg";
import iconcart from "../assets/images/icon-cart.png";
import addcart from "../assets/images/add-cart.svg";
import view from "../assets/images/view.svg";
import StarRatings from "react-star-ratings";

const ProductCard = (props) => {
  const { grid } = props;

  let location = useLocation();

  const { product } = props;
  const isLoggedIn = localStorage.getItem("accessToken");
  const handleLinkClick = () => {
    if (!isLoggedIn) {
      alert("Bạn cần đăng nhập để mua hàng.");
    }
    // else, handle the link click as usual
  };
  return (
    <>
      {product?.map((item) => (
        <div
          key={item?.id}
          className={` ${location.pathname === "/" ? "col-3" : `gr-${grid}`} `}
          style={{ minHeight: 460 }}
        >
          <Link
            to={
              isLoggedIn
                ? location.pathname === "/"
                  ? `/product/${item.id}`
                  : `/product/${item.id}`
                : "/"
            }
            className="product-card position-relative"
            onClick={handleLinkClick}
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
                <p style={{ minHeight: 40 }}>{item?.name}</p>
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
                  rating={item?.starRating}
                  starRatedColor="#ffd700"
                  starEmptyColor="#e4e5e9"
                  numberOfStars={5}
                  starDimension="22px"
                  starSpacing="2px"
                  isSelectable={false}
                />
                <p style={{ marginTop: 4, marginLeft: 35, color: "black" }}>
                  Đã bán {item?.sold}
                </p>
              </div>
              <div
                className="price-wrapper"
                style={{ display: "flex", alignItems: "center" }}
              >
                <p className="price">
                  {item?.price?.toLocaleString("vi-VN", {
                    style: "currency",
                    currency: "VND",
                  })}
                </p>
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
