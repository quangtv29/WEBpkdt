import React, { useState } from "react";
import StarRatings from "react-star-ratings";

const FeedbackForm = ({ onSubmit }) => {
  const [rating, setRating] = useState(0);
  const [comment, setComment] = useState("");
  const [username, setUsername] = useState("");
  const [productId, setProductId] = useState("");

  const handleRatingChange = (newRating) => {
    setRating(newRating);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Kiểm tra các trường bắt buộc trước khi gửi phản hồi
    if (
      rating === 0 ||
      comment.trim() === "" ||
      username.trim() === "" ||
      productId.trim() === ""
    ) {
      alert("Vui lòng điền đầy đủ thông tin.");
      return;
    }
    // Gửi phản hồi đến phần cha thông qua callback onSubmit
    onSubmit({ rating, comment, username, productId });
    // Reset các trường sau khi gửi
    setRating(0);
    setComment("");
    setUsername("");
    setProductId("");
  };

  return (
    <div>
      <h3>Đánh giá sản phẩm</h3>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Số sao:</label>
          <StarRatings
            rating={rating}
            starRatedColor="#ffd700"
            starEmptyColor="#e4e5e9"
            changeRating={handleRatingChange}
            numberOfStars={5}
            name="rating"
          />
        </div>
        <div>
          <label>Comment:</label>
          <textarea
            value={comment}
            onChange={(e) => setComment(e.target.value)}
          />
        </div>
        <div>
          <label>Tên người dùng:</label>
          <input
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div>
          <label>ID sản phẩm:</label>
          <input
            type="text"
            value={productId}
            onChange={(e) => setProductId(e.target.value)}
          />
        </div>
        <div>
          <button type="submit">Gửi đánh giá</button>
        </div>
      </form>
    </div>
  );
};

// Sử dụng component
const FeedbackPage = () => {
  const handleFeedbackSubmit = (feedbackData) => {
    // Xử lý phản hồi, có thể gửi đến server hoặc thực hiện các bước khác tùy ý
    console.log("Đánh giá đã được gửi:", feedbackData);
  };

  return (
    <div>
      <h1>Trang phản hồi</h1>
      <FeedbackForm onSubmit={handleFeedbackSubmit} />
    </div>
  );
};

export default FeedbackPage;
