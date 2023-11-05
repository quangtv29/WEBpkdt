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
      <aside class="main-sidebar sidebar-dark-primary elevation-4">
        <a href="/" class="brand-link">
          {/* <img src="" alt="Vinh Quang" class="brand-image img-circle elevation-3" style="opacity: .8"></img> */}
          <span class="brand-text font-weight-light">Vinh Quang</span>
        </a>

        <div class="sidebar">
          <div class="user-panel mt-3 pb-3 mb-3 d-flex">
            <div class="info">
              <a href="#" class="d-block">
                {welcomeMessage}
              </a>
            </div>
          </div>

          <div class="form-inline">
            <div class="input-group" data-widget="sidebar-search">
              <input
                class="form-control form-control-sidebar"
                type="search"
                placeholder="Search"
                aria-label="Search"
              ></input>
              <div class="input-group-append">
                <button class="btn btn-sidebar">
                  <i class="fas fa-search fa-fw"></i>
                </button>
              </div>
            </div>
          </div>

          <nav class="mt-2">
            <ul
              class="nav nav-pills nav-sidebar flex-column"
              role="menu"
              data-accordion="false"
            >
              <li class="nav-item">
                <a href="#" class="nav-link">
                  <i class="nav-icon fas fa-table"></i>
                  <p>
                    Bài viết giới thiệu<i class="fas fa-angle-left right"></i>
                  </p>
                </a>
                <ul class="nav nav-treeview">
                  <li class="nav-item">
                    <a href="pages/tables/simple.html" class="nav-link">
                      <i class="far fa-circle nav-icon"></i>
                      <p>Đăng bài viết</p>
                    </a>
                  </li>
                  <li class="nav-item">
                    <a href="admin/lop/add" class="nav-link">
                      <i class="far fa-circle nav-icon"></i>
                      <p>Danh sách bài viết</p>
                    </a>
                  </li>
                </ul>
              </li>
              <li class="nav-item">
                <a href="#" class="nav-link">
                  <i class="nav-icon fas fa-table"></i>
                  <p>
                    Quản lý sản phẩm<i class="fas fa-angle-left right"></i>
                  </p>
                </a>
                <ul class="nav nav-treeview">
                  <li class="nav-item">
                    <a href="/admin/list-product" class="nav-link">
                      <i class="far fa-circle nav-icon"></i>
                      <p>Danh sách sản phẩm</p>
                    </a>
                  </li>
                  <li class="nav-item">
                    <a href="/admin/list-type-product" class="nav-link">
                      <i class="far fa-circle nav-icon"></i>
                      <p>Danh sách loại sản phẩm</p>
                    </a>
                  </li>
                </ul>
              </li>
              <li class="nav-item">
                <a href="#" class="nav-link">
                  <i class="nav-icon fas fa-table"></i>
                  <p>
                    Quản lý đơn hàng<i class="fas fa-angle-left right"></i>
                  </p>
                </a>
                <ul class="nav nav-treeview">
                  <li class="nav-item">
                    <a href="/admin/list-bill" class="nav-link">
                      <i class="far fa-circle nav-icon"></i>
                      <p>Đơn hàng mới tạo</p>
                    </a>
                  </li>
                  <li class="nav-item">
                    <a href="pages/tables/data.html" class="nav-link">
                      <i class="far fa-circle nav-icon"></i>
                      <p>Đang giao cho khách</p>
                    </a>
                  </li>
                  <li class="nav-item">
                    <a href="pages/tables/data.html" class="nav-link">
                      <i class="far fa-circle nav-icon"></i>
                      <p>Đã giao thành công</p>
                    </a>
                  </li>
                  <li class="nav-item">
                    <a href="pages/tables/data.html" class="nav-link">
                      <i class="far fa-circle nav-icon"></i>
                      <p>Đơn hàng bị hủy</p>
                    </a>
                  </li>
                  <li style={{ textAlign: "center" }}>
                    <button onClick={() => logout()} className="custom-button">
                      <b>Đăng xuất</b>
                    </button>
                  </li>
                </ul>
              </li>
            </ul>
          </nav>
        </div>
      </aside>
    </>
  );
};
export default Sidebar;
