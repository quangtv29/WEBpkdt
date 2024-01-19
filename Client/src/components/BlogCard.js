import React from "react";
import { Link } from "react-router-dom";
const BlogCard = (props) => {
  return (
    <div className="blog-card">
      <div className="card-image">
        <img
          src={props?.item?.image}
          style={{
            maxHeight: 340,
            height: 340,
          }}
          className="img-fluid w-100"
          alt="blog"
        />
      </div>
      <div className="blog-content">
        <p className="date">{props?.item?.formatDate}</p>
        <h5 className="title" style={{ height: 60 }}>
          {props?.item?.title}
        </h5>
        <p className="desc" style={{ maxHeight: 115, overflow: "hidden" }}>
          {props?.item?.content}
        </p>

        <Link
          to="/blog/:id"
          className="button"
          onClick={(e) => {
            localStorage.setItem("blog", props?.item?.id);
          }}
        >
          Đọc thêm
        </Link>
      </div>
    </div>
  );
};

export default BlogCard;
