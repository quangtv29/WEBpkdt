import React, { useEffect, useState, useContext } from "react";
import axios from "axios";
import Meta from "../Meta";
import CryptoJS from "crypto-js";
import { MyContext } from "../../encryptionKey";

const Deliveringg = () => {
  const [data, setData] = useState([]);
  const { encryptionKey } = useContext(MyContext);
  const [isOpen, setIsOpen] = useState(false);
  const handleConfirm = () => {
    console.log("meomeo");
  };
  const handleCancel = () => {
    setIsOpen(false);
  };
  const handleOnclick = () => {
    setIsOpen(true);
  };
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
      })
      .catch((err) => {
        console.error(err);
      });
  }, []);

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
      <div
        className=" "
        style={{
          backgroundColor: isOpen ? "rgba(0, 0, 0, 0.5)" : "#e7ecf0",
          height: "100%",
          boxSizing: "border-box",
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
            {data.map((item, index) => (
              <div key={item.id} className="border">
                <li
                  className="row d-flex align-items-center mt-2  "
                  style={{ padding: 0 }}
                >
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
                  <div
                    className="col-1 d-flex justify-content-center"
                    style={{ color: "#ee4d2d" }}
                  >
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
                  <div className="col-1 d-flex justify-content-center">
                    {item.intoMoney?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </div>
                  <div className="col-2 d-flex justify-content-center">
                    <button
                      type="button"
                      className="btn btn-danger"
                      onClick={() => handleOnclick()}
                    >
                      Huỷ
                    </button>
                  </div>
                </li>
              </div>
            ))}
          </li>
        </ul>
      </div>
    </>
  );
};

export default Deliveringg;
