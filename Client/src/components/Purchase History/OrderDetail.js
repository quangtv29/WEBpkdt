import React from "react";
import { useState } from "react";
import { useEffect } from "react";
import axios from "axios";

const OrderDetail = () => {
  const id = localStorage.getItem("billid");
  const [data, setData] = useState();
  useEffect(() => {
    axios
      .post("https://localhost:7295/api/OrderDetail/getOrderDetailByBillId", {
        id,
      })
      .then((res) => {
        setData(res.data);
      })
      .catch(() => {});
  }, [id]);
  return <></>;
};

export default OrderDetail;
