import React, { useEffect, useState, useContext } from "react";
import { Container } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { MyContext } from "../encryptionKey";
import CryptoJS from "crypto-js";
import { toast } from "react-toastify";
import "./Profile.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEdit } from "@fortawesome/free-solid-svg-icons";
import { faSave } from "@fortawesome/free-solid-svg-icons";

const Profile = () => {
  const navigate = useNavigate();
  useEffect(() => {
    if (!localStorage.getItem("id")) {
      navigate("/login", { replace: true });
    }
  }, [navigate]);
  const { encryptionKey } = useContext(MyContext);
  const decryptedId = CryptoJS.AES.decrypt(
    localStorage.getItem("id"),
    encryptionKey
  ).toString(CryptoJS.enc.Utf8);
  const [customer, setCustomer] = useState([]);
  const [firstname, setFirstName] = useState("");
  const [lastname, setLastName] = useState("");
  const [address1, setAddress1] = useState("");
  const [address2, setAddress2] = useState("");
  const [detailOrder, setDetailOrder] = useState([]);
  const [selectedValue, setSelectedValue] = useState(0);
  const [active, setActive] = useState(false);
  const handleSelectChange = (event) => {
    setSelectedValue(parseInt(event.target.value, 10));
  };
  useEffect(() => {
    axios
      .post(
        "https://localhost:7295/api/Bill/getInfoOrder",
        {},
        {
          params: {
            Id: decryptedId,
          },
        }
      )
      .then((res) => {
        setDetailOrder(res.data);
      });
  }, [decryptedId]);
  useEffect(() => {
    axios
      .get(`https://localhost:7295/api/Customer/${decryptedId}`, {
        params: {
          Id: decryptedId,
        },
      })
      .then((res) => {
        setAddress1(res.data.data[0].address1 ?? "");
        setAddress2(res.data.data[0].address2 ?? "");
        setSelectedValue(res.data.data[0].gender);
      });
  }, [decryptedId]);
  useEffect(() => {
    axios
      .get("https://localhost:7295/api/Authentication", {
        params: {
          id: decryptedId,
        },
      })
      .then((res) => {
        setCustomer(res.data);
        setFirstName(res.data.firstName);
        setLastName(res.data.lastName);
      });
  }, [decryptedId]);
  const handleSave = (e) => {
    e.preventDefault();
    setActive(false);
    axios
      .post(
        "https://localhost:7295/api/Customer/updateCustomer",
        {
          address1: address1,
          address2: address2,
          gender: selectedValue,
        },
        {
          params: {
            Id: decryptedId,
            lastname: lastname,
            firstname: firstname,
          },
        }
      )
      .then(() => {
        toast.success("Lưu thành công");
      })
      .catch(() => {
        toast.error("Lỗi");
      });
  };

  const [image, setImage] = useState("");
  useEffect(() => {
    axios
      .get(`https://localhost:7295/api/Customer/${decryptedId}`)
      .then((res) => {
        setImage(res.data.data[0].image);
      })
      .catch((err) => {
        console.error(err);
      });
  }, [decryptedId]);
  const [avatar, setAvatar] = useState("");
  const handleFileChange = (event) => {
    const file = event.target.files[0];
    setAvatar(file);
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        setImage(reader.result);
      };
      reader.readAsDataURL(file);
    }
  };
  const addData = async (e) => {
    e.preventDefault();
    const config = {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    };
    var formData = new FormData();

    formData.append("Image", avatar);

    axios
      .post(
        `https://localhost:7295/api/Customer/addAvatar`,
        formData,
        {
          params: {
            CustomerId: decryptedId,
          },
        },
        config
      )
      .then(() => {
        toast("Đổi ảnh đại diện thành công");
      })
      .catch(() => {
        toast.error("Đổi ảnh đại diện thất bại");
      });
  };
  const styletd = {
    textAlign: "right",
    color: "rgba(85,85,85,.8)",
    overflow: "hidden",
    paddingBottom: "30px",
    whiteSpace: "nowrap",
    minWidth: "20%",
  };
  const styleright = {
    boxSizing: "border-box",
    paddingLeft: 20,
    paddingBottom: 36,
    fontSize: ".875rem",
    color: "#333",
  };
  return (
    <>
      <Container className="m-0 p-0" style={{ maxWidth: 1350 }}>
        <div
          style={{
            display: "block",
            minWidth: "100%",
            borderBottom: "0.0625rem solid #efefef",
            padding: "1.125rem 0",
          }}
        >
          <h1
            style={{
              margin: 0,
              fontSize: "1.125rem",
              fontWeight: 500,
              lineHeight: "1.5rem",
              textTransform: "capitalize",
              color: "#333",
            }}
            className="text-center"
          >
            Hồ Sơ Của Tôi
          </h1>
          <div
            style={{
              marginTop: "0.1875rem",
              fontSize: ".875rem",
              lineHeight: "1.0625rem",
              color: "#555",
            }}
            className="text-center"
          >
            Quản lý thông tin hồ sơ để bảo mật tài khoản
          </div>
        </div>
        <div
          className="row w-100 m-0"
          style={{ borderBottom: "0.0625rem solid #efefef" }}
        >
          <div className="col-6 " style={{ backgroundColor: "#fff" }}>
            <div className="mt-5">
              <table
                className="ml-5"
                style={{ borderCollapse: "collapse", borderColor: "gray" }}
              >
                <tr>
                  <td style={styletd}>
                    <label>Tên đăng nhập</label>
                  </td>
                  <td style={styleright}>{customer?.userName}</td>
                </tr>
                <tr>
                  <td style={styletd}>
                    <label>Số điện thoại</label>
                  </td>
                  <td style={styleright}>{customer?.phoneNumber}</td>
                </tr>
                <tr>
                  <td style={styletd}>
                    <label>Ngày lập tài khoản</label>
                  </td>
                  <td style={styleright}>{customer?.formatDate}</td>
                </tr>
                <tr>
                  <td style={styletd}>
                    <label>Số đơn hàng đã mua</label>
                  </td>
                  <td style={styleright}>{detailOrder?.quantity}</td>
                </tr>
                <tr>
                  <td style={styletd}>
                    <label>Tổng tiền hoá đơn tháng này</label>
                  </td>
                  <td style={styleright}>
                    {detailOrder?.totalOrderofMonth?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </td>
                </tr>
                <tr>
                  <td style={styletd}>
                    <label>Tổng số tiền đã mua</label>
                  </td>
                  <td style={styleright}>
                    {detailOrder?.totalOrder?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </td>
                </tr>
                <tr>
                  <td style={styletd}>
                    <label>Số tiền được giảm giá</label>
                  </td>
                  <td style={styleright}>
                    {detailOrder?.totalDiscount?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </td>
                </tr>
              </table>
            </div>
          </div>

          <div className="col-6" style={{ backgroundColor: "#fff" }}>
            <div style={{ borderLeft: "1px solid black", paddingLeft: 30 }}>
              <h2
                className="text-center  "
                style={{
                  margin: 0,
                  fontSize: "1.125rem",
                  fontWeight: 500,
                  lineHeight: "1.5rem",
                  textTransform: "capitalize",
                  color: "#333",
                }}
              >
                {" "}
                Sửa Thông Tin Cá Nhân
              </h2>
              <form className="d-flex flex-column gap-15 ">
                <label className="mb-0">Họ </label>
                <input
                  type="text"
                  value={firstname}
                  onChange={(e) => {
                    e.preventDefault();
                    setFirstName(e.target.value);
                  }}
                  disabled={!active}
                />
                <label className="mb-0">Tên</label>
                <input
                  type="text"
                  value={lastname}
                  onChange={(e) => {
                    e.preventDefault();
                    setLastName(e.target.value);
                  }}
                  disabled={!active}
                />
                <label className="mb-0">Địa chỉ 1</label>
                <input
                  type="text"
                  value={address1}
                  onChange={(e) => {
                    e.preventDefault();
                    setAddress1(e.target.value);
                  }}
                  disabled={!active}
                />
                <label className=" mb-0">Địa chỉ 2</label>
                <input
                  type="text"
                  value={address2}
                  onChange={(e) => {
                    e.preventDefault();
                    setAddress2(e.target.value);
                  }}
                  disabled={!active}
                />
                <label className=" mb-0">Giới tính</label>
                <select
                  value={selectedValue}
                  onChange={handleSelectChange}
                  disabled={!active}
                >
                  <option value={0}>Nam</option>
                  <option value={1}>Nữ</option>
                  <option value={2}>Khác</option>
                </select>

                <div className="w-100 d-flex justify-content-center ">
                  <button
                    className="button update w-75"
                    onClick={(e) => {
                      e.preventDefault();
                      setActive(true);
                    }}
                    style={{ maxWidth: 150 }}
                  >
                    <FontAwesomeIcon icon={faEdit} className="edit-icon" /> Sửa
                  </button>
                  <button
                    className="button save w-75 ml-2"
                    onClick={(e) => handleSave(e)}
                    style={{ maxWidth: 150 }}
                  >
                    <FontAwesomeIcon icon={faSave} /> Lưu
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
        <div className="avatar-containerr">
          <p>
            <label>Thay ảnh đại diện</label>
          </p>
          <div>
            <img
              src={
                image ??
                "https://res.cloudinary.com/dimu08wco/image/upload/v1703320369/5f344979-d3a4-4205-a834-ef9d7f1c001b.jpg"
              }
              alt="Avatar"
              className="avatar-imagee "
            />
          </div>
          <input
            type="file"
            name="file"
            onChange={handleFileChange}
            id="mypicture"
          />
          <div>
            <button className="change-button mb-2" onClick={(e) => addData(e)}>
              Đổi
            </button>
          </div>
        </div>
      </Container>
    </>
  );
};
export default Profile;
