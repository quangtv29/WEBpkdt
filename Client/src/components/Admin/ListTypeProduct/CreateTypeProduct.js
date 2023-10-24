import Form from 'react-bootstrap/Form';
import React, { useState, useEffect, useRef } from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import axios from 'axios';
import './TypeProduct.scss';
import CommonUtils from '../../../ultils/CommonUtils';
const CreatTypeProduct = (props) => {
  const [maloaisp, setMaLoaiSP] = useState('');
  const [tenloaisp, setTenLoaiSP] = useState('');
  useEffect(() => {
    if (props.typeProduct) {
      setMaLoaiSP(props.typeProduct.MaLoaiSP);
      setTenLoaiSP(props.typeProduct.TenLoaiSP);
    }
  }, [props.typeProduct]);

  const setmaloaisp = (e) => {
    setMaLoaiSP(e.target.value);
  };

  const settenloaisp = (e) => {
    setTenLoaiSP(e.target.value);
  };

  const addData = async (e) => {
    var formData = new FormData();
    formData.append('maloaisp', maloaisp);
    formData.append('tenloaisp', tenloaisp);

    const config = {
      headers: {
        'Content-Type': 'multipart/form-data',
      },
    };

    const res = null;
    if (props.isEditing === true) {
      res = await axios.post(`/api/loaisanpham/${maloaisp}`, formData, config);
    } else {
      res = await axios.post('/api/loaisanpham', formData, config);
    }

    if (res.data.status == 201) {
      toast.success('Lưu thành công');
      // history("/")
    } else {
      console.log('error');
    }
  };

  return (
    <>
      <div className="container">
        <Form>
          <Form.Group>
            <Form.Group className="mb-1 type">
              <Form.Label>Mã loại sản phẩm</Form.Label>
              <Form.Control
                type="text"
                name="maloaisp"
                onChange={setmaloaisp}
                defaultValue={maloaisp}
              />
            </Form.Group>

            <Form.Group className="mb-1">
              <Form.Label>Tên loại sản phẩm</Form.Label>
              <Form.Control
                type="text"
                name="tenloaisp"
                onChange={settenloaisp}
                defaultValue={tenloaisp}
              />
            </Form.Group>
          </Form.Group>
        </Form>
        <button
          className="btn btn-primary save-type"
          variant="primary"
          type="submit"
          onClick={addData}
        >
          <i class="fas fa-plus mr-2"></i>Lưu loại sản phẩm
        </button>
      </div>
    </>
  );
};

export default CreatTypeProduct;
