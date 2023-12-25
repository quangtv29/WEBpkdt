import React, { useState, useEffect } from "react";
import axios from "axios";
import "./Product.scss";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import CreateProduct from "./CreateProduct";
import CreateProduct1 from "./CreateProduct1";

const ListProduct = () => {
  const [selectedProduct, setSelectedProduct] = useState(null);
  const [productType, setProductType] = useState("");
  const [currentPage, setCurrentPage] = useState(1);
  const [maloaisp, setMaLoaiSP] = useState("");
  const [status, setStatus] = useState(false);
  const [status1, setStatus1] = useState(false);
  const [data, setData] = useState([]);
  const pageSize = 5;

  useEffect(() => {
    axios
      .get("https://localhost:7295/api/ProductType/getAll")
      .then((res) => {
        setProductType(res.data.data);
        setMaLoaiSP(res.data.data[0].id);
      })
      .catch(() => {});
  }, []);

  const fetchSanPham = async (page) => {
    try {
      const response = await axios.post(
        "https://localhost:7295/api/Product/getAllProduct",
        {
          pageNumber: page,
          pageSize,
        }
      );
      setData(response.data);
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
      console.log(response.data);
      toast.success("Xóa sản phẩm thành công");
      window.location.reload();
    } catch (error) {
      console.error(error);
      toast.error("Xóa sản phẩm thất bại");
    }
  };

  const handlePageChange = (page) => {
    setCurrentPage(page);
    fetchSanPham(page);
  };

  return (
    <div className="contai">
      <div className="row">
        <table className="table">
          <thead>
            <tr>
              <th>Mã SP</th>
              <th>Tên SP</th>
              <th>Số lượng</th>
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
            {data.map((item) => (
              <tr key={item.id} onClick={() => handleSelectProduct(item)}>
                <td style={{ wordWrap: "break-word", whiteSpace: "pre-wrap" }}>
                  {item?.id}
                </td>
                <td style={{ wordWrap: "break-word", whiteSpace: "pre-wrap" }}>
                  {item?.name}
                </td>
                <td>{item?.quantity}</td>
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
        <div className="pagination mb-3">
          <button
            onClick={() => handlePageChange(currentPage - 1)}
            disabled={currentPage === 1}
          >
            Trang trước
          </button>
          <button onClick={() => handlePageChange(currentPage + 1)}>
            Trang tiếp theo
          </button>
        </div>
        <div className="row">
          <div className="col-6">
            <button
              className="text-center"
              onClick={(e) => {
                e.preventDefault();
                setStatus1(!status1);
              }}
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
          <div className="col-6">
            <button
              className="text-center"
              onClick={(e) => {
                e.preventDefault();
                setStatus(!status);
              }}
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
