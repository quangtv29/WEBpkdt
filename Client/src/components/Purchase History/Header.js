import { React, useEffect, useState } from "react";
import { Link, Outlet } from "react-router-dom";

const Headers = () => {
  return (
    <>
      <div className="container-fluid d-flex flex-column">
        <div className="row">
          <div
            className="col-md-2 "
            style={{ padding: "0px", backgroundColor: "#1E90FF" }}
          >
            <ul className="nav" style={{ width: "100%" }}>
              <li className="mb-4 mt-5">
                <Link to="/to-pay" className="nav-link ">
                  Chờ xác nhận
                </Link>
              </li>
              <li className=" mb-4  ">
                <Link
                  to="/to-pay/to-deliveringg"
                  className="nav-link text-light"
                >
                  Đang vận chuyển
                </Link>
              </li>
              <li className=" mb-4 ">
                <Link to="/to-pay/done" className="nav-link text-light">
                  Hoàn thành
                </Link>
              </li>
              <li className=" mb-4  ">
                <Link to="/to-pay/to-cancel" className="nav-link text-light">
                  Đã huỷ
                </Link>
              </li>
            </ul>
          </div>
          <div className="col-md-10 p-0">
            <Outlet />
          </div>
        </div>
      </div>
    </>
  );
};

export default Headers;
