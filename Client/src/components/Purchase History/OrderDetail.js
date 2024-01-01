import React from "react";
import { useState } from "react";
import { useEffect } from "react";
import axios from "axios";
import Container from "../Container";
import { Link } from "react-router-dom";
const OrderDetail = () => {
  const id = localStorage.getItem("billid11");
  const [data, setData] = useState();
  const [status, setStatus] = useState(1);
  useEffect(() => {
    axios
      .post(
        "https://localhost:7295/api/Bill/getBillById",
        {},
        {
          params: {
            Id: id,
          },
        }
      )
      .then((res) => {
        setStatus(res.data.status);
      });
  }, [id]);
  useEffect(() => {
    axios
      .post(
        "https://localhost:7295/api/OrderDetail/getOrderDetailByBillId",
        {},
        {
          params: {
            id: id,
          },
        }
      )
      .then((res) => {
        setData(res.data);
      })
      .catch(() => {});
  }, [id]);

  return (
    <>
      <Container class1="cart-wrapper home-wrapper-2 py-5 w-100">
        <div className="row ">
          <div className="col-12">
            <h3 className="text-center">Chi tiết hoá đơn {id}</h3>
            <div className="cart-header py-3 d-flex justify-content-between align-items-center">
              <h4 className="col-5 text-center">Sản phẩm</h4>
              <h4 className="col-2 ">Giá bán</h4>
              <h4 className="col-2">Số lượng</h4>
              <h4 className="col-2">Tổng tiền</h4>
              <h4 className="col-1">Hành động</h4>
            </div>
          </div>
        </div>
        <div className="row">
          <div className="col-12">
            {data?.map((item, index) => (
              <div
                key={item.id}
                className="cart-data py-3 mb-2 d-flex justify-content-between align-items-center"
              >
                <div className="col-5 gap-15 d-flex align-items-center">
                  <div className="w-25">
                    <img
                      src={item?.image}
                      className="img-fluid"
                      alt="ảnh sản phẩm"
                    />
                  </div>
                  <div className="w-75">
                    <p>{item?.name}</p>
                  </div>
                </div>
                <div className="col-2">
                  <h5 className="price">
                    {item.price?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </h5>
                </div>
                <div className="col-2 d-flex align-items-center gap-15">
                  <div>{item?.quantity}</div>
                </div>

                <div className="col-2">
                  <h5 className="price">
                    {item?.totalMoney.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </h5>
                </div>
                {status === 0 &&
                localStorage.getItem("chucvu") !== "Manager" ? (
                  item?.isSave ? (
                    <div className="col-1">
                      <button
                        className="btn btn-danger"
                        onClick={() => {
                          localStorage.setItem("productId", item?.productId);
                          localStorage.setItem("orderId", item?.id);
                        }}
                      >
                        <Link to="/rating" style={{ color: "#fff" }}>
                          Đánh giá
                        </Link>
                      </button>
                    </div>
                  ) : (
                    <h6>Đã đánh giá</h6>
                  )
                ) : (
                  <div className="col-1"> </div>
                )}
              </div>
            ))}
          </div>
        </div>

        {/* <div className="row">
        <div className="col-12">
            <div className="cart-header py-3 d-flex justify-content-between align-items-center">
              <h4 className="cart-col-1">Sản phẩm</h4>
              <h4 className="cart-col-2">Giá bán</h4>
              <h4 className="cart-col-3">Số lượng</h4>
              <h4 className="cart-col-4">Tổng tiền</h4>
            </div>

            {data.map((item, index) => (
              <div
                key={item.id}
                className="cart-data py-3 mb-2 d-flex justify-content-between align-items-center"
              >
                <input
                  type="checkbox"
                  checked={selectedInvoices.includes(item.id)}
                  onChange={(event) =>
                    handleSelectInvoice(event, item.id, total[index], index)
                  }
                />
                <div className="cart-col-1 gap-15 d-flex align-items-center">
                  <div className="w-25">
                    <img
                      src={item.image}
                      className="img-fluid"
                      alt="ảnh sản phẩm"
                    />
                  </div>
                  <div className="w-75">
                    <p>{item.product}</p>
                    <p>Size: Không có</p>
                    <p>Màu: Không có</p>
                  </div>
                </div>
                <div className="cart-col-2">
                  <h5 className="price">
                    {item.price?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </h5>
                </div>
                <div className="cart-col-3 d-flex align-items-center gap-15">
                  <div>
                    <input
                      className="form-control"
                      type="number"
                      name=""
                      min={item.warehouse == 0 ? 0 : 1}
                      max={item?.warehouse}
                      id=""
                      value={quantities[index]}
                      onChange={(event) => {
                        const newQuantities = [...quantities];
                        newQuantities[index] = parseInt(event.target.value);
                        setQuantities(newQuantities);
                        const newTotal = [...total];
                        const change =
                          newQuantities[index] * item.price - total[index];
                        newTotal[index] = newQuantities[index] * item.price;
                        setTotal(newTotal);
                        if (checked[index]) {
                          setTotalMoney(totalMoney + change);
                        }
                        UpdateCart(event, item.id, newQuantities[index]);
                      }}
                    />
                  </div>
                  <div>
                    <AiFillDelete
                      className="text-danger"
                      onClick={() => handleRemoveFromCart(item)}
                    />
                  </div>
                </div>
                <div className="cart-col-4">
                  <h5 className="price">
                    {total[index]?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </h5>
                </div>
              </div>
            ))}
          </div>
          <div className="col-12 py-2 mt-4">
            <div className="d-flex justify-content-between align-items-baseline">
              <Link to="/product" className="button">
                Tiếp tục mua sắm
              </Link>
              <div className="d-flex flex-column align-items-end">
                <h4>
                  Tổng tiền:
                  {totalMoney.toLocaleString("vi-VN", {
                    style: "currency",
                    currency: "VND",
                  })}
                </h4>
                <p>Taxes and shipping calculated at checkout</p>
                <Link className="button" onClick={() => handleCreateBill()}>
                  Thanh toán
                </Link>
              </div>
            </div>
          </div>
        </div> */}
      </Container>
    </>
  );
};

export default OrderDetail;
