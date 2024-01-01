// File: Revenue.js

import React, { useState, useEffect } from "react";
import { format, subMonths } from "date-fns";
import { Doughnut } from "react-chartjs-2";
import axios from "axios";

const Revenue = () => {
  const [monthlyRevenues, setMonthlyRevenues] = useState([]);
  const [selectedMonth, setSelectedMonth] = useState(0);
  const [name, setName] = useState([]);

  useEffect(() => {
    fetchDataForMonth(selectedMonth);
  }, [selectedMonth]);

  const fetchDataForMonth = (month) => {
    const startDate = subMonths(new Date(), month);

    const formattedStartDate = format(startDate, "yyyy-MM-dd");

    axios
      .post(
        "https://localhost:7295/api/Bill/statiscal",
        {},
        {
          params: {
            a: formattedStartDate,
          },
        }
      )
      .then((res) => {
        setName(res.data);
        setMonthlyRevenues(res.data.map((item) => item?.quantity));
      })
      .catch((error) => console.error("Error fetching data:", error));
  };

  const generateMonthOptions = () => {
    const options = [];
    for (let i = 0; i < 12; i++) {
      options.push(
        <option key={i} value={i}>
          {format(subMonths(new Date(), i), "MMMM yyyy")}
        </option>
      );
    }
    return options;
  };

  const chartData = {
    labels: [
      name[0]?.name,
      name[1]?.name,
      !name[2]?.name ? "" : name[2]?.name,
      !name[3]?.name ? "" : name[3]?.name,
      !name[4]?.name ? "" : name[4]?.name,
    ],
    datasets: [
      {
        data: monthlyRevenues,
        backgroundColor: [
          "#FF6384",
          "#36A2EB",
          "#FFCE56",
          "#4CAF50",
          !name[4]?.name ? "#fff" : "green",
        ],
        hoverBackgroundColor: [
          "#FF6384",
          "#36A2EB",
          "#FFCE56",
          "#4CAF50",
          "#FF5733",
        ],
      },
    ],
  };

  return (
    <div style={{ maxHeight: "50%", maxWidth: "50%" }} className="mt-4">
      <label>Chọn tháng: </label>
      <select
        value={selectedMonth}
        onChange={(event) => setSelectedMonth(parseInt(event.target.value, 10))}
      >
        {generateMonthOptions()}
      </select>
      <div>
        <h3>
          5 sản phẩm có doanh thu tháng cao nhất{" "}
          {format(subMonths(new Date(), selectedMonth), "MM yyyy")}
        </h3>
        {name.length > 0 ? (
          <Doughnut data={chartData} />
        ) : (
          <h3 className="mt-5">Không có dữ liệu</h3>
        )}
      </div>
    </div>
  );
};

export default Revenue;
