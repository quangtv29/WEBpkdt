import React, { useContext, useState } from "react";
import { NavLink, Link } from "react-router-dom";
import { BsSearch } from "react-icons/bs";
// import { useState } from 'react';
import NavDropdown from "react-bootstrap/NavDropdown";
import { LinkContainer } from "react-router-bootstrap";
// import compare from "../assets/images/compare.svg";
// import wishlist from "../assets/images/wishlist.svg";
import cart from "../assets/images/cart.svg";
import menu from "../assets/images/menu.svg";
import axios from "axios";
import { CartContext } from "../CartContext";
import "./Admin/LayoutAdmin/LayoutAdmin.scss";
import { useNavigate } from "react-router-dom";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import InputGroup from "react-bootstrap/InputGroup";
import FormControl from "react-bootstrap/FormControl";
import { useEffect } from "react";
const Header = (props) => {
  const { cartCount, totalPrice, setSearchTerm } = useContext(CartContext);
  const [search, setSearch] = useState("");
  const u = localStorage.getItem("lastname");
  const welcomeMessage = u;
  const chucvu = localStorage.getItem("chucvu");
  const isAorN = chucvu === "Nhân viên" || chucvu === "Admin";
  const [isLogin, setIsLogin] = useState(false);

  // const [makh, setMakh] = useState("");
  // useEffect(() => {
  //   if (localStorage.getItem("chucvu") === "Khách hàng") {
  //     axios
  //       .get("/api/users")
  //       .then((res) => {
  //         setMakh(res.data.users[0].MAKH);
  //         localStorage.setItem("makh", res.data.users[0].MAKH);
  //       })
  //       .catch((err) => {
  //         console.error(err);
  //       });
  //   }
  // }, []);
  const logout = () => {
    localStorage.clear();
    setIsLogin(false);
    navigate("/login", { replace: true });
  };
  const handleSearch = (e) => {
    e.preventDefault();
    navigate(search ? `/product/?search=${search}` : "/product");
    setSearchTerm(search);
  };
  useEffect(() => {
    if (localStorage.getItem("id") != null) {
      setIsLogin(true);
    }
  });
  const handleLinkClick = () => {
    // Tải lại toàn bộ trang web
    window.location.href = "/admin";
  };

  const navigate = useNavigate();
  // const [query, setQuery] = useState('');
  // const submitHandler = (e) => {
  //   e.preventDefault();
  //   navigate(query ? `/product/?query=${query}` : '/product');
  // };
  return (
    <>
      <header className="header-top-strip py-3">
        <div className="container-xxl">
          <div className="row">
            <div className="col-6">
              <div className="flex-col hide-for-medium flex-left">
                <ul className="nav nav-left medium-nav-center nav-small  nav-divided">
                  <li className="html custom html_topbar_left">
                    <p className="text-end text-white mb-0">
                      <i class="fa fa-map-marker mr-2"></i>Địa chỉ: 55 Giải
                      Phóng, Hai Bà Trưng, Hà Nội
                    </p>
                  </li>
                </ul>
              </div>
            </div>
            <div className="col-6">
              <p className="text-end text-white mb-0">
                <i className="fa fa-phone mr-2"></i>Hotline:
                <a className="text-white" href="tel:+91 8264954234">
                  +91 8264954234
                </a>
              </p>
            </div>
          </div>
        </div>
      </header>
      <header className="header-upper py-3">
        <div className="container-xxl">
          <div className="row align-items-center">
            <div className="col-2">
              <h2>
                <Link to="/" className="text-white">
                  Vinh Quang
                </Link>
              </h2>
            </div>
            <Form className="col-5" onSubmit={(e) => handleSearch(e)}>
              <InputGroup className="input-group">
                <FormControl
                  style={{ height: "50px" }}
                  type="text"
                  className="form-control py-2"
                  placeholder="Nhập tên sản phẩm..."
                  aria-label="Nhập tên sản phẩm..."
                  aria-describedby="basic-addon2"
                  onChange={(e) => setSearch(e.target.value)}
                ></FormControl>
                <Button
                  className="input-group-text p-3"
                  type="submit"
                  id="basic-addon2"
                >
                  <BsSearch className="fs-6" />
                </Button>
              </InputGroup>
            </Form>
            <div className="col-5">
              <div className="header-upper-links d-flex align-items-center justify-content-between">
                <div>
                  {/* <Link
                                        to="/compare-product"
                                        className="d-flex align-items-center gap-10 text-white"
                                    >
                                        <img src={compare} alt="compare" />
                                        <p className="mb-0">
                                            Compare <br /> Products
                                        </p>
                                    </Link> */}
                </div>
                <div>
                  {/* <Link
                                        to="/wishlist"
                                        className="d-flex align-items-center gap-10 text-white"
                                    >
                                        <img src={wishlist} alt="wishlist" />
                                        <p className="mb-0">
                                            Favourite <br /> wishlist
                                        </p>
                                    </Link> */}
                </div>
                <div className="d-flex align-items-center gap-10 text-white text-light">
                  {welcomeMessage ? (
                    <NavDropdown
                      title={welcomeMessage}
                      id="basic-nav-dropdown"
                      className="nav-dropdown-title"
                    >
                      {welcomeMessage && isAorN && (
                        <LinkContainer to="/admin" onClick={handleLinkClick}>
                          <NavDropdown.Item>Admin</NavDropdown.Item>
                        </LinkContainer>
                      )}
                      <LinkContainer to="/profile">
                        <NavDropdown.Item>Tài Khoản Của Tôi</NavDropdown.Item>
                      </LinkContainer>
                      {(welcomeMessage && isAorN) || (
                        <LinkContainer to="/to-pay">
                          <NavDropdown.Item>Lịch Sử Mua Hàng</NavDropdown.Item>
                        </LinkContainer>
                      )}
                      <NavDropdown.Divider />
                      <Link
                        className="dropdown-item"
                        to="/login"
                        onClick={logout}
                      >
                        Đăng xuất
                      </Link>
                    </NavDropdown>
                  ) : (
                    <Link className="nav-link" to="/login">
                      Đăng Nhập
                    </Link>
                  )}
                </div>
                {isLogin && (
                  <div>
                    <Link
                      to="/cart"
                      className="d-flex align-items-center gap-10 text-white"
                    >
                      <img src={cart} alt="cart" />
                      <div className="d-flex flex-column gap-10">
                        <span className="badge bg-white text-dark">
                          {cartCount}
                        </span>
                        <p className="mb-0">
                          {totalPrice.toLocaleString("vi-VN", {
                            style: "currency",
                            currency: "VND",
                          })}
                        </p>
                      </div>
                    </Link>
                  </div>
                )}
              </div>
            </div>
          </div>
        </div>
      </header>
      <header className="header-bottom py-3">
        <div className="container-xxl">
          <div className="row">
            <div className="col-12">
              <div className="menu-bottom d-flex align-items-center gap-30">
                <div>
                  <div className="dropdown">
                    <button
                      className="btn btn-secondary dropdown-toggle bg-transparent border-0 gap-15 d-flex align-items-center"
                      type="button"
                      id="dropdownMenuButton1"
                      data-bs-toggle="dropdown"
                      aria-expanded="false"
                    >
                      <img src={menu} alt="" />
                      <span className="me-5 d-inline-block">
                        Danh mục cửa hàng
                      </span>
                    </button>
                    <ul
                      className="dropdown-menu"
                      aria-labelledby="dropdownMenuButton1"
                    >
                      <li>
                        <Link className="dropdown-item text-white" to="">
                          Action
                        </Link>
                      </li>
                      <li>
                        <Link className="dropdown-item text-white" to="">
                          Another action
                        </Link>
                      </li>
                      <li>
                        <Link className="dropdown-item text-white" to="">
                          Something else here
                        </Link>
                      </li>
                    </ul>
                  </div>
                </div>
                <div className="menu-links">
                  <div className="d-flex align-items-center gap-15">
                    <NavLink to="/">Trang chủ</NavLink>
                    <NavLink to="/product">Sản phẩm</NavLink>
                    <NavLink to="/blogs">Blogs</NavLink>
                    <NavLink to="/contact">Liên hệ</NavLink>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </header>
    </>
  );
};

export default Header;
