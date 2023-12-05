import React, { useContext, useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { BiArrowBack } from "react-icons/bi";
import Container from "../components/Container";
import axios from "axios";
import { MyContext } from "../encryptionKey";
import CryptoJS from "crypto-js";
const Checkout = () => {
  const [address, setAddress] = useState({});
  const [customer, setCustomer] = useState();
  const [data, setData] = useState();
  const [checkdiscount, setCheckDiscount] = useState(0);
  const [discountCode, setDiscountCode] = useState();
  const [name, setName] = useState("");
  const [phone, setPhone] = useState("");
  const { encryptionKey } = useContext(MyContext);
  const decryptedId = CryptoJS.AES.decrypt(
    localStorage.getItem("id"),
    encryptionKey
  ).toString(CryptoJS.enc.Utf8);
  // const handleAddressChange = (newAddress) => {
  //   setAddress(newAddress);
  // };
  // const { id } = useState('1');
  const handleOrder = (totalMoney, e) => {
    if (phone == null) {
      alert("Bạn cần nhập số điện thoại");
    } else {
      axios
        .post("https://localhost:7295/api/bill/updateBill", {
          id: localStorage.getItem("billid1"),
          discount: checkdiscount,
          intoMoney: totalMoney - checkdiscount,
          address: "",
          phoneNumber: phone,
          status: 3,
        })
        .then(() => {
          axios
            .post(
              "https://localhost:7295/api/orderdetail/updateOrderDetail",
              {},
              {
                params: {
                  Id: localStorage.getItem("billid1"),
                  isCart: "delivering",
                },
              }
            )
            .then((res) => {
              if (res.data.message === "Thêm hoá đơn bị lỗi") {
                alert("Số lượng sản phẩm trong kho không đủ!");
                window.location.href = "/cart";
              } else {
                alert("Đặt hàng thành công");
              }
            })
            .catch(() => {
              alert("Số lượng sản phẩm trong kho không đủ!");
              window.location.href = "/cart";
            });
        })
        .catch(() => {
          alert("Thêm hoá đơn bị lỗi!");
        });
    }
  };

  const handleCheckCode = (event) => {
    event.preventDefault();
    axios
      .get("https://localhost:7295/api/Sale", {
        params: {
          discountCode: discountCode,
          totalMoney: data?.totalMoney,
        },
      })
      .then((res) => {
        setCheckDiscount(res.data.message);
      });
  };
  useEffect(() => {
    axios
      .get("https://localhost:7295/api/Authentication", {
        params: {
          id: decryptedId,
        },
      })
      .then((res) => {
        setCustomer(res.data);
        setPhone(res.data.phoneNumber);
      });
  }, [decryptedId]);
  useEffect(() => {
    axios
      .post(
        "https://localhost:7295/api/Bill/getBillById",
        {},
        {
          params: {
            Id: localStorage.getItem("billid1"),
          },
        }
      )
      .then((res) => {
        setData(res.data);
      });
  }, [decryptedId]);

  // useEffect(() => {
  //   const fetchKhachHang = async () => {
  //     try {
  //       const response = await axios.get(`/api/khachhang/1`);
  //       setCustomer(response.data[0]);
  //       console.log(customer);
  //     } catch (error) {
  //       console.error(error);
  //     }
  //   };

  // fetchKhachHang();

  //   setInvoice(customer.MaKH, "", totalPrice, "", "Chưa check");
  //   setInvoiceDetails(cartItems.MaSP);
  //   console.log(invoice);
  //   console.log(invoiceDetails);
  // }, []);

  // const handleOrder = (invoice, invoiceDetails) => {
  // const post = async (invoice, invoiceDetails) => {
  //   try {
  //     // Tạo mới Hóa đơn
  //     const invoiceResponse = await axios.post('/api/hoadon', invoice);
  //     const invoiceId = invoiceResponse.data.id;
  //     // Tạo mới danh sách Chi tiết hóa đơn
  //     const invoiceDetailPromises = invoiceDetails.map((invoiceDetail) => {
  //       invoiceDetail.invoiceId = invoiceId;
  //       return axios.post('/api/chitiethoadon', invoiceDetail);
  //     });
  //     const invoiceDetailResponses = await Promise.all(invoiceDetailPromises);
  //     console.log('Tạo mới Hóa đơn thành công:', invoiceResponse.data);
  //     console.log(
  //       'Tạo mới Chi tiết hóa đơn thành công:',
  //       invoiceDetailResponses.map((response) => response.data)
  //     );
  //   } catch (error) {
  //     console.error('Lỗi khi tạo mới Hóa đơn và Chi tiết hóa đơn:', error);
  //   }
  // };
  // post(invoice, invoiceDetails);
  // };

  return (
    <>
      <Container className="checkout-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-7">
            <div className="checkout-left-data">
              <nav
                style={{ "--bs-breadcrumb-divider": ">" }}
                aria-label="breadcrumb"
              >
                <ol className="breadcrumb">
                  <li className="breadcrumb-item">
                    <Link className="text-dark total-price" to="/cart">
                      Giỏ hàng
                    </Link>
                  </li>
                  /
                  <li
                    className="breadcrumb-ite total-price active"
                    aria-current="page"
                  >
                    Thông tin
                  </li>
                  /
                  <li className="breadcrumb-item total-price active">
                    Chi phí vận chuyển
                  </li>
                  <li
                    className="breadcrumb-item total-price active"
                    aria-current="page"
                  >
                    Thanh toán
                  </li>
                </ol>
              </nav>
              <h4 className="title total">Thông tin liên lạc</h4>
              <p className="user-details total">
                {customer?.firstName + " " + customer?.lastName} (
                {customer?.phoneNumber})
              </p>
              <h4 className="mb-3">Địa chỉ nhận hàng</h4>
              <form
                action=""
                className="d-flex gap-15 flex-wrap justify-content-between"
              >
                <div className="flex-grow-1">
                  <input
                    type="text"
                    value={name}
                    placeholder="Tên người nhận"
                    className="form-control"
                    onChange={(e) => {
                      e.preventDefault();
                      setName(e.target.value);
                    }}
                  />
                </div>
                <div className="flex-grow-1">
                  <input
                    type="text"
                    value={phone}
                    placeholder="Số điện thoại"
                    className="form-control"
                    onChange={(e) => {
                      e.preventDefault();
                      setPhone(e.target.value);
                    }}
                  />
                </div>
                <div className="w-100">
                  <h4 className="title total">
                    Tỉnh/Thành phố, Quận/Huyện, Phường/Xã
                  </h4>
                  {/* <AddressForm onChange={handleAddressChange} /> */}
                </div>
                <div className="d-flex">
                  <div className="mr-2">
                    {address.province ? address.province.label : ""},
                  </div>
                  <div className="mr-2">
                    {address.district ? address.district.label : ""},
                  </div>
                  <div>{address.ward ? address.ward.label : ""}</div>
                </div>
                <div className="w-100">
                  <h4 className="title total">Địa chỉ cụ thể</h4>
                  <input
                    type="text"
                    placeholder="Tên đường, Tòa nhà, Số nhà."
                    className="form-control"
                  />
                </div>
                <div className="w-70">
                  <h4 className="title total">Mã giảm giá</h4>
                  <div className="d-flex">
                    <input
                      type="text"
                      value={discountCode}
                      className="form-control"
                      onChange={(event) => {
                        event.preventDefault();
                        setDiscountCode(event.target.value);
                      }}
                    />
                    <button
                      style={{ borderRadius: 5 }}
                      onClick={(event) => handleCheckCode(event)}
                    >
                      Nhập
                    </button>
                  </div>
                </div>
                <div className="w-100">
                  {typeof checkdiscount === "string" ? (
                    <p className="text-danger">{checkdiscount}</p>
                  ) : (
                    <p>
                      {checkdiscount === 0 ||
                        checkdiscount?.toLocaleString("vi-VN", {
                          style: "currency",
                          currency: "VND",
                        })}
                    </p>
                  )}
                </div>
                {/* <div className="flex-grow-1">
                  <input
                    type="text"
                    placeholder="City"
                    className="form-control"
                  />
                </div>
                <div className="flex-grow-1">
                  <select name="" className="form-control form-select" id="">
                    <option value="" selected disabled>
                      Select State
                    </option>
                  </select>
                </div>
                <div className="flex-grow-1">
                  <input
                    type="text"
                    placeholder="Zipcode"
                    className="form-control"
                  />
                </div> */}
                <div className="w-100">
                  <div className="d-flex justify-content-between align-items-center">
                    <Link to="/cart" className="text-dark">
                      <BiArrowBack className="me-2" />
                      Quay lại Giỏ hàng
                    </Link>
                    <Link to="/cart" className="button">
                      Tiếp tục mua sắm
                    </Link>
                    <Link
                      className="button"
                      // onClick={handleOrder(invoice, invoiceDetails)}
                      onClick={(e) => handleOrder(data.totalMoney, e)}
                    >
                      Đặt hàng
                    </Link>
                  </div>
                </div>
              </form>
            </div>
          </div>
          <div className="col-5">
            {/* {cartItems.map((item) => (
              <div key={item.MaSP} className="border-bottom py-4">
                <div className="d-flex gap-10 mb-2 align-align-items-center">
                  <div className="w-75 d-flex gap-10">
                    <div className="w-25 position-relative">
                      <span
                        style={{ top: "-10px", right: "2px" }}
                        className="badge bg-secondary text-white rounded-circle p-2 position-absolute"
                      >
                        {item.quantity}meo
                      </span>
                      <img
                        className="img-fluid"
                        src={item?.image}
                        alt="product"
                      />
                    </div>
                    <div>
                      <h5 className="total-price">{item.TenSP}</h5>
                      <p className="total-price">
                        {item.GiaBan?.toLocaleString("vi-VN", {
                          style: "currency",
                          currency: "VND",
                        })}
                      </p>
                    </div>
                  </div>
                  <div className="flex-grow-1">
                    <h5 className="total">
                      {item.prices?.toLocaleString("vi-VN", {
                        style: "currency",
                        currency: "VND",
                      })}
                    </h5>
                  </div>
                </div>
              </div>
            ))} */}
            <div className="border-bottom py-4">
              <div className="d-flex justify-content-between align-items-center">
                <p className="total">Tổng tiền hàng</p>
                <p className="total-price">
                  {data?.totalMoney?.toLocaleString("vi-VN", {
                    style: "currency",
                    currency: "VND",
                  })}
                </p>
              </div>
              <div className="d-flex justify-content-between align-items-center">
                <p className="mb-0 total">Giảm giá</p>
                <p className="mb-0 total-price">
                  {typeof checkdiscount === "number"
                    ? checkdiscount.toLocaleString("vi-VN", {
                        style: "currency",
                        currency: "VND",
                      })
                    : "0đ"}
                </p>
              </div>
            </div>
            <div className="d-flex justify-content-between align-items-center border-bootom py-4">
              <h4 className="total">Tổng thanh toán</h4>
              <h5 className="total-price">
                {(
                  data?.totalMoney -
                  (typeof checkdiscount === "string" ? 0 : checkdiscount)
                ).toLocaleString("vi-VN", {
                  style: "currency",
                  currency: "VND",
                })}
              </h5>
            </div>
          </div>
        </div>
      </Container>
    </>
  );
};

export default Checkout;
