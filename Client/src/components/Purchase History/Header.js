import React, { useState } from "react";
import { Link, Outlet } from "react-router-dom";
import "./Header.scss";

const Headers = () => {
  const [selectedLi, setSelectedLi] = useState(0);

  const handleLiClick = (index) => {
    setSelectedLi(index);
  };

  return (
    <>
      <div className="container-fluid d-flex flex-column p-0">
        <div>
          <div style={{ padding: 0 }}>
            <ul className="nav vip">
              <li className={selectedLi === 0 ? "active" : ""}>
                <Link
                  to="/to-pay"
                  className="nav-link"
                  onClick={() => handleLiClick(0)}
                >
                  Chờ xác nhận
                </Link>
              </li>
              <li className={selectedLi === 1 ? "active" : ""}>
                <Link
                  to="/to-pay/to-deliveringg"
                  className="nav-link"
                  onClick={() => handleLiClick(1)}
                >
                  Đang vận chuyển
                </Link>
              </li>
              <li className={selectedLi === 2 ? "active" : ""}>
                <Link
                  to="/to-pay/done"
                  className="nav-link"
                  onClick={() => handleLiClick(2)}
                >
                  Hoàn thành
                </Link>
              </li>
              <li className={selectedLi === 3 ? "active" : ""}>
                <Link
                  to="/to-pay/to-cancel"
                  className="nav-link"
                  onClick={() => handleLiClick(3)}
                >
                  Đã huỷ
                </Link>
              </li>
            </ul>
          </div>
          <div>
            <Outlet />
          </div>
        </div>
      </div>
    </>
  );
};

export default Headers;
