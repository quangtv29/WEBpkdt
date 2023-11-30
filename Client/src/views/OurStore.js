import React, { useState, useContext, useEffect } from "react";
import BreadCrumb from "../components/BreadCrumb";
import Meta from "../components/Meta";
import ReactStars from "react-rating-stars-component";
import ProductCard from "../components/ProductCard";
import Color from "../components/Color";
import Container from "../components/Container";
import { SearchContext } from "../SearchContext";
const OurStore = () => {
  const [grid, setGrid] = useState(4);
  const [condition, setCondition] = useState("Liên Quan");
  const handleConditionChange = (event) => {
    setCondition(event.target.value);
  };
  const { record } = useContext(SearchContext);
  const fix = record / 6;

  const [currentPage, setCurrentPage] = useState(1);
  const handlePageChange = (pageNumber) => {
    setCurrentPage(pageNumber);
  };
  return (
    <>
      <Meta title={"Our Store"} />
      <BreadCrumb title="Our Store" />
      <Container class1="store-wrapper home-wrapper-2 py-5">
        <div className="row">
          <div className="col-3">
            <div className="filter-card mb-3">
              <h3 className="filter-title">Danh mục sản phẩm</h3>
              <div>
                <ul className="list-unstyled ps-0">
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#oplung-collapse"
                      aria-expanded="true"
                    >
                      Ốp lưng {"\u00A0"}
                      <i className="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div className="collapse" id="oplung-collapse">
                      <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#kinh-collapse"
                      aria-expanded="true"
                    >
                      Kính cường lực {"\u00A0"}
                      <i className="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div className="collapse" id="kinh-collapse">
                      <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#cusac-collapse"
                      aria-expanded="true"
                    >
                      Củ sạc, bộ sạc {"\u00A0"}
                      <i className="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div className="collapse" id="cusac-collapse">
                      <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#capsac-collapse"
                      aria-expanded="true"
                    >
                      Cáp sạc {"\u00A0"}
                      <i className="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div className="collapse" id="capsac-collapse">
                      <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#tainghe-collapse"
                      aria-expanded="true"
                    >
                      Tai nghe {"\u00A0"}
                      <i className="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div className="collapse" id="tainghe-collapse">
                      <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#sac-collapse"
                      aria-expanded="true"
                    >
                      Sạc dự phòng {"\u00A0"}
                      <i className="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div className="collapse" id="sac-collapse">
                      <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#loa-collapse"
                      aria-expanded="true"
                    >
                      Loa Bluetooth {"\u00A0"}
                      <i className="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div className="collapse" id="loa-collapse">
                      <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#giado-collapse"
                      aria-expanded="true"
                    >
                      Giá đỡ điện thoại {"\u00A0"}
                      <i className="fa fa-angle-down" aria-hidden="true"></i>
                    </button>
                    <div className="collapse" id="giado-collapse">
                      <ul className="btn-toggle-nav list-unstyled fw-normal pb-1 small">
                        <li>Hi</li>
                        <li>Ba</li>
                        <li>Bon</li>
                      </ul>
                    </div>
                  </li>
                </ul>
              </div>
            </div>
            <div className="filter-card mb-3">
              <h3 className="filter-title">Lọc</h3>
              <div>
                <h5 className="sub-title">Sẵn có</h5>
                <div>
                  <div className="form-check">
                    <input className="form-check-input" type="checkbox" />
                    <label className="form-check-label" htmlFor="">
                      Còn hàng
                    </label>
                  </div>
                  <div className="form-check">
                    <input className="form-check-input" type="checkbox" />
                    <label className="form-check-label" htmlFor="">
                      Hết hàng
                    </label>
                  </div>
                </div>
                <h5 className="sub-title">Price</h5>
                <div className="d-flex align-items-center gap-10">
                  <div className="form-floating">
                    <input
                      type="email"
                      className="form-control"
                      id="floatingInput"
                      placeholder="From"
                    />
                    <label htmlFor="floatingInput">From</label>
                  </div>
                  <div className="form-floating">
                    <input
                      type="email"
                      className="form-control"
                      id="floatingInput1"
                      placeholder="To"
                    />
                    <label htmlFor="floatingInput1">To</label>
                  </div>
                </div>
                <h5 className="sub-title">Colors</h5>
                <div>
                  <Color />
                </div>
                <h5 className="sub-title">Size</h5>
                <div>
                  <div className="form-check">
                    <input
                      className="form-check-input"
                      type="checkbox"
                      value=""
                      id="color-1"
                    />
                    <label className="form-check-label" htmlFor="color-1">
                      S (2)
                    </label>
                  </div>
                  <div className="form-check">
                    <input
                      className="form-check-input"
                      type="checkbox"
                      value=""
                      id="color-2"
                    />
                    <label className="form-check-label" htmlFor="color-2">
                      M (2)
                    </label>
                  </div>
                </div>
              </div>
            </div>
            <div className="filter-card mb-3">
              <h3 className="filter-title">Product Tags</h3>
              <div>
                <div className="product-tags d-flex flex-wrap align-items-center gap-10">
                  <span className="badge bg-light text-secondary rounded-3 py-2 px-3">
                    Headphone
                  </span>
                  <span className="badge bg-light text-secondary rounded-3 py-2 px-3">
                    Laptop
                  </span>
                  <span className="badge bg-light text-secondary rounded-3 py-2 px-3">
                    Mobile
                  </span>
                  <span className="badge bg-light text-secondary rounded-3 py-2 px-3">
                    Wire
                  </span>
                </div>
              </div>
            </div>
            <div className="filter-card mb-3">
              <h3 className="filter-title">Random Product</h3>
              <div>
                <div className="random-products mb-3 d-flex">
                  <div className="w-50">
                    <img
                      src="../assets/images/watch.jpg"
                      className="img-fluid"
                      alt="watch"
                    />
                  </div>
                  <div className="w-50">
                    <h5>
                      Kids headphones bulk 10 pack multi colored for students
                    </h5>
                    <ReactStars
                      count={5}
                      size={24}
                      value={4}
                      edit={false}
                      activeColor="#ffd700"
                    />
                    <b>$ 300</b>
                  </div>
                </div>
                <div className="random-products d-flex">
                  <div className="w-50">
                    <img
                      src="../assets/images/watch.jpg"
                      className="img-fluid"
                      alt="watch"
                    />
                  </div>
                  <div className="w-50">
                    <h5>
                      Kids headphones bulk 10 pack multi colored for students
                    </h5>
                    <ReactStars
                      count={5}
                      size={24}
                      value={4}
                      edit={false}
                      activeColor="#ffd700"
                    />
                    <b>$ 300</b>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div className="col-9">
            <div className="filter-sort-grid mb-4">
              <div className="d-flex justify-content-between align-items-center">
                <div className="d-flex align-items-center gap-10">
                  <p className="mb-0 d-block" style={{ width: "165px" }}>
                    Sắp xếp theo:
                  </p>
                  <select
                    name=""
                    value={condition}
                    defaultValue={"Liên Quan"}
                    className="form-control form-select"
                    id=""
                    onChange={handleConditionChange}
                  >
                    <option value="Liên Quan">Liên Quan</option>
                    <option value="Bán Chạy">Bán Chạy</option>
                    <option value="Theo Thứ Tự, A-Z">Theo Thứ Tự, A-Z</option>
                    <option value="Theo Thứ Tự, Z-A">Theo Thứ Tự, Z-A</option>
                    <option value="Giá, Thấp đến Cao">Giá, Thấp đến Cao</option>
                    <option value="Giá, Cao đến Thấp">Giá, Cao đến Thấp</option>
                    {/* <option value="created-ascending">Ngày, old to new</option>
                    <option value="created-descending">Ngày, new to old</option> */}
                  </select>
                </div>
                <div className="d-flex align-items-center gap-10">
                  <p className="totalproducts mb-0 mr-4">
                    <b>{record} sản phẩm</b>
                  </p>
                </div>
              </div>
            </div>
            <div className="products-list pb-5">
              <div className="d-flex gap-10 flex-wrap">
                <ProductCard
                  grid={grid}
                  condition={condition}
                  currentPage={currentPage}
                />
              </div>
            </div>
            <div className="pagination d-flex justify-content-center">
              <div className="pagination-info">
                <span>
                  Page <b>{currentPage}</b> of <b>{Math.ceil(fix)}</b>
                </span>
              </div>
              <div className="pagination-buttons">
                <button
                  onClick={() => handlePageChange(currentPage - 1)}
                  disabled={currentPage === 1}
                  className="mr-3 ml-1"
                >
                  Previous
                </button>
                <button
                  onClick={() => handlePageChange(currentPage + 1)}
                  disabled={currentPage === Math.ceil(fix)}
                >
                  Next
                </button>
              </div>
            </div>
          </div>
        </div>
      </Container>
    </>
  );
};

export default OurStore;
