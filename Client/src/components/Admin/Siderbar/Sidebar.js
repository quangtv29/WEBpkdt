import React, { useState } from "react";
import "../../../styles/adminlte.min.css";
import "./Siderbar.scss";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const Sidebar = (props) => {
  const user = localStorage.getItem("lastname");
  const navigate = useNavigate();
  const welcomeMessage = `Welcome, ${user}!`;
  const logout = () => {
    localStorage.clear();
    navigate("/login", { replace: true });
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
              <a href="#" className="d-block">
                {welcomeMessage}
              </a>
            </div>
          </div>

          <div className="form-inline">
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
          </div>

          <nav className="mt-2">
            <ul
              className="nav nav-pills nav-sidebar flex-column"
              role="menu"
              data-accordion="false"
            >
              <li className="nav-item">
                <a href="#" className="nav-link">
                  <i className="nav-icon fas fa-table"></i>
                  <p>
                    Bài viết giới thiệu
                    <i className="fas fa-angle-left right"></i>
                  </p>
                </a>
                <ul className="nav nav-treeview">
                  <li className="nav-item">
                    <a href="pages/tables/simple.html" className="nav-link">
                      <i className="far fa-circle nav-icon"></i>
                      <p>Đăng bài viết</p>
                    </a>
                  </li>
                  <li className="nav-item">
                    <a href="admin/lop/add" className="nav-link">
                      <i className="far fa-circle nav-icon"></i>
                      <p>Danh sách bài viết</p>
                    </a>
                  </li>
                </ul>
              </li>
              <li className="nav-item">
                <a href="#" className="nav-link">
                  <i className="nav-icon fas fa-table"></i>
                  <p>
                    Quản lý sản phẩm<i className="fas fa-angle-left right"></i>
                  </p>
                </a>
                <ul className="nav nav-treeview">
                  <li className="nav-item">
                    <a href="/admin/list-product" className="nav-link">
                      <i className="far fa-circle nav-icon"></i>
                      <p>Danh sách sản phẩm</p>
                    </a>
                  </li>
                  <li className="nav-item">
                    <a href="/admin/list-type-product" className="nav-link">
                      <i className="far fa-circle nav-icon"></i>
                      <p>Danh sách loại sản phẩm</p>
                    </a>
                  </li>
                </ul>
              </li>
              <li className="nav-item">
                <a href="#" className="nav-link">
                  <i className="nav-icon fas fa-table"></i>
                  <p>
                    Quản lý đơn hàng<i className="fas fa-angle-left right"></i>
                  </p>
                </a>
                <ul className="nav nav-treeview">
                  <li className="nav-item">
                    <a href="/admin/list-bill" className="nav-link">
                      <i className="far fa-circle nav-icon"></i>
                      <p>Đơn hàng mới tạo</p>
                    </a>
                  </li>
                  <li className="nav-item">
                    <a href="pages/tables/data.html" className="nav-link">
                      <i className="far fa-circle nav-icon"></i>
                      <p>Đang giao cho khách</p>
                    </a>
                  </li>
                  <li className="nav-item">
                    <a href="pages/tables/data.html" className="nav-link">
                      <i className="far fa-circle nav-icon"></i>
                      <p>Đã giao thành công</p>
                    </a>
                  </li>
                  <li className="nav-item">
                    <a href="pages/tables/data.html" className="nav-link">
                      <i className="far fa-circle nav-icon"></i>
                      <p>Đơn hàng bị hủy</p>
                    </a>
                  </li>
                </ul>
              </li>
              <li className="nav-item">
                <a href="#" className="nav-link">
                  {/* <i className="nav-icon fas fa-table"></i> */}
                  <p>
                    Thống kê<i className=""></i>
                  </p>
                </a>
              </li>
              <li style={{ textAlign: "center" }}>
                <button onClick={() => logout()} className="custom-button">
                  <b>Đăng xuất</b>
                </button>
              </li>
            </ul>
          </nav>
        </div>
      </aside>
    </>
  );
};
export default Sidebar;
