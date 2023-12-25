import React, { useEffect, useState, useContext } from "react";
import axios from "axios";
import { MyContext } from "../../encryptionKey";
import CryptoJS from "crypto-js";
import { Link } from "react-router-dom";
import Meta from "../Meta";
import "./Done.scss";

const Done = () => {
  const [data, setData] = useState([]);
  const { encryptionKey } = useContext(MyContext);

  const decryptedId = CryptoJS.AES.decrypt(
    localStorage.getItem("id"),
    encryptionKey
  ).toString(CryptoJS.enc.Utf8);
  const accessToken = localStorage.getItem("accessToken");

  useEffect(() => {
    axios.defaults.headers.common["Authorization"] = `Bearer ${accessToken}`;
    axios
      .post(
        `https://localhost:7295/api/Bill/${decryptedId}/bills`,
        {},
        {
          params: {
            Status: 0,
          },
        }
      )
      .then((response) => {
        setData(response.data);
      })
      .catch((err) => {
        console.error(err);
      });
  }, [decryptedId, accessToken]);

  return (
    <>
      <Meta title="Đã hoàn thành" />
      <div className="done-container">
        <ul className="done-list">
          <li className="done-list-header">
            <div className="done-list-item">Mã hoá đơn</div>
            <div className="done-list-item">Địa chỉ</div>
            <div className="done-list-item">Số điện thoại</div>
            <div className="done-list-item">Thời gian nhận hàng</div>
            <div className="done-list-item">Tạm tính</div>
            <div className="done-list-item">Giảm giá</div>
            <div className="done-list-item">Tổng tiền</div>
            <div className="done-list-item"></div>
          </li>
          <li>
            <ul style={{ padding: 0 }}>
              {data.map((item) => (
                <div
                  key={item.id}
                  className="done-list-item"
                  style={{ border: 0 }}
                >
                  <li className="done-list-row">
                    <div style={{ border: 0 }} className="done-list-item">
                      {item?.id}
                    </div>
                    <div style={{ border: 0 }} className="done-list-item">
                      {item?.address}
                    </div>
                    <div style={{ border: 0 }} className="done-list-item">
                      {item?.phoneNumber}
                    </div>
                    <div
                      style={{ border: 0 }}
                      className="done-list-item font-weight-bold"
                    >
                      {item?.formatShippingDate}
                    </div>
                    <div
                      className="done-list-item done-list-money"
                      style={{ color: "#ee4d2d", border: 0 }}
                    >
                      {item?.totalMoney?.toLocaleString("vi-VN", {
                        style: "currency",
                        currency: "VND",
                      })}
                    </div>
                    <div
                      className="done-list-item done-list-money"
                      style={{ color: "rgba(0,0,0,.87)", border: 0 }}
                    >
                      {item?.discount?.toLocaleString("vi-VN", {
                        style: "currency",
                        currency: "VND",
                      })}
                    </div>
                    <div
                      className="done-list-item done-list-money"
                      style={{ border: 0 }}
                    >
                      {item?.intoMoney?.toLocaleString("vi-VN", {
                        style: "currency",
                        currency: "VND",
                      })}
                    </div>
                    <div className="done-list-item" style={{ border: 0 }}>
                      <button
                        type="button"
                        className="btn btn-danger done-list-button"
                        onClick={() => {
                          localStorage.setItem("billid11", item.id);
                        }}
                      >
                        <Link to="../orderDetail" style={{ color: "#fff" }}>
                          Chi tiết
                        </Link>
                      </button>
                    </div>
                  </li>
                </div>
              ))}
            </ul>
          </li>
        </ul>
      </div>
    </>
  );
};

export default Done;
