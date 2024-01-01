import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import BreadCrumb from "../components/BreadCrumb";
import { HiOutlineArrowLeft } from "react-icons/hi";
import Meta from "../components/Meta";
import Container from "../components/Container";
import axios from "axios";

const SingleBlog = () => {
  var id = localStorage.getItem("blog");
  const [data, setData] = useState([]);
  useEffect(() => {
    axios
      .get(`https://localhost:7295/api/Blog/getBlogByID?Id=${id}`)
      .then((res) => {
        setData(res.data);
      });
  }, [id]);
  const paragraphs = data?.content?.split("\\n");
  console.log(paragraphs);

  return (
    <>
      <Meta title={"Dynamic Blog Name"} />
      <BreadCrumb title="Dynamic Blog Name" />
      <Container class1="blog-wrapper home-wrapper-2 py-5">
        <div className="row">
          <div className="col-12">
            <div className="single-blog-card">
              <Link to="/blogs" className="d-flex align-items-center gap-10">
                <HiOutlineArrowLeft className="fs-4" /> Quay lại
              </Link>
              <h3 className="title">{data?.title}</h3>
              <br />
              <div className="d-flex justify-content-center">
                <img
                  src={data?.image}
                  className="img-fluid w-50  "
                  alt="blog"
                />
              </div>
              <br />
              <br />

              <div>
                {paragraphs?.map((paragraph, index) => (
                  <p key={index}>{paragraph}</p>
                ))}
              </div>
              <span className="d-flex justify-content-end">
                Chỉnh sửa lần cuối : {data?.lastChange}
              </span>
            </div>
          </div>
        </div>
      </Container>
    </>
  );
};

export default SingleBlog;
