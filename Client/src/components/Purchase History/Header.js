import { React, useEffect, useState } from "react";
import { Link, Outlet } from "react-router-dom";
import "./Header.scss";

const Headers = () => {
  return (
    <>
      <div className="container-fluid d-flex flex-column ">
        <div className="row">
          <div className="col-md-2 mt-3 ">
            <ul className="nav vip" style={{ width: "100%" }}>
              <li className="" style={{ width: "100%" }}>
                <Link to="/to-pay" className=" nav-link ">
                  Chờ xác nhận
                </Link>
              </li>
              <li className=" w-100">
                <Link to="/to-pay/to-deliveringg" className="nav-link ">
                  Đang vận chuyển
                </Link>
              </li>
              <li className="  w-100">
                <Link to="/to-pay/done" className="nav-link ">
                  Hoàn thành
                </Link>
              </li>
              <li className=" w-100 ">
                <Link to="/to-pay/to-cancel" className="nav-link ">
                  Đã huỷ
                </Link>
              </li>
            </ul>
          </div>
          <div className="col-md-10 p-0 mt-3">
            <Outlet />
          </div>
        </div>
      </div>
    </>
  );
};

export default Headers;
