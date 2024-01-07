import React, { useContext, useState } from "react";
import { NavLink, Link } from "react-router-dom";
import { BsSearch } from "react-icons/bs";
import NavDropdown from "react-bootstrap/NavDropdown";
import { LinkContainer } from "react-router-bootstrap";
import cart from "../assets/images/cart.svg";
import menu from "../assets/images/menu.svg";
import { CartContext } from "../CartContext";
import "./Admin/LayoutAdmin/LayoutAdmin.scss";
import { useNavigate } from "react-router-dom";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import InputGroup from "react-bootstrap/InputGroup";
import FormControl from "react-bootstrap/FormControl";
import { useEffect } from "react";
import axios from "axios";
import { MyContext } from "../encryptionKey";
import { SearchContext } from "../SearchContext";
import CryptoJS from "crypto-js";
import Avatar from "./Avatar";
const Header = () => {
  const { setSearchTerm } = useContext(CartContext);
  const { search, setSearch, setStatus } = useContext(SearchContext);
  const [customer, setCustomer] = useState([]);
  const [noti, setNoti] = useState([]);
  const [isLogin, setIsLogin] = useState(false);
  const { encryptionKey } = useContext(MyContext);
  const [count, setCount] = useState(0);
  const [totalCart, setTotalCart] = useState(0);
  const [avatar, setAvatar] = useState("");

  const decryptedId = isLogin
    ? CryptoJS.AES.decrypt(localStorage.getItem("id"), encryptionKey).toString(
        CryptoJS.enc.Utf8
      )
    : null;

  useEffect(() => {
    if (isLogin) {
      axios
        .get("https://localhost:7295/api/Authentication", {
          params: {
            id: decryptedId,
          },
        })
        .then((res) => {
          setCustomer(res.data.firstName + " " + res.data.lastName);
        });
    }
  }, [decryptedId, isLogin]);
  useEffect(() => {
    if (isLogin) {
      axios
        .get(`https://localhost:7295/api/Customer/${decryptedId}`)
        .then((res) => {
          setAvatar(res.data.data[0].image);
        })
        .catch((err) => {
          console.error(err);
        });
    }
  }, [decryptedId, isLogin]);
  useEffect(() => {
    if (isLogin) {
      axios
        .get(
          `https://localhost:7295/api/OrderDetail/listCart?CustomerId=${decryptedId}`
        )
        .then((res) => {
          setCount(res.data.length);
          var a = 0;
          res.data.map((item) => {
            a += item?.totalMoney;
          });
          setTotalCart(a);
        })
        .catch((err) => {
          console.error(err);
        });
    }
  }, [decryptedId, isLogin]);
  const [currentPage, setCurrentPage] = useState(1);

  const handleNoti = (e) => {
    e.preventDefault();
    if (isLogin) {
      axios
        .post(
          "https://localhost:7295/api/Notification/getNotiByCustomerId",
          {
            pageNumber: currentPage,
            pageSize: 5,
          },
          {
            params: {
              customerId: decryptedId,
            },
          }
        )
        .then((res) => {
          setNoti(res.data);
        });
    }
  };
  const handleLoadMore = () => {
    setCurrentPage((prevPage) => prevPage + 1);
  };
  const chucvu = localStorage.getItem("chucvu");
  const isAorN = chucvu === "Nhân viên" || chucvu === "Manager";
  // let welcomeMessage = "";
  // const u = customer?.firstName + " " + customer?.lastName;
  // if (u === "undefined undefined") {
  //   welcomeMessage = undefined;
  // } else {
  //   welcomeMessage = u;
  // }
  const logout = () => {
    axios.post("https://localhost:7295/api/Authentication/logout", {});
    localStorage.clear();
    setIsLogin(false);
    navigate("/login", { replace: true });
    setCustomer(null);
  };
  const handleSearch = (e) => {
    e.preventDefault();
    navigate(search ? `/product/?search=${search}` : "/product");
    setSearchTerm(search);
  };
  if (!isLogin) {
    if (localStorage.getItem("id") != null) {
      setIsLogin(true);
    }
  }

  const handleLinkClick = () => {
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
      <header className="header-top-strip py-3 ">
        <div className="container-xxl m-0" style={{ maxWidth: 1451 }}>
          <div className="row">
            <div className="col-6">
              <div className="flex-col hide-for-medium flex-left">
                <ul className="nav nav-left medium-nav-center nav-small  nav-divided">
                  <li className="html custom html_topbar_left">
                    <p className="text-end text-white mb-0">
                      <i className="fa fa-map-marker mr-2"></i>Địa chỉ: 55 Giải
                      Phóng, Hai Bà Trưng, Hà Nội
                    </p>
                  </li>
                </ul>
              </div>
            </div>
            <div className="col-6">
              <p className="text-end text-white mb-0">
                <i className="fa fa-phone mr-2"></i>Hotline:
                <a className="text-white" href="tel:+84 862260888">
                  +84 862260888
                </a>
              </p>
            </div>
          </div>
        </div>
      </header>
      <header className="header-upper py-3">
        <div className="container-xxl m-0" style={{ maxWidth: 1451 }}>
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
                  onClick={() => {
                    setStatus(true);
                  }}
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
                {isLogin && (
                  <div>
                    <NavDropdown
                      title=" Thông báo 🔔"
                      onClick={(e) => handleNoti(e)}
                      drop="down "
                    >
                      <div
                        style={{ display: "flex", justifyContent: "flex-end" }}
                      >
                        <h6
                          style={{
                            color: "red",
                            marginRight: 6,
                            cursor: "pointer",
                          }}
                        >
                          Đọc tất cả
                        </h6>
                      </div>
                      {noti?.map((item, index) => (
                        <div key={index}>
                          <NavDropdown.Item
                            style={{
                              maxWidth: 500,
                              minWidth: 500,
                              borderTop: "1px solid black",
                              backgroundColor:
                                item?.watched === 1 ? "#DDDDDD" : "#fff",
                              padding: "7px",
                            }}
                          >
                            <h6>{item?.header}</h6>
                            <p
                              style={{
                                whiteSpace: "normal",
                              }}
                            >
                              {item?.content}
                            </p>
                            <p style={{ fontSize: 13, margin: 0 }}>
                              {item?.formatDate}
                            </p>
                          </NavDropdown.Item>
                        </div>
                      ))}
                      <NavDropdown.Item>
                        <Link to="/noti">
                          <button>Xem tất cả</button>
                        </Link>
                      </NavDropdown.Item>
                    </NavDropdown>
                  </div>
                )}
                {isLogin && <Avatar Image={avatar} />}

                <div className="d-flex align-items-center gap-10 text-white text-light">
                  {isLogin ? (
                    <NavDropdown
                      title={customer}
                      id="basic-nav-dropdown"
                      className="nav-dropdown-title"
                    >
                      {customer && isAorN && (
                        <LinkContainer to="/admin" onClick={handleLinkClick}>
                          <NavDropdown.Item>Admin</NavDropdown.Item>
                        </LinkContainer>
                      )}
                      <LinkContainer to="/profile">
                        <NavDropdown.Item>Tài Khoản Của Tôi</NavDropdown.Item>
                      </LinkContainer>
                      <LinkContainer to="/resetpassword">
                        <NavDropdown.Item>Đổi Mật Khẩu</NavDropdown.Item>
                      </LinkContainer>
                      {(customer && isAorN) || (
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
                          {count}
                        </span>
                        <p className="mb-0">
                          {totalCart.toLocaleString("vi-VN", {
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
        <div className="container-xxl" style={{ maxWidth: 1451 }}>
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
                      {isLogin && (
                        <li>
                          <Link
                            className="dropdown-item text-white"
                            to="/voucher"
                          >
                            Kho voucher
                          </Link>
                        </li>
                      )}
                      {isLogin && (
                        <li>
                          <Link className="dropdown-item text-white" to="/noti">
                            Thông báo
                          </Link>
                        </li>
                      )}
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
