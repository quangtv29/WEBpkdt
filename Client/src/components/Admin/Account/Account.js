import React, { useEffect, useState } from "react";
import axios from "axios";
import "./Account.css";

const AccountInfo = () => {
  const [detailOrder, setDetailOrder] = useState([]);
  const [id, setId] = useState("");
  const [customer, setCustomer] = useState([]);
  const [searchUsername, setSearchUsername] = useState("");
  const [name, setName] = useState("");
  let userName = localStorage.getItem("username");
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
    setName(response.data.firstName + " " + response.data.lastName);
    setId(response.data.id);
  };
  const [image, setImage] = useState("");
  const [cuid, setCuId] = useState("");
  const [isActive, setIsActive] = useState("");
  useEffect(() => {
    if (id) {
      axios
        .get(`https://localhost:7295/api/Customer/${id}`)
        .then((res) => {
          setImage(res.data.data[0].image);
          setCuId(res.data.data[0].id);
          setIsActive(res.data.data[0].isActive);
        })
        .catch((err) => {
          console.error(err);
        });
    }
  }, [id]);
  const handleChangeActive = (e) => {
    axios
      .post(`https://localhost:7295/api/Customer/lockAccount?id=${cuid}`)
      .then((res) => {
        alert("Thành công");
        window.location.reload();
      });
  };
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
        {name}
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
      {id && (
        <div className="account-info-item">
          {isActive ? (
            <button
              className="text-center p-1"
              onClick={(e) => handleChangeActive(e)}
            >
              Khoá tài khoản
            </button>
          ) : (
            <button
              className="text-center p-1"
              onClick={(e) => handleChangeActive(e)}
            >
              Mở khoá tài khoản
            </button>
          )}
        </div>
      )}
    </div>
  );
};

export default AccountInfo;
