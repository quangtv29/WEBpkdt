import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './TypeProduct.scss';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import CreateTypeProduct from './CreateTypeProduct';
const ListTypeProduct = (props) => {
  const [selectedTypeProduct, setSelectedTypeProduct] = useState(null);
  const [isEditing, setIsEditing] = useState(false);

  const [data, setData] = useState([]);
  useEffect(() => {
    const fetchLoaiSanPham = async () => {
      try {
        const response = await axios.get('/api/loaisanpham');
        setData(response.data);
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
      .delete(`/api/loaisanpham/${typeProductId}`)
      .then((response) => {
        console.log(response.data);
        // Xử lý kết quả trả về khi xóa thành công
        toast.success('Xóa loại sản phẩm thành công');
        window.location.reload();
      })
      .catch((error) => {
        console.error(error);
        // Xử lý lỗi khi xóa không thành công
        toast.error('Xóa loại sản phẩm thất bại');
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
              {data.map((item) => (
                <tr
                  key={item.MaLoaiSP}
                  onClick={() => handleSelectTypeProduct(item)}
                >
                  <td>{item.MaLoaiSP}</td>
                  <td>{item.TenLoaiSP}</td>
                  <td>
                    <i
                      class="fad fa-edit"
                      onClick={() => handleEditTypeProduct(item.MaLoaiSP)}
                    ></i>
                  </td>
                  <td>
                    <i
                      class="fad fa-trash-alt"
                      onClick={() => handleDeleteTypeProduct(item.MaLoaiSP)}
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
          )}{' '}
        </div>
      </div>
    </div>
  );
};

export default ListTypeProduct;
