import React, { useState, useEffect } from "react";
import axios from "axios";
import "./Bill.scss";
import { Link } from "react-router-dom";
import ReactPaginate from "react-paginate";

const ListBill = () => {
  const [data, setData] = useState([]);
  const accessToken = localStorage.getItem("accessToken");
  const [pageNumber, setPageNumber] = useState(0);
  const itemsPerPage = 4;
  const pageCount = Math.ceil(data.length / itemsPerPage);
  useEffect(() => {
    axios.defaults.headers.common["Authorization"] = `Bearer ${accessToken}`;
    axios
      .post(
        `https://localhost:7295/api/Bill/getAll`,
        {
          pageNumber: pageNumber + 1,
          pageSize: itemsPerPage,
        },
        {
          params: {
            Status: 3,
          },
        }
      )
      .then((response) => {
        setData(response.data.data);
      })
      .catch(() => {
        alert("lỗi");
      });
  }, [pageNumber, data]);
  const handlePageClick = (selectedPage) => {
    setPageNumber(selectedPage.selected);
  };

  const confirm = (id, customerid) => {
    axios
      .post(
        "https://localhost:7295/api/Bill/updateStatusBill",
        {},
        {
          params: {
            id: id,
            status: 1,
          },
        }
      )
      .then(() => {
        axios.post("https://localhost:7295/api/Notification/createNoti", {
          content: `Đơn hàng ${id} đã được xác nhận. Sản phẩm sẽ được giao đến bạn trong thời gian nhanh nhất.`,
          header: "Đơn hàng đã được xác nhận",
          customerID: customerid,
        });
        alert("Xác nhận đơn hàng thành công");
      })
      .catch(() => {
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
              <th>ID tài khoản</th>
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
            {data.map((item) => (
              <tr key={item.id} className="text-center ">
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
                      {item.id}
                    </Link>
                  </td>
                  <td
                    style={{
                      maxWidth: "100px",
                      whiteSpace: "pre-line",
                      wordWrap: "break-word",
                    }}
                  >
                    {item?.customerID}
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
                  <td>
                    <button
                      onClick={() => confirm(item?.id, item?.customerID)}
                      className="button mr-2"
                    >
                      Xác nhận <i className="fas fa-check"></i>
                    </button>
                  </td>
                </>
              </tr>
            ))}
          </tbody>
        </table>
        <ReactPaginate
          previousLabel={"Previous"}
          nextLabel={"Next"}
          pageCount={pageCount}
          onPageChange={handlePageClick}
          containerClassName={"pagination"}
          previousLinkClassName={"pagination__link"}
          nextLinkClassName={"pagination__link"}
          disabledClassName={"pagination__link--disabled"}
          activeClassName={"pagination__link--active"}
        />
      </div>
    </div>
  );
};

export default ListBill;
