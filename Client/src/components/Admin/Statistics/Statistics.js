import React, { useEffect, useState } from "react";
import RevenueChart from "../../../views/Chart";
import axios from "axios";
const Statistics = () => {
  const [data, setData] = useState([]);
  const [profit, setProfit] = useState([]);
  useEffect(() => {
    axios.post("https://localhost:7295/api/Bill/totalRevenue").then((res) => {
      setData(res.data);
      console.log(res.data);
    });
  }, []);
  useEffect(() => {
    axios
      .get(
        "https://localhost:7295/api/OrderDetail/getTotalProfitByLast12Months"
      )
      .then((res) => {
        setProfit(res.data);
      });
  }, []);
  const revenueData = data?.reduce((result, item) => {
    result[item.datetime] = item.revenues;
    return result;
  }, {});
  const reversedObject = Object.fromEntries(
    Object.entries(revenueData).reverse()
  );
  return <RevenueChart data={reversedObject} profitData={profit} />;
};

export default Statistics;
