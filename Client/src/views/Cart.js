import React, { useContext, useEffect, useState } from "react";
import { CartContext } from "../CartContext";
import BreadCrumb from "../components/BreadCrumb";
import Meta from "../components/Meta";
import { AiFillDelete } from "react-icons/ai";
import { Link } from "react-router-dom";
import Container from "../components/Container";
import axios from "axios";
import { MyContext } from "../encryptionKey";
import CryptoJS from "crypto-js";

export const Cart = () => {
  const { cartItems, totalPrice, removeFromCart, updateCart } =
    useContext(CartContext);
  const handleRemoveFromCart = (item) => {
    removeFromCart(item);
  };

  const { encryptionKey } = useContext(MyContext);
  const [data, setData] = useState([]);
  useEffect(() => {
    axios
      .get(
        `https://localhost:7295/api/OrderDetail/listCart?CustomerId=${decryptedId}`
      )
      .then((res) => {
        setData(res.data);
      })
      .catch((err) => {
        console.error(err);
      });
  }, []);
  const handleUpdateCart = (event, item) => {
    const quantity = parseInt(event.target.value);
    const updatedQuantity = Math.min(Math.max(quantity, 1), 10);
    updateCart(item, updatedQuantity);
  };
  const [quantities, setQuantities] = useState([]);
  const [total, setTotal] = useState([]);
  useEffect(() => {
    const initialQuantities = data.map((item) => item.quantity);
    setQuantities(initialQuantities);
    const listTotal = data.map((item) => item.totalMoney);
    setTotal(listTotal);
  }, [data]);

  const decryptedId = CryptoJS.AES.decrypt(
    localStorage.getItem("id"),
    encryptionKey
  ).toString(CryptoJS.enc.Utf8);

  const UpdateCart = (event, id, quantity) => {
    event.preventDefault();
    axios
      .post("https://localhost:7295/api/OrderDetail/updateTotal", {
        id,
        quantity,
      })
      .then((res) => {
        // const updatedTotal = data.map((item) => {
        //   if (item.id === id) {
        //     return item.price * quantity;
        //   }
        //   return item.totalMoney;
        // });
        // setTotal(updatedTotal);
      });
  };

  return (
    <>
      <Meta title={"Giỏ Hàng"} />
      <BreadCrumb title="Cart" />
      <Container class1="cart-wrapper home-wrapper-2 py-5">
        <div className="row">
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
                    {item.price.toLocaleString("vi-VN", {
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
                      min={1}
                      max={10}
                      id=""
                      value={quantities[index]}
                      onChange={(event) => {
                        const newQuantities = [...quantities];
                        newQuantities[index] = parseInt(event.target.value);
                        setQuantities(newQuantities);
                        const newTotal = [...total];
                        newTotal[index] = newQuantities[index] * item.price;
                        console.log(newTotal[index]);
                        setTotal(newTotal);
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
                  Tổng tiền:{" "}
                  {totalPrice.toLocaleString("vi-VN", {
                    style: "currency",
                    currency: "VND",
                  })}
                </h4>
                <p>Taxes and shipping calculated at checkout</p>
                <Link to="/checkout" className="button">
                  Thanh toán
                </Link>
              </div>
            </div>
          </div>
        </div>
      </Container>
    </>
  );
};

export default Cart;
