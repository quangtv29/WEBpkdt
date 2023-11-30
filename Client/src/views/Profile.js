import React, { useEffect, useState, useContext } from "react";
import { Container } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { MyContext } from "../encryptionKey";
import CryptoJS from "crypto-js";

const Profile = () => {
  const navigate = useNavigate();
  useEffect(() => {
    if (!localStorage.getItem("id")) {
      navigate("/login", { replace: true });
    }
  }, [navigate]);
  const { encryptionKey } = useContext(MyContext);
  const decryptedId = CryptoJS.AES.decrypt(
    localStorage.getItem("id"),
    encryptionKey
  ).toString(CryptoJS.enc.Utf8);
  const [customer, setCustomer] = useState();
  const [firstname, setFirstName] = useState();
  const [lastname, setLastName] = useState();
  const [address1, setAddress1] = useState();
  const [address2, setAddress2] = useState();
  const [phone, setPhone] = useState();
  const [detailOrder, setDetailOrder] = useState();
  const [selectedValue, setSelectedValue] = useState("");
  const [active, setActive] = useState(false);
  const handleSelectChange = (event) => {
    setSelectedValue(event.target.value);
    console.log(event.target.value);
  };
  useEffect(() => {
    axios
      .post(
        "https://localhost:7295/api/Bill/getInfoOrder",
        {},
        {
          params: {
            Id: decryptedId,
          },
        }
      )
      .then((res) => {
        setDetailOrder(res.data);
      });
  }, [decryptedId]);
  useEffect(() => {
    axios
      .get("https://localhost:7295/api/Authentication", {
        params: {
          id: decryptedId,
        },
      })
      .then((res) => {
        setCustomer(res.data);
        setFirstName(res.data.firstName);
        setLastName(res.data.lastName);
        setPhone(res.data.phoneNumber);
      });
  }, [decryptedId]);
  return (
    <>
      <Container className="m-0 p-0" style={{ maxWidth: 1350 }}>
        <div className="row w-100 m-0">
          <div className="col-5 d-flex" style={{ backgroundColor: "#e9f5f3" }}>
            <div className="auth-card justify-content-center">
              <h2 className="mt-5 text-center">Tài khoản của tôi</h2>
              <h6 className="mt-3 mb-0">Tài khoản</h6>
              <p>{customer?.userName}</p>
              <h6 className="mb-0">Số điện thoại</h6>
              <p>{customer?.phoneNumber}</p>
              <h6 className=" mb-0">Ngày lập tài khoản</h6>
              <p>{customer?.createAccount}</p>
              <h6 className=" mb-0">Số đơn hàng</h6>
              <p>{detailOrder?.quantity}</p>
              <h6 className=" mb-0">Tổng số tiền đã mua tháng này</h6>
              <p>
                {detailOrder?.totalOrderofMonth.toLocaleString("vi-VN", {
                  style: "currency",
                  currency: "VND",
                })}
              </p>
              <h6 className=" mb-0">Tổng số tiền đã mua</h6>
              <p>
                {detailOrder?.totalOrder.toLocaleString("vi-VN", {
                  style: "currency",
                  currency: "VND",
                })}
              </p>
              <h6 className=" mb-0">Tổng số tiền được giảm giá</h6>
              <p>
                {detailOrder?.totalDiscount.toLocaleString("vi-VN", {
                  style: "currency",
                  currency: "VND",
                })}
              </p>
            </div>
          </div>
          <div className="col-7" style={{ backgroundColor: "#e9f5f3" }}>
            <div className="auth-card">
              <h2 className="text-center mb-2 ">Thông tin cá nhân</h2>
              <form className="d-flex flex-column gap-15 ">
                <label className="mb-0">Họ </label>
                <input
                  type="text"
                  value={firstname}
                  onChange={(e) => {
                    e.preventDefault();
                    setFirstName(e.target.value);
                  }}
                  disabled={!active}
                />
                <label className="mb-0">Tên</label>
                <input
                  type="text"
                  value={lastname}
                  onChange={(e) => {
                    e.preventDefault();
                    setLastName(e.target.value);
                  }}
                  disabled={!active}
                />
                <label className="mb-0">Địa chỉ 1</label>
                <input
                  type="text"
                  value={address1}
                  onChange={(e) => {
                    e.preventDefault();
                    setAddress1(e.target.value);
                  }}
                  disabled={!active}
                />
                <label className=" mb-0">Địa chỉ 2</label>
                <input
                  type="text"
                  value={address2}
                  onChange={(e) => {
                    e.preventDefault();
                    setAddress2(e.target.value);
                  }}
                  disabled={!active}
                />
                <label className=" mb-0">Giới tính</label>
                <select
                  value={selectedValue}
                  onChange={handleSelectChange}
                  disabled={!active}
                >
                  <option value="0">Nam</option>
                  <option value="1">Nữ</option>
                  <option value="2">Khác</option>
                </select>
                <label className=" mb-0">Số điện thoại</label>
                <input
                  type="number"
                  value={phone}
                  onChange={(e) => {
                    e.preventDefault();
                    setPhone(e.target.value);
                  }}
                  disabled={!active}
                />
                <div className="w-100 d-flex ">
                  <button
                    className="button update w-75"
                    onClick={(e) => {
                      e.preventDefault();
                      setActive(true);
                    }}
                  >
                    Sửa
                  </button>
                  <button
                    className="button save w-75"
                    onClick={(e) => {
                      e.preventDefault();
                      setActive(false);
                    }}
                  >
                    Lưu
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </Container>
    </>
  );
};
export default Profile;
