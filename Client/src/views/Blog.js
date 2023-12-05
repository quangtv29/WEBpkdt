import React from "react";
import BreadCrumb from "../components/BreadCrumb";
import Meta from "../components/Meta";
import BlogCard from "../components/BlogCard";
import Container from "../components/Container";

const Blog = () => {
  return (
    <>
      <Meta title={"Blogs"} />
      <BreadCrumb title="Blogs" />
      <Container class1="blog-wrapper home-wrapper-2 py-5">
        <div className="row">
          <div className="col-3">
            <div className="filter-card mb-3">
              <h3 className="filter-title">Danh mục sản phẩm</h3>
              <div>
                <ul className="list-unstyled ps-0">
                  <li class="mb-1">
                    <button
                      class="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#oplung-collapse"
                      aria-expanded="true"
                    >
                      Ốp lưng <nbsp />
                      <i class="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div class="collapse" id="oplung-collapse">
                      <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li class="mb-1">
                    <button
                      class="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#kinh-collapse"
                      aria-expanded="true"
                    >
                      Kính cường lực <nbsp />
                      <i class="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div class="collapse" id="kinh-collapse">
                      <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li class="mb-1">
                    <button
                      class="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#cusac-collapse"
                      aria-expanded="true"
                    >
                      Củ sạc, bộ sạc <nbsp />
                      <i class="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div class="collapse" id="cusac-collapse">
                      <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li class="mb-1">
                    <button
                      class="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#capsac-collapse"
                      aria-expanded="true"
                    >
                      Cáp sạc <nbsp />
                      <i class="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div class="collapse" id="capsac-collapse">
                      <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li class="mb-1">
                    <button
                      class="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#tainghe-collapse"
                      aria-expanded="true"
                    >
                      Tai nghe <nbsp />
                      <i class="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div class="collapse" id="tainghe-collapse">
                      <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li class="mb-1">
                    <button
                      class="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#sac-collapse"
                      aria-expanded="true"
                    >
                      Sạc dự phòng <nbsp />
                      <i class="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div class="collapse" id="sac-collapse">
                      <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li class="mb-1">
                    <button
                      class="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#loa-collapse"
                      aria-expanded="true"
                    >
                      Loa Bluetooth <nbsp />
                      <i class="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div class="collapse" id="loa-collapse">
                      <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li class="mb-1">
                    <button
                      class="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#giado-collapse"
                      aria-expanded="true"
                    >
                      Giá đỡ điện thoại <nbsp />
                      <i class="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div class="collapse" id="giado-collapse">
                      <ul class="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                </ul>
              </div>
            </div>
          </div>
          <div className="col-9">
            <div className="row">
              <div className="col-6 mb-3">
                <BlogCard />
              </div>
              <div className="col-6 mb-3">
                <BlogCard />
              </div>
              <div className="col-6 mb-3">
                <BlogCard />
              </div>
              <div className="col-6 mb-3">
                <BlogCard />
              </div>
            </div>
          </div>
        </div>
      </Container>
    </>
  );
};

export default Blog;
