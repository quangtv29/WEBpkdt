import React, { useEffect, useState, useContext } from "react";
import axios from "axios";
import { MyContext } from "../../encryptionKey";
import CryptoJS from "crypto-js";
import Meta from "../Meta";
import { Link } from "react-router-dom";
import "./Done.scss";

const Delivering = () => {
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
            Status: 1,
          },
        }
      )
      .then((response) => {
        setData(response.data);
        console.log(response.data);
      })
      .catch((err) => {});
  }, [decryptedId, accessToken]);
  const handleDone = (e, id) => {
    e.preventDefault();
    axios
      .post(
        "https://localhost:7295/api/Bill/updateStatusBill",
        {},
        {
          params: {
            Id: id,
            status: 0,
          },
        }
      )
      .then(() => {
        setData(data.filter((item) => item.id !== id));
      });
  };

  // const handleCancel = (id) => {
  //   axios
  //     .put(`/api/cancel/${id}`)
  //     .then(() => {
  //       setData(
  //         data.filter((dt) => {
  //           return dt.MaCTHD !== id;
  //         })
  //       );
  //     })
  //     .catch((err) => {
  //       console.error(err);
  //     });
  // };
  return (
    <>
      <Meta title="Đang vận chuyển" />
      <div className="done-container">
        <ul className="done-list">
          <li className="done-list-header">
            <div className="done-list-item">Mã hoá đơn</div>
            <div className="done-list-item">Địa chỉ</div>
            <div className="done-list-item">Số điện thoại</div>
            <div className="done-list-item">Thời gian đặt hàng</div>
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
                      {item?.formatDate}
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
                        className="btn btn-danger mb-2 ml-1 w-100"
                        onClick={() => {
                          localStorage.setItem("billid11", item?.id);
                        }}
                      >
                        <Link to="../orderDetail" className="text-light">
                          Chi tiết
                        </Link>
                      </button>
                      <button
                        type="button"
                        className="btn btn-primary ml-1 w-100 "
                        onClick={(e) => handleDone(e, item?.id)}
                      >
                        Đã nhận hàng
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

export default Delivering;
