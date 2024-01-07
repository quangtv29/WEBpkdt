import React, { useState, useEffect } from "react";
import axios from "axios";
import "./TypeProduct.scss";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import CreateTypeProduct from "./CreateTypeProduct";
const ListTypeProduct = () => {
  const [selectedTypeProduct, setSelectedTypeProduct] = useState(null);
  const [isEditing, setIsEditing] = useState(false);

  const [data, setData] = useState([]);
  useEffect(() => {
    const fetchLoaiSanPham = async () => {
      try {
        const response = await axios.get(
          "https://localhost:7295/api/ProductType/GetAll"
        );
        setData(response.data.data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchLoaiSanPham();
  }, []);

  const handleSelectTypeProduct = (typeProduct) => {
    // console.log(product)
    setSelectedTypeProduct(typeProduct);
  };

  const handleEditTypeProduct = (typeProduct) => {
    setSelectedTypeProduct(typeProduct);
    setIsEditing(true);
  };

  const handleDeleteTypeProduct = (typeProductId) => {
    axios
      .post(`https://localhost:7295/api/ProductType?id=${typeProductId}`)
      .then(() => {
        // Xử lý kết quả trả về khi xóa thành công
        toast.success("Xóa loại sản phẩm thành công");
        setData(data.filter((item) => item.id !== typeProductId));
      })
      .catch((error) => {
        // Xử lý lỗi khi xóa không thành công
        toast.error(
          "Không xoá được loại sản phẩm vì đang tồn tài sản phẩm thuộc loại này"
        );
      });
  };

  // const handleAddProduct = (e) => {
  //   e.preventDefault();
  //   window.location.href = '/admin/create-product';
  // };

  return (
    <div className="container">
      {/* <div className='mb-3'>
        <button class="btn btn-navbar" type="button" onClick={(e) => handleAddProduct(e)}>
          <i class="fas fa-plus"></i>Thêm sản phẩm
        </button>
      </div> */}
      <div className="row">
        <div className="col-md-6 type">
          <table className="table table-striped">
            <thead>
              <tr>
                <th>Mã loại sản phẩm</th>
                <th>Tên loại sản phẩm</th>
                <th colspan="2">Thao tác</th>
              </tr>
            </thead>
            <tbody>
              {data?.map((item) => (
                <tr
                  key={item?.id}
                  onClick={() => handleSelectTypeProduct(item)}
                >
                  <td>{item?.id}</td>
                  <td>{item?.name}</td>
                  <td>
                    <i
                      class="fad fa-edit"
                      onClick={() => handleEditTypeProduct(item.id)}
                    ></i>
                  </td>
                  <td>
                    <i
                      class="fad fa-trash-alt"
                      onClick={() => handleDeleteTypeProduct(item.id)}
                    ></i>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
        <div className="col-md-6">
          {selectedTypeProduct ? (
            <CreateTypeProduct
              typeProduct={selectedTypeProduct}
              isEditing={isEditing}
            />
          ) : (
            <CreateTypeProduct />
          )}{" "}
        </div>
      </div>
    </div>
  );
};

export default ListTypeProduct;
