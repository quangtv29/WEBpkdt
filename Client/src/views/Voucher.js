import React, { useEffect, useState, useContext } from "react";
import axios from "axios";
import "./Voucher.css"; // Import file CSS
import { MyContext } from "../encryptionKey";
import CryptoJS from "crypto-js";

const Voucher = () => {
  const [data, setData] = useState([]);
  const { encryptionKey } = useContext(MyContext);
  const decryptedId = CryptoJS.AES.decrypt(
    localStorage.getItem("id"),
    encryptionKey
  ).toString(CryptoJS.enc.Utf8);
  useEffect(() => {
    axios
      .get(
        `https://localhost:7295/api/Sale/GetAllSale?customerid=${decryptedId}`
      )
      .then((res) => {
        setData(res.data);
      });
  }, [decryptedId]);

  const handleSave = (e, id) => {
    axios
      .post("https://localhost:7295/api/SaleDetail/CreateSD", {
        saleId: id,
        customerId: decryptedId,
      })
      .then((res) => {
        if (res.data === "Mã giảm giá đã được lưu hết") {
          alert("Mã giảm giá đã được lưu hết");
        } else {
          setData(
            data.filter((item) => {
              if (item.id === id) {
                item.isActive = true;
                item.count += 1;
              }
              return item;
            })
          );
        }
      });
  };

  return (
    <>
      <div style={{ minHeight: 500 }}>
        <h2 className="w-100 text-center">Danh sách mã giảm giá</h2>
        <div className="voucher-container">
          {data.map((item, index) => (
            <div key={index} className="voucher-item">
              <div className="voucher-details">
                <h6 className="voucher-code">{item?.discountCode}</h6>
                {item?.percent === 1 ? (
                  <p
                    className="voucher-discount"
                    style={{ fontSize: 17, fontWeight: "bold" }}
                  >
                    Giảm{" "}
                    {item?.money?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </p>
                ) : (
                  <p
                    className="voucher-discount"
                    style={{ fontSize: 17, fontWeight: "bold" }}
                  >
                    Giảm {item?.percent * 100}%
                  </p>
                )}

                <p className="voucher-min-bill">
                  Đơn tối thiểu{" "}
                  {item?.minBill?.toLocaleString("vi-VN", {
                    style: "currency",
                    currency: "VND",
                  })}
                  {item?.percent !== 1 && (
                    <span>
                      {" "}
                      Giảm tối đa{" "}
                      {item?.money?.toLocaleString("vi-VN", {
                        style: "currency",
                        currency: "VND",
                      })}
                    </span>
                  )}
                </p>
                <p className="voucher-expiry" style={{ color: "#ee4d2d" }}>
                  Hạn sử dụng mã: {item?.formatDate}
                </p>
                <p className="voucher-count">
                  Đã lưu: {item?.count}/{item?.quantity}
                </p>
              </div>
              <div className="e-voucher-button">
                {!item?.isActive && (
                  <button
                    onClick={(e) => handleSave(e, item?.id)}
                    className="voucher-button-save"
                  >
                    Lưu
                  </button>
                )}
                {item?.isActive && (
                  <button className="voucher-button">Đã lưu</button>
                )}
              </div>
            </div>
          ))}
        </div>
      </div>
    </>
  );
};

export default Voucher;
