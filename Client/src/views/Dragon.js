import React, { useState } from "react";
import axios from "axios";

const Dragon = () => {
  const [phone, setPhone] = useState("");

  const apiUrl = "https://dragongem.biasaigon.vn/sbar/api/get_otp";

  const getOtp = async () => {
    try {
      const response = await axios.post(apiUrl, {
        full_name: "meo",
        phone_number: phone,
        email: "meo@gmail.com",
        location: "Bình Định",
      });
      console.log(response);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
      <label>Số điện thoại</label>
      <input
        type="phone"
        onChange={(e) => {
          setPhone(e.target.value);
        }}
      />
      <button onClick={() => getOtp()}>Lấy OTP</button>
    </>
  );
};

export default Dragon;
