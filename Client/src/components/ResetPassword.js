import React, { useState, useContext } from "react";
import "./resetpassword.css";
import axios from "axios";
import { MyContext } from "../encryptionKey";
import CryptoJS from "crypto-js";

const ResetPassword = () => {
  const [currentPassword, setCurrentPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const { encryptionKey } = useContext(MyContext);
  const decryptedId = CryptoJS.AES.decrypt(
    localStorage.getItem("id"),
    encryptionKey
  ).toString(CryptoJS.enc.Utf8);
  const handleSubmit = (e) => {
    e.preventDefault();

    if (
      currentPassword === "" ||
      newPassword === "" ||
      confirmPassword === ""
    ) {
      setErrorMessage("Vui lòng điền đầy đủ thông tin.");
    } else if (newPassword !== confirmPassword) {
      setErrorMessage("Mật khẩu mới và xác nhận mật khẩu không khớp.");
    } else {
      if (newPassword.length < 8) {
        setErrorMessage("Mật khẩu phải tối thiểu có 8 ký tự.");
      } else {
        axios
          .post("https://localhost:7295/api/Authentication/resetPassword", {
            id: decryptedId,
            password: currentPassword,
            newPassword: newPassword,
          })
          .then(() => {
            setErrorMessage("Mật khẩu đã được thay đổi thành công.");
            setCurrentPassword("");
            setNewPassword("");
            setConfirmPassword("");
          })
          .catch(() => {
            setErrorMessage("Mật khẩu cũ không đúng.");
            setCurrentPassword("");
            setNewPassword("");
            setConfirmPassword("");
          });
      }
    }
  };

  return (
    <form className="change-password-form" onSubmit={handleSubmit}>
      <h2>Đổi mật khẩu</h2>
      {errorMessage && <p className="error-message">{errorMessage}</p>}
      <div>
        <label htmlFor="currentPassword">Mật khẩu hiện tại:</label>
        <input
          type="password"
          id="currentPassword"
          value={currentPassword}
          onChange={(e) => setCurrentPassword(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="newPassword">Mật khẩu mới:</label>
        <input
          type="password"
          id="newPassword"
          value={newPassword}
          onChange={(e) => setNewPassword(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="confirmPassword">Xác nhận mật khẩu mới:</label>
        <input
          type="password"
          id="confirmPassword"
          value={confirmPassword}
          onChange={(e) => setConfirmPassword(e.target.value)}
        />
      </div>
      <button className="mt-4" type="submit">
        Đổi mật khẩu
      </button>
    </form>
  );
};

export default ResetPassword;
