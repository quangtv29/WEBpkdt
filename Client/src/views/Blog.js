import React, { useEffect, useState } from "react";
import Meta from "../components/Meta";
import BlogCard from "../components/BlogCard";
import Container from "../components/Container";
import axios from "axios";

const Blog = () => {
  const [data, setData] = useState([]);
  useEffect(() => {
    axios.get("https://localhost:7295/api/Blog/getBlog").then((res) => {
      setData(res.data);
    });
  }, []);
  return (
    <>
      <Meta title={"Blogs"} />

      <Container class1="blog-wrapper home-wrapper-2 py-5">
        <div>
          <div className="row">
            {data?.map((item) => (
              <div key={item?.id} className="col-6 mb-3">
                {data && <BlogCard item={item} />}
              </div>
            ))}
          </div>
        </div>
      </Container>
    </>
  );
};

export default Blog;
