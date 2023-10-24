import React, { useEffect } from "react";
import { Container } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const Profile = () => {
  const navigate = useNavigate();
  useEffect(() => {
    if (!localStorage.getItem("id")) {
      navigate("/login", { replace: true });
    }
  }, [navigate]);
  return (
    <>
      <Container className="login-wrapper ">
        <div className="row">
          <div className="col-5">
            <div className="auth-card">
              <h3 className="mt-5">Tài khoản của tôi</h3>
              <label className="mt-3 mb-0">Tài khoản</label>
              <p>HIhi</p>
              <label className=" mb-0">Ngày lập tài khoản</label>
              <p>HIhi</p>
              <label className=" mb-0">Số đơn hàng</label>
              <p>HIhi</p>
              <label className=" mb-0">Tổng số tiền đã mua</label>
              <p>HIhi</p>
              <label className=" mb-0">Tổng số tiền được giảm giá</label>
              <p>HIhi</p>
            </div>
          </div>
          <div className="col-7">
            <div className="auth-card">
              <h2 className="text-center mb-2 ">Thông tin cá nhân</h2>
              <form className="d-flex flex-column gap-15 ">
                <label className="mb-0">Họ </label>
                <input type="text" />
                <label className="mb-0">Tên</label>
                <input type="text" />
                <label className="mb-0">Địa chỉ 1</label>
                <input type="text" />
                <label className=" mb-0">Địa chỉ 2</label>
                <input type="text " />
                <label className=" mb-0">Giới tính</label>
                <select>
                  <option>Nam</option>
                  <option>Nữ</option>
                  <option>Khác</option>
                </select>
                <label className=" mb-0">Số điện thoại</label>
                <input type="text " />
                <button className="button update">Cập nhật</button>
              </form>
            </div>
          </div>
        </div>
      </Container>
    </>
  );
};
export default Profile;
