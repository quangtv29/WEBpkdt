import React, { useState, useContext, useEffect } from "react";
import BreadCrumb from "../components/BreadCrumb";
import Meta from "../components/Meta";
import ProductCard from "../components/ProductCard";
import Color from "../components/Color";
import Container from "../components/Container";
import _ from "lodash";
import { SearchContext } from "../SearchContext";
import axios from "axios";
import "./OurStore.css";

const OurStore = () => {
  const [grid, setGrid] = useState(4);
  const [isInStockChecked, setIsInStockChecked] = useState(false);
  const [isOutOfStockChecked, setIsOutOfStockChecked] = useState(false);

  const handleInStockChange = () => {
    if (isInStockChecked) {
      setIsInStockChecked(false);
    } else {
      setIsInStockChecked(true);
      setIsOutOfStockChecked(false);
    }
  };

  const handleOutOfStockChange = () => {
    if (isOutOfStockChecked) {
      setIsOutOfStockChecked(false);
    } else {
      setIsOutOfStockChecked(true);
      setIsInStockChecked(false);
    }
  };
  const [condition, setCondition] = useState("Liên Quan");
  const handleConditionChange = (event) => {
    setCondition(event.target.value);
  };
  const [from, setFrom] = useState(0);
  const [to, setTo] = useState(0);
  const { record, search, setRecord, status, setStatus } =
    useContext(SearchContext);
  const fix = record / 6;
  const [products, setProducts] = useState([]);

  const [currentPage, setCurrentPage] = useState(1);
  const handlePageChange = (pageNumber) => {
    setCurrentPage(pageNumber);
  };

  const fetchProductByType = async (name) => {
    let url = "https://localhost:7295/api/Product/getProductByProductType";
    const pageNumber = currentPage;
    const pageSize = 6;
    const response = await axios.post(
      url,
      { pageNumber, pageSize },
      {
        params: {
          productType: name,
        },
      }
    );
    setRecord(response.data.length);
    setProducts(response.data);
  };

  const fetchProducts = async () => {
    let url = "https://localhost:7295/api/Product/searchByName";
    const pageNumber = currentPage;
    const pageSize = 6;
    const response = await axios.post(
      url,
      { pageNumber, pageSize },
      {
        params: {
          name: search,
        },
      }
    );

    let data = response.data.item1;
    setRecord(response.data.item2);

    switch (condition) {
      case "Bán Chạy":
        data = _.sortBy(data, "sold").reverse();
        break;
      case "Giá, Thấp đến Cao":
        data = _.sortBy(data, "price");
        break;
      case "Giá, Cao đến Thấp":
        data = _.sortBy(data, "price").reverse();
        break;
      case "Theo Thứ Tự, A-Z":
        data = _.sortBy(data, "name");
        break;
      case "Theo Thứ Tự, Z-A":
        data = _.sortBy(data, "name").reverse();
        break;
      // Thêm các case cho các trường hợp khác
      default:
        // Xử lý cho trường hợp mặc định nếu không có case nào khớp với giá trị của biến condition
        break;
    }
    setProducts(data);
  };
  const handleFilter = async (event) => {
    event.preventDefault();

    const response = await axios.post(
      "https://localhost:7295/api/Product/getByPrice",
      {
        pageNumber: currentPage,
        pageSize: 6,
      },
      {
        params: {
          vip: from,
          to: to,
          inStock: isInStockChecked,
          outOfStock: isOutOfStockChecked,
        },
      }
    );
    setProducts(response.data);
    let count = 0;
    response.data.map(() => {
      count++;
    });

    setRecord(count);
  };
  useEffect(() => {
    fetchProducts();
    setStatus(false);
    // fetchTopSeller();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [status, currentPage]);
  useEffect(() => {
    let data = [...products];
    switch (condition) {
      case "Bán Chạy":
        data = _.sortBy(data, "sold").reverse();
        break;
      case "Giá, Thấp đến Cao":
        data = _.sortBy(data, "price");
        break;
      case "Giá, Cao đến Thấp":
        data = _.sortBy(data, "price").reverse();
        break;
      case "Theo Thứ Tự, A-Z":
        data = _.sortBy(data, "name").reverse();
        break;
      case "Theo Thứ Tự, Z-A":
        data = _.sortBy(data, "name");
        break;
      // Thêm các case cho các trường hợp khác
      default:
        // Xử lý cho trường hợp mặc định nếu không có case nào khớp với giá trị của biến condition
        break;
    }
    setProducts(data);
  }, [condition]);
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
                      onClick={() => fetchProductByType("Ốp lưng")}
                      className="btn  align-items-center  "
                    >
                      Ốp lưng {"\u00A0"}
                    </button>
                  </li>
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#kinh-collapse"
                      aria-expanded="true"
                    >
                      Kính cường lực {"\u00A0"}
                    </button>
                  </li>
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#cusac-collapse"
                      aria-expanded="true"
                    >
                      Củ sạc, bộ sạc {"\u00A0"}
                    </button>
                  </li>
                  <li className="mb-1">
                    <button
                      onClick={() => fetchProductByType("Cáp sạc")}
                      className="btn  align-items-center  "
                    >
                      Cáp sạc {"\u00A0"}
                    </button>
                  </li>
                  <li className="mb-1">
                    <button
                      onClick={() => fetchProductByType("Tai nghe")}
                      className="btn  align-items-center  "
                    >
                      Tai nghe {"\u00A0"}
                    </button>
                  </li>
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#sac-collapse"
                      aria-expanded="true"
                    >
                      Sạc dự phòng {"\u00A0"}
                    </button>
                  </li>
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#loa-collapse"
                      aria-expanded="true"
                    >
                      Loa Bluetooth {"\u00A0"}
                    </button>
                  </li>
                  <li className="mb-1">
                    <button
                      className="btn btn-toggle align-items-center rounded"
                      data-bs-toggle="collapse"
                      data-bs-target="#giado-collapse"
                      aria-expanded="true"
                    >
                      Giá đỡ điện thoại {"\u00A0"}
                    </button>
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
                    <input
                      className="form-check-input"
                      type="checkbox"
                      checked={isInStockChecked}
                      onChange={handleInStockChange}
                    />
                    <label className="form-check-label" htmlFor="">
                      Còn hàng
                    </label>
                  </div>
                  <div className="form-check">
                    <input
                      className="form-check-input"
                      type="checkbox"
                      checked={isOutOfStockChecked}
                      onChange={handleOutOfStockChange}
                    />
                    <label className="form-check-label" htmlFor="">
                      Hết hàng
                    </label>
                  </div>
                </div>
                <h5 className="sub-title">Giá</h5>
                <div className="d-flex align-items-center gap-10">
                  <div className="form-floating">
                    <input
                      type="number"
                      className="form-control"
                      id="floatingInput"
                      placeholder="From"
                      onChange={(event) => {
                        event.preventDefault();
                        setFrom(event.target.value);
                      }}
                    />
                    <label htmlFor="floatingInput">From</label>
                  </div>
                  <div className="form-floating">
                    <input
                      type="number"
                      className="form-control"
                      id="floatingInput1"
                      placeholder="To"
                      onChange={(event) => {
                        event.preventDefault();
                        setTo(event.target.value);
                      }}
                    />
                    <label htmlFor="floatingInput1">To</label>
                  </div>
                </div>
                <div className="d-flex w-100 justify-content-center">
                  <button
                    className="button mt-2"
                    onClick={(e) => handleFilter(e)}
                  >
                    Lọc
                  </button>
                </div>
                <h5 className="sub-title">Colors</h5>
                <div>
                  <Color />
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
                  product={products}
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
