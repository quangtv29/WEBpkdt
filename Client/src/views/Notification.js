import React, { useState, useContext } from "react";
import "./Notification.css";
import { useEffect } from "react";
import axios from "axios";
import { MyContext } from "../encryptionKey";
import CryptoJS from "crypto-js";
import { Link } from "react-router-dom";
const NotificationComponent3 = () => {
  const { encryptionKey } = useContext(MyContext);
  const decryptedId = CryptoJS.AES.decrypt(
    localStorage.getItem("id"),
    encryptionKey
  ).toString(CryptoJS.enc.Utf8);
  const [notifications, setNotifications] = useState([]);
  useEffect(() => {
    axios
      .post(
        "https://localhost:7295/api/Notification/getNotiByCustomerId",
        {
          pageNumber: 100,
          pageSize: 5,
        },
        {
          params: {
            customerId: decryptedId,
          },
        }
      )
      .then((res) => {
        setNotifications(res.data);
      });
  }, [decryptedId]);
  const handleUpdate = (id) => {
    axios.post(
      "https://localhost:7295/api/Notification/updateNoti",
      {},
      {
        params: {
          id: id,
        },
      }
    );
  };
  return (
    <div className="notification-container3" style={{ padding: 0 }}>
      <h3 className="notification-label3 text-center">Thông báo</h3>
      <div className="notification-content3">
        {notifications &&
          notifications?.map((notification, index) => (
            <Link
              key={notification?.id}
              className="meo"
              to={
                notification?.header.includes("Voucher")
                  ? "/voucher"
                  : "/to-pay/to-deliveringg"
              }
              style={{
                backgroundColor: notification?.watched === 0 && "#fff",
              }}
              onClick={() => handleUpdate(notification?.id)}
            >
              <div key={index} className="notification-item3">
                {" "}
                <h6 style={{ color: "rgb(0, 123, 255)" }}>
                  {notification?.header}
                </h6>
                <p style={{ color: "#333" }}>{notification?.content}</p>
                <p style={{ fontSize: 13, color: "#333" }}>
                  {notification?.formatDate}
                </p>
              </div>
            </Link>
          ))}
      </div>
    </div>
  );
};

export default NotificationComponent3;
