import React, { useState, useContext } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faStar } from "@fortawesome/free-solid-svg-icons";
import "./ProductRating.scss";
import axios from "axios";
import { MyContext } from "../encryptionKey";
import CryptoJS from "crypto-js";

const ProductRating = ({ initialRating }) => {
  const [isChecked, setIsChecked] = useState(false);
  const { encryptionKey } = useContext(MyContext);

  const decryptedId = CryptoJS.AES.decrypt(
    localStorage.getItem("id"),
    encryptionKey
  ).toString(CryptoJS.enc.Utf8);

  const handleToggle = () => {
    setIsChecked(!isChecked);
    console.log(!isChecked);
  };

  const [avatar, setAvatar] = useState(null);
  const handleFileChange = (event) => {
    const file = event.target.files[0];
    setAvatar(file);
    if (file) {
      const reader = new FileReader();
      reader.readAsDataURL(file);
    }
  };

  const [rating, setRating] = useState(initialRating || 5);
  const [comment, setComment] = useState("");
  const handleFeedback = (e) => {
    e.preventDefault();
    const config = {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    };
    var formData = new FormData();

    formData.append("file", avatar);
    formData.append("Star", rating);
    formData.append("Comment", comment);
    formData.append("ProductId", localStorage.getItem("productId"));
    formData.append("isShow", isChecked);
    formData.append("orderDetailId", localStorage.getItem("orderId"));
    formData.append("UserName", decryptedId);

    axios
      .post(
        "https://localhost:7295/api/Feedback/CreateFeedback",
        formData,
        config
      )
      .then(() => {
        alert("Cảm ơn bạn đã đánh giá sản phẩm");
        window.location.href = "/product";
      })
      .catch((error) => {
        alert("Bạn đã đánh giá sản phẩm này rồi");
      });
  };

  const handleStarClick = (selectedRating) => {
    setRating(selectedRating);
  };

  const handleCommentChange = (event) => {
    const newComment = event.target.value;
    setComment(newComment);
  };

  return (
    <div className="product-rating-container">
      <h2>Đánh giá sản phẩm</h2>
      <div className="rating-stars">
        {[1, 2, 3, 4, 5].map((star) => (
          <FontAwesomeIcon
            key={star}
            icon={faStar}
            onClick={() => handleStarClick(star)}
            className={star <= rating ? "star selected" : "star"}
          />
        ))}
      </div>
      <p className="rating-text">Đánh giá của bạn: {rating} sao</p>
      <textarea
        className="comment-input"
        rows="4"
        value={comment}
        onChange={handleCommentChange}
        placeholder="Nhập nhận xét của bạn..."
      />
      <input
        type="file"
        name="file"
        onChange={handleFileChange}
        id="mypicture"
        className="mb-4"
      />
      <div>
        Ẩn tên trên đánh giá này
        <label className="switch ml-1">
          <input type="checkbox" checked={isChecked} onChange={handleToggle} />
          <span className="slider"></span>
        </label>
      </div>
      <button className="submit-button" onClick={(e) => handleFeedback(e)}>
        Gửi
      </button>
    </div>
  );
};

export default ProductRating;
