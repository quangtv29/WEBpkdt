import React, { useState, useEffect } from "react";
import axios from "axios";
import "./Product.scss";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import CreateProduct from "./CreateProduct";
import CreateProduct1 from "./CreateProduct1";
import _ from "lodash";

const ListProduct = () => {
  const [selectedProduct, setSelectedProduct] = useState(null);
  const [productType, setProductType] = useState("");
  const [currentPage, setCurrentPage] = useState(1);
  const [maloaisp, setMaLoaiSP] = useState("");
  const [status, setStatus] = useState(false);
  const [number, setNumber] = useState(0);
  const [status1, setStatus1] = useState(false);
  const [products, setProducts] = useState([]);
  const pageSize = 5;
  const [condition, setCondition] = useState("Liên Quan");
  const [record, setRecord] = useState("");
  const handleConditionChange = (event) => {
    setCondition(event.target.value);
  };

  useEffect(() => {
    axios
      .get("https://localhost:7295/api/ProductType/getAll")
      .then((res) => {
        setProductType(res.data.data);
        setMaLoaiSP(res.data.data[0].id);
      })
      .catch(() => {});
  }, []);
  const [totalPage, setTotalPage] = useState(0);
  const fetchSanPham = async (page) => {
    try {
      const response = await axios.post(
        "https://localhost:7295/api/Product/getAllProduct",
        {
          pageNumber: page,
          pageSize,
        },
        {
          params: {
            a: number,
          },
        }
      );
      setProducts(response.data.productDTO);
      setTotalPage(Math.ceil(response.data.item2 / 5));
      setRecord(response.data.item2);
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    fetchSanPham(currentPage);
  }, [currentPage]);

  const handleSelectProduct = (product) => {
    setSelectedProduct(product);
  };

  const handleDeleteProduct = async (productId) => {
    try {
      const response = await axios.delete(`/api/sanpham/${productId}`);

      toast.success("Xóa sản phẩm thành công");
      window.location.reload();
    } catch (error) {
      toast.error("Xóa sản phẩm thất bại");
    }
  };

  const handlePageChange = (page, a) => {
    setCurrentPage(page);
    fetchSanPham(page);
  };
  useEffect(() => {
    let data = [...products];
    switch (condition) {
      case "Bán Chạy":
        setNumber(1);
        fetchSanPham(currentPage);
        break;
      case "Giá, Thấp đến Cao":
        data = _.sortBy(data, "price");
        break;
      case "Giá, Cao đến Thấp":
        setNumber(2);
        fetchSanPham(currentPage);
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
    <div className="contai">
      <div className="row">
        <div className="d-flex justify-content-between align-items-center">
          <div className="d-flex align-items-center gap-10">
            <p className="mb-0 d-block" style={{ width: "165px" }}>
              Sắp xếp theo:
            </p>
            <select
              name=""
              value={condition}
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
        <table className="table table-striped  ">
          <thead>
            <tr>
              <th>Tên SP</th>
              <th>Số lượng</th>
              <th>Đã bán</th>
              <th>Giá nhập</th>
              <th>Giá bán</th>
              <th>Loại sản phẩm</th>
              <th>NSX</th>
              <th>Mô tả</th>
              <th>Hình ảnh</th>
              <th colSpan="2">Thao tác</th>
            </tr>
          </thead>
          <tbody>
            {products?.map((item) => (
              <tr key={item.id} onClick={() => handleSelectProduct(item)}>
                <td style={{ wordWrap: "break-word", whiteSpace: "pre-wrap" }}>
                  {item?.name}
                </td>
                <td>{item?.quantity}</td>
                <td style={{ wordWrap: "break-word", whiteSpace: "pre-wrap" }}>
                  {item?.sold}
                </td>
                <td>
                  {item?.importPrice?.toLocaleString("vi-VN", {
                    style: "currency",
                    currency: "VND",
                  })}
                </td>
                <td>
                  {item?.price?.toLocaleString("vi-VN", {
                    style: "currency",
                    currency: "VND",
                  })}
                </td>
                <td>{item?.productTypeName}</td>
                <td>{item?.producer}</td>
                <td style={{ wordWrap: "break-word", whiteSpace: "pre-wrap" }}>
                  {item?.describe}
                </td>
                <td>
                  <img
                    src={item?.image}
                    alt={item?.name}
                    className="fixImage"
                  />
                </td>
                <td>
                  <i
                    className="fad fa-trash-alt"
                    onClick={() => handleDeleteProduct(item.MaSP)}
                  ></i>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            marginTop: "20px",
          }}
        >
          <div style={{ marginRight: "20px" }}>
            Trang <b>{currentPage}</b> / <b>{totalPage}</b>
          </div>
          <div style={{ display: "flex", alignItems: "center" }}>
            <button
              onClick={() => handlePageChange(currentPage - 1)}
              disabled={currentPage === 1}
              style={{
                padding: "8px 12px",
                margin: "0 5px",
                border: "1px solid #ccc",
                borderRadius: "4px",
                cursor: "pointer",
                backgroundColor: "#fff",
                color: "#333",
                transition: "background-color 0.3s",
              }}
            >
              Trước
            </button>

            {Array.from({ length: totalPage }, (_, index) => (
              <button
                key={index + 1}
                onClick={() => setCurrentPage(index + 1)}
                style={{
                  padding: "8px 12px",
                  margin: "0 5px",
                  border: "1px solid #ccc",
                  borderRadius: "4px",
                  cursor: "pointer",
                  backgroundColor: currentPage === index + 1 ? "#eee" : "#fff",
                  color: "#333",
                  transition: "background-color 0.3s",
                }}
              >
                {index + 1}
              </button>
            ))}

            <button
              onClick={() => handlePageChange(currentPage + 1)}
              disabled={currentPage === totalPage}
              style={{
                padding: "8px 12px",
                margin: "0 5px",
                border: "1px solid #ccc",
                borderRadius: "4px",
                cursor: "pointer",
                backgroundColor: "#fff",
                color: "#333",
                transition: "background-color 0.3s",
              }}
            >
              Sau
            </button>
          </div>
        </div>
        <div className="row">
          <div className="col-6 text-center">
            <button
              className="text-center"
              onClick={(e) => {
                e.preventDefault();
                setStatus1(!status1);
              }}
              style={{ padding: 3 }}
            >
              Sửa sản phẩm
            </button>
            {status1 && (
              <CreateProduct
                product={selectedProduct}
                productType={productType}
                maloaisp={maloaisp}
              />
            )}
          </div>
          <div className="col-6 text-center">
            <button
              className="text-center"
              onClick={(e) => {
                e.preventDefault();
                setStatus(!status);
              }}
              style={{ padding: 3 }}
            >
              Thêm sản phẩm
            </button>
            {status && (
              <CreateProduct1 productType={productType} maloaisp={maloaisp} />
            )}
          </div>
        </div>
      </div>
    </div>
  );
};

export default ListProduct;
