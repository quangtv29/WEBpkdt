import Form from "react-bootstrap/Form";
import React, { useState, useEffect } from "react";
import "react-toastify/dist/ReactToastify.css";
import axios from "axios";
import "./Product.scss";
import { toast } from "react-toastify";
const CreateProduct = (props) => {
  const [masp, setMaSP] = useState("");
  const [tensp, setTenSP] = useState("");
  const [soluong, setSoLuong] = useState("");
  const [gianhap, setGiaNhap] = useState("");
  const [giaban, setGiaBan] = useState("");
  const productType = props.productType;
  const [maloaisp, setMaLoaiSP] = useState(props.maloaisp);
  const [nsx, setNSX] = useState("");
  const [mota, setMoTa] = useState("");
  const [image, setImage] = useState("");
  // const imageRef = useRef(null);
  const accessToken = localStorage.getItem("accessToken");
  useEffect(() => {
    if (props.product) {
      setMaSP(props.product.id);
      setTenSP(props.product.name);
      setSoLuong(props.product.quantity);
      setGiaNhap(props.product.importPrice);
      setGiaBan(props.product.price);
      setMaLoaiSP(props.maloaisp);
      setNSX(props.product.producer);
      setMoTa(props.product.describe);
      setImage(props.product.image);
    }
  }, [props.product]);

  const handleFileChange = (e) => {
    const selectedFile = e.target.files[0];
    setImage(selectedFile);
  };
  const setmasp = (e) => {
    setMaSP(e.target.value);
  };

  const settensp = (e) => {
    setTenSP(e.target.value);
  };

  const setsoluong = (e) => {
    setSoLuong(e.target.value);
  };

  const setgianhap = (e) => {
    setGiaNhap(e.target.value);
  };

  const setgiaban = (e) => {
    setGiaBan(e.target.value);
  };

  const setmaloaisp = (e) => {
    let id = "";
    productType.map((item) => {
      if (item.name === e.target.value) {
        id = item.id;
      }
    });
    setMaLoaiSP(id);
  };

  const setnsx = (e) => {
    setNSX(e.target.value);
  };

  const setmota = (e) => {
    setMoTa(e.target.value);
  };

  const addData = async (e) => {
    e.preventDefault();
    const config = {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    };
    var formData = new FormData();
    formData.append("Id", masp);
    formData.append("Name", tensp);
    formData.append("Quantity", soluong);
    formData.append("ImportPrice", gianhap);
    formData.append("Price", giaban);
    formData.append("ProductTypeID", maloaisp);
    formData.append("Producer", nsx);
    formData.append("Describe", mota);
    formData.append("Image", image);

    axios.defaults.headers.common["Authorization"] = `Bearer ${accessToken}`;

    axios
      .post(
        "https://localhost:7295/api/Product/updateProduct",
        formData,
        config
      )
      .then(() => {
        toast("Cập nhật sản phẩm thành công");
      })
      .catch(() => {
        toast.error("Cập nhật sản phẩm thất bại");
      });
  };

  return (
    <>
      <div className="container">
        <Form className="row">
          <Form.Group className="col-md-6">
            <Form.Group className="mb-1">
              <Form.Label>Mã sản phẩm</Form.Label>
              <Form.Control
                type="text"
                name="masp"
                onChange={setmasp}
                defaultValue={masp}
              />
            </Form.Group>

            <Form.Group className="mb-1">
              <Form.Label>Tên sản phẩm</Form.Label>
              <Form.Control
                type="text"
                name="tensp"
                onChange={settensp}
                defaultValue={tensp}
              />
            </Form.Group>

            <Form.Group className="mb-1">
              <Form.Label>Số lượng</Form.Label>
              <Form.Control
                type="text"
                name="soluong"
                onChange={setsoluong}
                defaultValue={soluong}
              />
            </Form.Group>

            <Form.Group className="mb-1">
              <Form.Label>Giá nhập</Form.Label>
              <Form.Control
                type="text"
                name="gianhap"
                onChange={setgianhap}
                defaultValue={gianhap}
              />
            </Form.Group>

            <Form.Group className="mb-1">
              <Form.Label>Giá bán</Form.Label>
              <Form.Control
                type="text"
                name="giaban"
                onChange={setgiaban}
                defaultValue={giaban}
              />
            </Form.Group>

            <Form.Group className="mb-1">
              <Form.Label>Loại sản phẩm</Form.Label>
              <Form.Select
                name="maloaisp"
                value={props?.product?.productTypeName}
                onChange={(e) => setmaloaisp(e)}
              >
                {productType?.map((item) => (
                  <option key={item.id}>{item?.name}</option>
                ))}
              </Form.Select>
            </Form.Group>

            <Form.Group className="mb-1">
              <Form.Label>NSX</Form.Label>
              <Form.Control
                type="text"
                name="nsx"
                onChange={setnsx}
                defaultValue={nsx}
              />
            </Form.Group>

            <Form.Group className="mb-1">
              <Form.Label>Mô tả</Form.Label>
              <Form.Control
                type="text"
                name="mota"
                onChange={setmota}
                defaultValue={mota}
              />
            </Form.Group>
          </Form.Group>

          <Form.Group className="col-md-6">
            <Form.Group className="mb-1">
              <Form.Label htmlFor="mypicture" className="preview">
                <i className="fas fa-cloud-upload"></i>
                <span>Select Your Image</span>
                <div
                  className="preview-image"
                  style={{ backgroundImage: `url(${image})` }}
                ></div>
              </Form.Label>
              <Form.Control
                type="file"
                name="file"
                onChange={(e) => handleFileChange(e)}
                id="mypicture"
              />
            </Form.Group>
            <button
              className="btn btn-primary"
              variant="primary"
              type="submit"
              onClick={addData}
            >
              <i class="fas fa-plus mr-2"></i>Lưu sản phẩm
            </button>
          </Form.Group>
        </Form>
      </div>
    </>
  );
};

export default CreateProduct;
