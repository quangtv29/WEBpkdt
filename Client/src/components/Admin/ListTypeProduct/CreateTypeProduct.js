import Form from "react-bootstrap/Form";
import React, { useState, useEffect } from "react";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import axios from "axios";
import "./TypeProduct.scss";
const CreatTypeProduct = (props) => {
  const [tenloaisp, setTenLoaiSP] = useState("");
  useEffect(() => {
    if (props.typeProduct) {
      setTenLoaiSP(props?.typeProduct?.name);
    }
  }, [props.typeProduct]);

  const settenloaisp = (e) => {
    setTenLoaiSP(e.target.value);
  };

  const addData = async (e) => {
    await axios
      .post("https://localhost:7295/api/ProductType/createProductType", {
        name: tenloaisp,
      })
      .then(() => {
        toast("Thêm loại sản phẩm thành công");
      })
      .catch(() => {
        toast.error("Thêm loại sản phẩm thất bại");
      });
  };

  return (
    <>
      <div className="container">
        <Form>
          <Form.Group>
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
