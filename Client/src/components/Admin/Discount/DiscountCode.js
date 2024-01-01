import React, { useEffect, useState } from "react";
import "./Discount.css";
import axios from "axios";
import { toast } from "react-toastify";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

const DiscountCodeForm = () => {
  const [code, setCode] = useState("");
  const [amount, setAmount] = useState(0);
  const [quantity, setQuantity] = useState(0);
  const [percentage, setPercentage] = useState(100);
  const [minAmount, setMinAmount] = useState(0);
  const [expiryDate, setExpiryDate] = useState(null);
  const [message, setMessage] = useState("");
  const [voucher, setVoucher] = useState([]);
  const handleDateChange = (date) => {
    setExpiryDate(date);
  };
  const handleFormSubmit = () => {
    if (
      !code ||
      amount === 0 ||
      quantity === 0 ||
      !expiryDate ||
      percentage < 1 ||
      percentage > 100
    ) {
      if (percentage < 1 || percentage > 100) {
        setMessage("Phần trăm giảm giá phải >= 1 và <= 100");
      } else {
        setMessage("Bạn cần nhập đầy đủ thông tin");
      }
    } else {
      axios
        .post("https://localhost:7295/api/Sale/createSale", {
          discountCode: code,
          money: amount,
          quantity: quantity,
          percent: percentage / 100,
          minBill: minAmount,
          endDate: expiryDate,
        })
        .then(() => {
          toast("Thêm mã giảm giá thành công ");
          setMessage("");
          setCode("");
          setAmount(0);
          setQuantity(0);
          setPercentage(100);
          setMinAmount(0);
          setExpiryDate("");
          axios.post("https://localhost:7295/api/Notification/createNoti", {
            content: `Vào kho Voucher để sở hữu các Voucher hấp dẫn. Số lượng có hạn - Nhanh tay bạn nhé.`,
            header: "Voucher hấp dẫn đang chờ bạn",
            customerID: "2bc37ad4-9601-4ede-a821-6a23d9990609",
          });
        })
        .catch(() => {
          toast("Thêm mã giảm giá thất bại");
        });
    }
  };
  const handleVoucherItemClick = (selectedVoucher) => {
    setCode(selectedVoucher?.discountCode || "");
    setAmount(selectedVoucher?.money || 0);
    setQuantity(selectedVoucher?.quantity || 0);
    setPercentage(selectedVoucher?.percent * 100 || 100);
    setMinAmount(selectedVoucher?.minBill || 0);
  };
  useEffect(() => {
    axios.get("https://localhost:7295/api/Sale/GetAllSale").then((res) => {
      setVoucher(res.data);
    });
  }, []);
  return (
    <div className="d-flex">
      <div className="discount-container w-100">
        <h1 className="mb-3">Tạo mã giảm giá</h1>
        {message && <p className="text-center text-danger">{message}</p>}
        <form className="discount-form">
          <div className="form-group">
            <label className="form-label">Mã giảm giá:</label>
            <input
              type="text"
              className="form-input"
              value={code}
              onChange={(e) => setCode(e.target.value)}
              placeholder="Nhập mã giảm giá"
            />
            <span style={{ color: "red" }}> *</span>
          </div>
          <div className="form-group">
            <label className="form-label">Số tiền giảm giá:</label>
            <input
              type="text"
              className="form-input"
              value={amount}
              onChange={(e) => setAmount(e.target.value)}
              placeholder="Nhập số tiền giảm giá"
            />
            <span style={{ color: "red" }}> *</span>
          </div>
          <div className="form-group">
            <label className="form-label">Số lượng sử dụng:</label>
            <input
              type="text"
              className="form-input"
              value={quantity}
              onChange={(e) => setQuantity(e.target.value)}
              placeholder="Nhập số lượng sử dụng"
            />
            <span style={{ color: "red" }}> *</span>
          </div>
          <div className="form-group">
            <label className="form-label">Phần trăm giảm giá:</label>
            <input
              type="number"
              className="form-input"
              value={percentage}
              min={1}
              max={100}
              onChange={(e) => setPercentage(e.target.value)}
              placeholder="Nhập phần trăm giảm giá"
            />
          </div>
          <div className="form-group">
            <label className="form-label">Hoá đơn tối thiểu:</label>
            <input
              type="text"
              className="form-input"
              value={minAmount}
              onChange={(e) => setMinAmount(e.target.value)}
              placeholder="Nhập hoá đơn tối thiểu"
            />
          </div>
          <div className="form-group">
            <label className="form-label">Ngày hết hạn:</label>
            <DatePicker
              selected={expiryDate}
              onChange={handleDateChange}
              dateFormat="dd/MM/yyyy"
              showYearDropdown
              scrollableYearDropdown
            />
            <span style={{ color: "red" }}> *</span>
          </div>
          <button
            onClick={() => handleFormSubmit()}
            type="button"
            className="form-button"
          >
            Tạo mã giảm giá
          </button>
        </form>
      </div>
      <div style={{ minHeight: 500 }}>
        <h2 className="w-100 text-center">Danh sách mã giảm giá</h2>
        <div className="voucher-container">
          {voucher.map((item, index) => (
            <div
              key={index}
              className="voucher-itemm"
              onClick={() => handleVoucherItemClick(item)}
            >
              <div className="voucher-detailss">
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
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default DiscountCodeForm;
