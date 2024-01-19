import React from "react";
import "../../../styles/adminlte.min.css";
import "./Siderbar.scss";
import {
  faChartBar,
  faLight,
  faTicketsPerforated,
  faUser,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { Link } from "react-router-dom";
import { Breadcrumb, Layout, Menu, theme } from "antd";

function getItem(label, key, icon, children) {
  return {
    key,
    icon,
    children,
    label,
  };
}
const items = [
  getItem(
    "Bài viết giới thiệu",
    "sub1",
    <i className="nav-icon fas fa-table"></i>,
    [
      getItem("Đăng bài viết", "createblog"),
      getItem("Danh sách bài viết", "lop/add"),
    ]
  ),
  getItem(
    "Quản lý sản phẩm",
    "sub2",
    <i className="nav-icon fas fa-table"></i>,
    [
      getItem("Danh sách sản phẩm", "list-product"),
      getItem("Danh sách loại sản phẩm", "list-type-product"),
    ]
  ),
  getItem(
    "Quản lý đơn hàng",
    "sub3",
    <i className="nav-icon fas fa-table"></i>,
    [
      getItem("Đơn hàng mới tạo", "list-bill"),
      getItem("Đơn hàng giao cho khách", "delivering"),
      getItem("Đơn hàng hoàn thành", "done"),
      getItem("Đơn hàng bị hủy", "cancel"),
    ]
  ),
  getItem(
    "Chương trình khuyến mại",
    "discount",
    <FontAwesomeIcon icon={faChartBar} size="1x" />
  ),
  getItem(
    "Thống kê",
    "statistics",
    <FontAwesomeIcon icon={faChartBar} size="1x" />
  ),
  getItem(
    "Quản lý tài khoản",
    "accountinfo",
    <FontAwesomeIcon icon={faUser} size="1x" />
  ),
];

const Sidebar = () => {
  const user = localStorage.getItem("lastname");
  const navigate = useNavigate();
  const welcomeMessage = `Xin chào, ${user}!`;

  const logout = () => {
    localStorage.clear();
    window.location.href = "/login";
  };

  return (
    <>
      <aside className="main-sidebar sidebar-dark-primary elevation-4">
        <a href="/" className="brand-link">
          {/* <img src="" alt="Vinh Quang" class="brand-image img-circle elevation-3" style="opacity: .8"></img> */}
          <span className="brand-text font-weight-light">Vinh Quang</span>
        </a>

        <div className="sidebar">
          <div className="user-panel mt-3 pb-3 mb-3 d-flex">
            <div className="info">
              <a href="/admin" className="d-block">
                {welcomeMessage}
              </a>
            </div>
          </div>

          {/* <div className="form-inline">
            <div className="input-group" data-widget="sidebar-search">
              <input
                className="form-control form-control-sidebar"
                type="search"
                placeholder="Search"
                aria-label="Search"
              ></input>
              <div className="input-group-append">
                <button className="btn btn-sidebar">
                  <i className="fas fa-search fa-fw"></i>
                </button>
              </div>
            </div>
          </div> */}
          <Menu
            theme="dark"
            defaultSelectedKeys={["1"]}
            mode="inline"
            className="menu"
          >
            {items.map((item) => {
              if (item?.children) {
                return (
                  <Menu.SubMenu
                    key={item.key}
                    icon={item.icon}
                    title={item.label}
                    className="sub-menu"
                  >
                    {item.children.map((child) => (
                      <Menu.Item key={child.key} className="menu-item">
                        <Link to={`/admin/${child.key}`}>{child.label}</Link>
                      </Menu.Item>
                    ))}
                  </Menu.SubMenu>
                );
              } else {
                return (
                  <Menu.Item key={item.key} icon={item.icon}>
                    <Link to={`/admin/${item.key}`}>{item.label}</Link>
                  </Menu.Item>
                );
              }
            })}
          </Menu>

          <div style={{ textAlign: "center", margin: "20px" }}>
            <button onClick={() => logout()} className="custom-button">
              <b>Đăng xuất</b>
            </button>
          </div>
        </div>
      </aside>
    </>
  );
};
export default Sidebar;
