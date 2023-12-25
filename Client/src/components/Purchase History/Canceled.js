import React, { useEffect, useState, useContext } from "react";
import axios from "axios";
import { MyContext } from "../../encryptionKey";
import CryptoJS from "crypto-js";
import Meta from "../Meta";
import { Link } from "react-router-dom";

const Canceled = () => {
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
            Status: 2,
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
      <Meta title="Chờ xác nhận" />
      <div
        className=" "
        style={{
          backgroundColor: "#e7ecf0",
          height: "100%",
          boxSizing: "border-box",
          minHeight: 500,
        }}
      >
        <ul
          style={{ padding: "0px", backgroundColor: "#fff", listStyle: "none" }}
        >
          <li className="row d-flex border m-0">
            <div className="col-1 d-flex text-center ">Mã hoá đơn</div>
            <div className="col-3 d-flex justify-content-center text-center">
              Địa chỉ
            </div>
            <div className="col-1 d-flex justify-content-center text-center">
              Số điện thoại
            </div>
            <div className="col-2 d-flex justify-content-center">
              Thời gian đặt hàng
            </div>
            <div className="col-1 d-flex justify-content-center">Tạm tính </div>
            <div className="col-1 d-flex justify-content-center">Giảm giá</div>
            <div className="col-1 d-flex justify-content-center">Tổng tiền</div>
            <div className="col-2 d-flex justify-content-center"></div>
          </li>
          <li>
            <ul style={{ padding: 0 }}>
              {data.map((item) => (
                <div key={item?.id} className="border">
                  {item?.status === 2 && (
                    <li
                      className="row d-flex align-items-center mt-2  "
                      style={{ padding: 0 }}
                    >
                      <div className="col-1 d-flex justify-content-center">
                        {item?.id}
                      </div>
                      <div className="col-3 d-flex justify-content-center ">
                        {item?.address}
                      </div>
                      <div className="col-1 d-flex justify-content-center">
                        {item?.phoneNumber}
                      </div>
                      <div className="col-2 font-weight-bold  d-flex justify-content-center ">
                        {item?.formatDate}
                      </div>
                      <div
                        className="col-1 d-flex justify-content-center"
                        style={{ color: "#ee4d2d" }}
                      >
                        {item?.totalMoney?.toLocaleString("vi-VN", {
                          style: "currency",
                          currency: "VND",
                        })}
                      </div>
                      <div
                        className="col-1 d-flex justify-content-center"
                        style={{ color: "rgba(0,0,0,.87)" }}
                      >
                        {item?.discount?.toLocaleString("vi-VN", {
                          style: "currency",
                          currency: "VND",
                        })}
                      </div>
                      <div className="col-1 d-flex justify-content-center">
                        {item.intoMoney?.toLocaleString("vi-VN", {
                          style: "currency",
                          currency: "VND",
                        })}
                      </div>

                      <div className="col-2 d-flex justify-content-center">
                        <button
                          type="button"
                          className="btn btn-danger "
                          onClick={() => {
                            localStorage.setItem("billid11", item.id);
                          }}
                        >
                          <Link to="../orderDetail" className="text-light">
                            Chi tiết
                          </Link>
                        </button>
                      </div>
                    </li>
                  )}
                </div>
              ))}
            </ul>
          </li>
        </ul>
      </div>
    </>
  );
};

export default Canceled;
