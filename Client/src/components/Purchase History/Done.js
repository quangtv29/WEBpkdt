import React, { useEffect, useState, useContext } from "react";
import axios from "axios";
import { MyContext } from "../../encryptionKey";
import CryptoJS from "crypto-js";
import { Link } from "react-router-dom";
import Meta from "../Meta";
const Done = () => {
  const [data, setData] = useState([]);
  const { encryptionKey } = useContext(MyContext);
  const handleClick = (id) => {
    localStorage.removeItem("billid");
    localStorage.setItem("billid", id);
  };
  const decryptedId = CryptoJS.AES.decrypt(
    localStorage.getItem("id"),
    encryptionKey
  ).toString(CryptoJS.enc.Utf8);
  // eslint-disable-next-line react-hooks/exhaustive-deps
  useEffect(() => {
    axios
      .get(`https://localhost:7295/api/Bill/${decryptedId}/bills`)
      .then((response) => {
        setData(response.data);
      })
      .catch((err) => {
        console.error(err);
      });
  }, [decryptedId]);

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
      <Meta title="Đã hoàn thành" />
      <div className="container mt-2">
        <ul
          style={{
            padding: "0px",
            height: 500,
            position: "relative",
          }}
        >
          <li
            className="row d-flex"
            style={{ borderBottom: "1px solid black" }}
          >
            <div className="col-1 d-flex text-center text-bold ">
              Mã hoá đơn
            </div>
            <div className="col-3 d-flex justify-content-center text-center text-bold">
              Địa chỉ nhận hàng
            </div>
            <div className="col-1 d-flex justify-content-center text-center text-bold">
              Số điện thoại
            </div>
            <div className="col-2 d-flex justify-content-center text-bold">
              Thời gian đặt hàng
            </div>
            <div className="col-1 d-flex justify-content-center text-bold">
              Tạm tính{" "}
            </div>
            <div className="col-1 d-flex justify-content-center text-bold">
              Giảm giá
            </div>
            <div className="col-1 d-flex justify-content-center text-bold">
              Tổng tiền
            </div>
            <div className="col-2 d-flex justify-content-center text-bold"></div>
          </li>
          {data.map((item, index) => (
            <div key={index}>
              {item.status === 3 && (
                <li className="row d-flex align-items-center mt-2 border ">
                  <div className="col-1 d-flex justify-content-center">
                    {index + 1}
                  </div>
                  <div className="col-3 d-flex justify-content-center ">
                    {item.address}
                  </div>
                  <div className="col-1 d-flex justify-content-center">
                    {item.phoneNumber}
                  </div>
                  <div className="col-2 font-weight-bold  d-flex justify-content-center ">
                    {item.formatDate}
                  </div>
                  <div className="col-1 d-flex justify-content-center">
                    {item.totalMoney?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </div>
                  <div
                    className="col-1 d-flex justify-content-center"
                    style={{ color: "rgba(0,0,0,.87)" }}
                  >
                    {item.discount?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </div>
                  <div
                    className="col-1 d-flex justify-content-center"
                    style={{ color: "#ee4d2d" }}
                  >
                    {item.intoMoney?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </div>
                  <div className="col-2 d-flex justify-content-center">
                    <button
                      type="button"
                      className="btn"
                      style={{ backgroundColor: "#ee4d2d" }}
                    >
                      <Link
                        to="/to-pay/orderDetail"
                        onClick={() => handleClick(item.id)}
                        className="text-light"
                      >
                        Xem chi tiết
                      </Link>
                    </button>
                  </div>
                </li>
              )}
            </div>
          ))}
        </ul>
      </div>
    </>
  );
};

export default Done;
