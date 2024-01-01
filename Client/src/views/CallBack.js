// src/components/CallbackComponent.js
import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import axios from "axios";
import { HiOutlineArrowLeft } from "react-icons/hi";
import { Link } from "react-router-dom";

const CallbackComponent = () => {
  const location = useLocation();
  const [result, setResult] = useState("");

  useEffect(() => {
    // Xử lý thông tin kết quả thanh toán
    const queryParams = new URLSearchParams(location.search);
    setResult(queryParams.get("vnp_ResponseCode"));
  }, [location.search]);

  useEffect(() => {
    if (result && result === "00") {
      axios.post(
        "https://localhost:7295/api/Bill/updatePayDone",
        {},
        {
          params: {
            id: localStorage.getItem("billid1"),
          },
        }
      );
    }
  }, [location.search, result]);
  useEffect(() => {
    if (result && result === "00") {
      axios
        .post(
          "https://localhost:7295/api/orderdetail/updateOrderDetail",
          {},
          {
            params: {
              Id: localStorage.getItem("billid1"),
              isCart: "delivering",
            },
          }
        )
        .then(() => {
          console.log("meo");
        });
    }
  }, [result]);

  const successStyle = {
    color: "green",
    fontWeight: "bold",
  };

  const failureStyle = {
    color: "red",
    fontWeight: "bold",
  };

  return (
    <div style={{ minHeight: 500 }}>
      <h1 className="text-center">Kết quả thanh toán</h1>
      {result === "00" ? (
        <div style={successStyle}>
          <p className="text-center">Thanh toán thành công</p>
        </div>
      ) : (
        <div className="text-center" style={failureStyle}>
          Thanh toán thất bại
        </div>
      )}
      {/* Hiển thị thông tin kết quả thanh toán nếu cần */}
      <Link to="/product" className="d-flex align-items-center gap-10">
        <HiOutlineArrowLeft className="fs-4" /> Tiếp tục mua sắm
      </Link>
    </div>
  );
};

export default CallbackComponent;
