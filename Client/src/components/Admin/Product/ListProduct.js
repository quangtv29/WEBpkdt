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
  const [maloaisp, setMaLoaiSP] = useState("");
  const [status, setStatus] = useState(false);
  const [status1, setStatus1] = useState(false);
  useEffect(() => {
    axios
      .get("https://localhost:7295/api/ProductType/getAll")
      .then((res) => {
        setProductType(res.data.data);
        setMaLoaiSP(res.data.data[0].id);
        console.log(res.data.data);
      })
      .catch(() => {});
  }, []);
  const [data, setData] = useState([]);
  const pageNumber = 1;
  const pageSize = 10;
  useEffect(() => {
    const fetchSanPham = async () => {
      try {
        const response = await axios.post(
          "https://localhost:7295/api/Product/getAllProduct",
          {
            pageNumber,
            pageSize,
          }
        );
        setData(response.data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchSanPham();
  }, []);

  const handleSelectProduct = (product) => {
    // console.log(product);
    setSelectedProduct(product);
  };

  const handleDeleteProduct = async (productId) => {
    try {
      const response = await axios.delete(`/api/sanpham/${productId}`);
      console.log(response.data);
      // Xử lý kết quả trả về khi xóa thành công
      toast.success("Xóa sản phẩm thành công");
      window.location.reload();
    } catch (error) {
      console.error(error);
      // Xử lý lỗi khi xóa không thành công
      toast.error("Xóa sản phẩm thất bại");
    }
  };

  // const handleAddProduct = (e) => {
  //   e.preventDefault();
  //   window.location.href = '/admin/create-product';
  // };

  return (
    <div className="contai">
      {/* <div className='mb-3'>
        <button class="btn btn-navbar" type="button" onClick={(e) => handleAddProduct(e)}>
          <i class="fas fa-plus"></i>Thêm sản phẩm
        </button>
      </div> */}
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
              <th colspan="2">Thao tác</th>
            </tr>
          </thead>
          <tbody>
            {data.map((item) => (
              <tr key={item.id} onClick={() => handleSelectProduct(item)}>
                <td>{item.id}</td>
                <td>{item.name}</td>
                <td>{item.quantity}</td>
                <td>{item.importPrice}</td>
                <td>{item.price}</td>
                <td>{item.productTypeName}</td>
                <td>{item.producer}</td>
                <td>{item.describe}</td>
                <td>
                  <img src={item.image} alt={item.name} className="fixImage" />
                </td>

                <td>
                  <i
                    class="fad fa-trash-alt"
                    onClick={() => handleDeleteProduct(item.MaSP)}
                  ></i>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        <div className="row">
          <div className="col-6">
            <button
              className="text-center"
              onClick={(e) => {
                e.preventDefault();
                setStatus1(true);
              }}
            >
              Sửa sản phẩm
            </button>
            {status1 && <CreateProduct product={selectedProduct} />}
          </div>
          <div className="col-6">
            <button
              className="text-center"
              onClick={(e) => {
                e.preventDefault();
                setStatus(true);
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
