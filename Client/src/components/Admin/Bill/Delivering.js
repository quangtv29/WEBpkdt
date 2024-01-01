import React, { useState, useEffect } from "react";
import axios from "axios";
import "./Bill.scss";
import { Link } from "react-router-dom";

const Delivering = () => {
  const [data, setData] = useState([]);
  const accessToken = localStorage.getItem("accessToken");
  const [currentPage, setCurrentPage] = useState(1);
  const itemsPerPage = 5;
  const [totalPage, setTotalPage] = useState(0);

  useEffect(() => {
    axios.defaults.headers.common["Authorization"] = `Bearer ${accessToken}`;
    axios
      .post(
        `https://localhost:7295/api/Bill/getAll`,
        {
          pageNumber: currentPage,
          pageSize: itemsPerPage,
        },
        {
          params: {
            Status: 1,
          },
        }
      )
      .then((response) => {
        setData(response.data.data);
        setTotalPage(Math.ceil(response.data.totalPage / itemsPerPage));
      });
  }, [currentPage, accessToken]);
  const handlePageChange = (selectedPage) => {
    setCurrentPage(selectedPage);
  };

  const confirm = (id) => {
    axios
      .post(
        "https://localhost:7295/api/Bill/updateStatusBill",
        {},
        {
          params: {
            id: id,
            status: 0,
          },
        }
      )
      .then(() => {
        setData(data.filter((item) => item.id !== id));
        alert("Xác nhận đơn hàng thành công");
      })
      .catch((error) => {
        alert("Xác nhận đơn hàng thất bại");
      });
  };

  return (
    <div className="container">
      <div id="list-bill" style={{ width: "100%" }}>
        <table className="table table-striped">
          <thead>
            <tr className="text-center">
              <th>Mã hoá đơn</th>
              <th>Tên tài khoản</th>
              <th>Tên người nhận</th>
              <th>Địa chỉ</th>
              <th>Số điện thoại</th>
              <th>Thời gian đặt hàng</th>
              <th>Tạm tính</th>
              <th>Giảm giá</th>
              <th>Tổng tiền</th>
              <th>Ghi chú </th>
              <th>Thao tác</th>
            </tr>
          </thead>
          <tbody>
            {data.map((item, index) => (
              <tr key={item?.id} className="text-center ">
                <>
                  <td
                    style={{
                      maxWidth: "100px",
                      whiteSpace: "pre-line",
                      wordWrap: "break-word",
                      cursor: "pointer  ",
                    }}
                    onClick={() => {
                      localStorage.setItem("billid11", item.id);
                    }}
                  >
                    <Link
                      to="../orderDetaila"
                      style={{
                        maxWidth: "100px",
                        whiteSpace: "pre-line",
                        wordWrap: "break-word",
                      }}
                      className="text-danger"
                    >
                      {index + 1}
                    </Link>
                  </td>
                  <td
                    style={{
                      maxWidth: "100px",
                      whiteSpace: "pre-line",
                      wordWrap: "break-word",
                    }}
                  >
                    {item?.userName}
                  </td>
                  <td
                    style={{
                      maxWidth: "100px",
                      whiteSpace: "pre-line",
                      wordWrap: "break-word",
                    }}
                  >
                    {item?.name}
                  </td>
                  <td
                    style={{
                      maxWidth: "100px",
                      whiteSpace: "pre-line",
                      wordWrap: "break-word",
                    }}
                  >
                    {item?.address}
                  </td>
                  <td>{item?.phoneNumber}</td>
                  <td>{item?.formatDate}</td>
                  <td>
                    {item?.totalMoney?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </td>
                  <td>
                    {item?.discount?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                  </td>
                  <td>
                    {item?.intoMoney?.toLocaleString("vi-VN", {
                      style: "currency",
                      currency: "VND",
                    })}
                    {item?.discountCode === "Done" && <p>(Đã thanh toán)</p>}
                  </td>
                  <td
                    style={{
                      maxWidth: "100px",
                      whiteSpace: "pre-line",
                      wordWrap: "break-word",
                    }}
                  >
                    {item?.GhiChu}
                  </td>
                  <td className="check">
                    <button
                      onClick={() => confirm(item?.id)}
                      className="btn mr-2"
                      style={{ backgroundColor: "blue" }}
                    >
                      Giao thành công <i className="fas fa-check"></i>
                    </button>
                  </td>
                </>
              </tr>
            ))}
          </tbody>
        </table>
        <div className="pagination mb-3">
          <button
            onClick={() => handlePageChange(currentPage - 1)}
            disabled={currentPage === 1}
          >
            Trang trước
          </button>
          <button
            onClick={() => handlePageChange(currentPage + 1)}
            disabled={currentPage === totalPage}
          >
            Trang tiếp theo
          </button>
          <span className="mt-2">
            {" "}
            {currentPage} / {totalPage}
          </span>
        </div>
      </div>
    </div>
  );
};

export default Delivering;
