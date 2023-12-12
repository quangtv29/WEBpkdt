// RevenueChart.js
import React, { useEffect, useRef } from "react";
import Chart from "chart.js/auto";

const RevenueChart = ({ data, profitData, title }) => {
  const chartRef = useRef(null);

  useEffect(() => {
    const ctx = chartRef.current.getContext("2d");

    const chart = new Chart(ctx, {
      type: "bar",
      data: {
        labels: Object.keys(data),
        datasets: [
          {
            label: "Doanh thu",
            data: Object.values(data),
            backgroundColor: "rgba(75, 192, 192, 0.2)",
            borderColor: "rgba(75, 192, 192, 1)",
            borderWidth: 1,
          },
          {
            label: "Lợi nhuận",
            data: Object.values(profitData),
            backgroundColor: "rgba(255, 0, 0, 0.2)", // Màu hồng
            borderColor: "rgba(255, 0, 0, 1)",
            borderWidth: 1,
          },
        ],
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });

    // Cleanup khi component unmount
    return () => {
      chart.destroy();
    };
  }, [data, profitData]);

  return (
    <div>
      <h2>{title}</h2>
      <canvas ref={chartRef} style={{ minWidth: 1070 }} />
    </div>
  );
};

export default RevenueChart;
