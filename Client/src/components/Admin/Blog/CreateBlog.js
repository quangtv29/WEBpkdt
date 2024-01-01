// BlogForm.jsx
import React, { useState } from "react";
import axios from "axios";
import "./BlogForm.css";

const BlogForm = () => {
  const [title, setTitle] = useState("");
  const [image, setImage] = useState(null);
  const [content, setContent] = useState("");

  const handleCreateBlog = async () => {
    try {
      if (!title || !content) {
        alert("Bạn cần điền đầy đủ thông tin");
        return;
      }
      const formData = new FormData();
      formData.append("title", title);
      formData.append("content", content);
      if (image) {
        formData.append("image", image);
      }

      const response = await axios
        .post("https://localhost:7295/api/Blog/CreateBlog", formData, {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        })
        .then(() => {
          alert("Thêm bài viết thành công");
        });
    } catch (error) {
      alert("Lỗi");
    }
  };

  const handleImageChange = (e) => {
    setImage(e.target.files[0]);
  };

  const handleContentChange = (e) => {
    const rawContent = e.target.value;
    const contentWithNewLines = rawContent.replace(/\n/g, "\\n");
    setContent(contentWithNewLines);
  };

  return (
    <div className="blog-form-container">
      <h2 className="text-center mb-5">Tạo bài viết mới</h2>
      <label className="blog-label">Tiêu đề:</label>
      <input
        type="text"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        className="blog-input"
      />

      <label className="blog-label">Hình ảnh:</label>
      <input type="file" onChange={handleImageChange} className="blog-input" />

      <label className="blog-label">Nội dung:</label>
      <textarea
        value={content}
        onChange={handleContentChange}
        className="blog-textarea"
        style={{ height: 500 }}
      />
      <div style={{ display: "flex", justifyContent: "center" }}>
        <button onClick={handleCreateBlog} className="blog-button">
          Tạo bài viết
        </button>
      </div>
    </div>
  );
};

export default BlogForm;
