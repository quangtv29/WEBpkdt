import Form from "react-bootstrap/Form";
import React, { useState, useEffect } from "react";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import axios from "axios";
import "./Product.scss";
import CommonUtils from "../../../ultils/CommonUtils";
const CreatProduct = (props) => {
  const [masp, setMaSP] = useState("");
  const [tensp, setTenSP] = useState("");
  const [soluong, setSoLuong] = useState("");
  const [gianhap, setGiaNhap] = useState("");
  const [giaban, setGiaBan] = useState("");
  const [maloaisp, setMaLoaiSP] = useState("");
  const [nsx, setNSX] = useState("");
  const [mota, setMoTa] = useState("");
  const [file, setFile] = useState("");
  const [image, setImage] = useState("");
  // const imageRef = useRef(null);
  const [productType, setProductType] = useState([]);

  useEffect(() => {
    axios
      .get("https://localhost:7295/api/ProductType/getAll")
      .then((res) => {
        setProductType(res.data.data);
      })
      .catch(() => {});
  }, []);
  useEffect(() => {
    if (props.product) {
      setMaSP(props.product.id);
      setTenSP(props.product.name);
      setSoLuong(props.product.quantity);
      setGiaNhap(props.product.importPrice);
      setGiaBan(props.product.price);
      setMaLoaiSP(props.product.productTypeName);
      setNSX(props.product.producer);
      setMoTa(props.product.describe);
      setFile(props.product.image);
      setImage(props.product.image);
    }
  }, [props.product]);

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

  const setimgfile = async (e) => {
    var fileImage = e.target.files[0];
    var base64 = await CommonUtils.getBase64(fileImage);
    // var imageElement = document.createElement('img');

    console.log(base64);
    if (!fileImage.name) {
      return;
    }

    if (
      ![".jpg", ".png", ".jpeg"].some((ext) =>
        fileImage.name.toLowerCase().includes(ext)
      )
    ) {
      toast.error("Hình ảnh phải thuộc dạng jpeg");
      return;
    }

    const objectUrl = URL.createObjectURL(fileImage);
    setImage(objectUrl);
    setFile(base64);
  };

  const addData = async (e) => {
    // e.preventDefault();

    var formData = new FormData();
    formData.append("masp", masp);
    formData.append("tensp", tensp);
    formData.append("soluong", soluong);
    formData.append("gianhap", gianhap);
    formData.append("giaban", giaban);
    formData.append("maloaisp", maloaisp);
    formData.append("nsx", nsx);
    formData.append("mota", mota);
    formData.append("file", file);

    const config = {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    };

    let res = null;
    // if (props.isEditing === true) {
    //   res = await axios.post(`/api/sanpham/${masp}`, formData, config);
    // } else {
    //   res = await axios.post("/api/sanpham", formData, config);
    // }

    if (res.data.status === 201) {
      console.log("success");
      // history("/")
    } else {
      console.log("error");
    }
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
                defaultValue={maloaisp}
                onChange={(e) => setmaloaisp(e)}
              >
                {productType?.map((item) => (
                  <option key={item.id} selected={item?.name === maloaisp}>
                    {item?.name}
                  </option>
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
                onChange={(e) => setimgfile(e)}
                hidden
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

export default CreatProduct;
