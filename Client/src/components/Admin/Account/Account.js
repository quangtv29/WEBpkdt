import React, { useEffect, useState } from "react";
import axios from "axios";
import "./Account.css";

const AccountInfo = () => {
  const [detailOrder, setDetailOrder] = useState([]);
  const [id, setId] = useState("");
  const [customer, setCustomer] = useState([]);
  const [searchUsername, setSearchUsername] = useState("");

  useEffect(() => {
    if (id) {
      axios
        .post(
          "https://localhost:7295/api/Bill/getInfoOrder",
          {},
          {
            params: {
              Id: id,
            },
          }
        )
        .then((res) => {
          setDetailOrder(res.data);
        });
    }
  }, [id]);

  const handleSearch = async () => {
    const response = await axios.get(
      "https://localhost:7295/api/Authentication/getInfoByName",
      {
        params: {
          userName: searchUsername,
        },
      }
    );
    setCustomer(response.data);
    setId(response.data.id);
  };
  const [image, setImage] = useState("");
  useEffect(() => {
    if (id) {
      axios
        .get(`https://localhost:7295/api/Customer/${id}`)
        .then((res) => {
          setImage(res.data.data[0].image);
        })
        .catch((err) => {
          console.error(err);
        });
    }
  }, [id]);
  return (
    <div className="account-info-container">
      <h2 className="account-info-heading">Thông tin tài khoản</h2>

      <div>
        {/* Bước 2: Thêm ô nhập liệu để tìm kiếm theo tên người dùng */}
        <input
          type="text"
          placeholder="Nhập tên người dùng"
          value={searchUsername}
          onChange={(e) => setSearchUsername(e.target.value)}
        />
        <button onClick={handleSearch}>Tìm kiếm</button>
      </div>

      {image && (
        <img src={image} alt="Ảnh đại diện" className="account-info-avatar" />
      )}

      <div className="account-info-item">
        <span className="account-info-label">Họ và tên:</span>
        {customer?.firstName + " " + customer?.lastName}
      </div>
      <div className="account-info-item">
        <span className="account-info-label">Đơn hàng đã mua:</span>
        {detailOrder?.quantity}
      </div>
      <div className="account-info-item">
        <span className="account-info-label">Đơn hàng đã huỷ:</span>
        {detailOrder?.quantityCancel}
      </div>
      <div className="account-info-item">
        <span className="account-info-label">
          Tổng số tiền đã mua tháng này:
        </span>

        {detailOrder?.totalOrderofMonth?.toLocaleString("vi-VN", {
          style: "currency",
          currency: "VND",
        })}
      </div>
      <div className="account-info-item">
        <span className="account-info-label">Số tiền được giảm giá</span>
        {detailOrder?.totalDiscount?.toLocaleString("vi-VN", {
          style: "currency",
          currency: "VND",
        })}
      </div>
      <div className="account-info-item">
        <span className="account-info-label">Tổng số tiền đã mua:</span>
        {detailOrder?.totalOrder?.toLocaleString("vi-VN", {
          style: "currency",
          currency: "VND",
        })}
      </div>
      <div className="account-info-item">
        <button className="text-center p-1">Khoá tài khoản</button>
      </div>
    </div>
  );
};

export default AccountInfo;
