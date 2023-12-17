import Sidebar from "../Siderbar/Sidebar";
import React, { useEffect, useRef } from "react";
import { Outlet } from "react-router-dom";
import "./LayoutAdmin.scss";
const Admin = (props) => {
  const pushMenuRef = useRef(null);

  const handleToggleClass = () => {
    const div = pushMenuRef.current;
    if (div) {
      div.classList.toggle("sidebar-collapse");
    }
  };

  return (
    <div className="sidebar-mini" style={{ height: "auto" }} ref={pushMenuRef}>
      <div className="wrapper">
        <nav className="main-header navbar navbar-expand navbar-white navbar-light">
          <ul className="navbar-nav">
            <li className="nav-item">
              <a
                className="nav-link"
                onClick={handleToggleClass}
                href="#"
                role="button"
              >
                <i className="fas fa-bars"></i>
              </a>
            </li>
            <li className="nav-item d-none d-sm-inline-block">
              <a href="../../index3.html" className="nav-link">
                Home
              </a>
            </li>
            <li className="nav-item d-none d-sm-inline-block">
              <a href="#" className="nav-link">
                Contact
              </a>
            </li>
          </ul>

          <ul className="navbar-nav ml-auto">
            <li className="nav-item">
              <a
                className="nav-link"
                data-widget="navbar-search"
                href="#"
                role="button"
              >
                <i className="fas fa-search"></i>
              </a>
              <div className="navbar-search-block">
                <form className="form-inline">
                  <div className="input-group input-group-sm">
                    <input
                      className="form-control form-control-navbar"
                      type="search"
                      placeholder="Search"
                      aria-label="Search"
                    ></input>
                    <div className="input-group-append">
                      <button className="btn btn-navbar" type="submit">
                        <i className="fas fa-search"></i>
                      </button>
                      {/* <button className="btn btn-navbar" type="button" data-widget="navbar-search">
                            <i className="fas fa-times"></i>
                            </button> */}
                    </div>
                  </div>
                </form>
              </div>
            </li>
          </ul>
        </nav>
        <div className="main-header navbar navbar-expand navbar-white navbar-light">
          {" "}
          <Outlet />
        </div>
        <Sidebar className="main-sidebar sidebar-dark-primary elevation-4" />
      </div>
    </div>
  );
};
export default Admin;
