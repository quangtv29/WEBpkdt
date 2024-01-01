import React, { useState, useEffect } from "react";
import axios from "axios";
import "./Bill.scss";
import { Link } from "react-router-dom";
import Confirmm from "../../Confirm";

const ListBill = () => {
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
            Status: 3,
          },
        }
      )
      .then((response) => {
        setData(response.data.data);
        setTotalPage(Math.ceil(response.data.totalPage / itemsPerPage));
      });
  }, [currentPage]);
  const handlePageChange = (selectedPage) => {
    setCurrentPage(selectedPage);
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
        setData(data.filter((item) => item.id !== id));

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
  const [isOpen, setIsOpen] = useState(false);
  const handleConfirm = () => {
    setIsOpen(false);
    setData(
      data.filter((item) => item.id !== localStorage.getItem("billid11"))
    );
    axios.post(
      "https://localhost:7295/api/Bill/updateStatusBill",
      {},
      {
        params: {
          Id: localStorage.getItem("billid11"),
          status: 2,
        },
      }
    );
  };
  const handleCancel = () => {
    setIsOpen(false);
    localStorage.removeItem("billid11");
  };
  const handleOnclick = (id) => {
    setIsOpen(true);
    localStorage.setItem("billid11", id);
  };
  return (
    <div className="container m-0" style={{ maxWidth: 1260 }}>
      <div id="list-bill" style={{ width: "100%" }}>
        <table className="table table-striped">
          <thead>
            <tr className="text-center">
              <th>Mã hoá đơn</th>
              <th>Tài khoản</th>
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
            {data?.map((item) => (
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
                      {item?.id}
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
                  <td
                    style={{
                      maxWidth: "115px",
                      whiteSpace: "pre-line",
                      wordWrap: "break-word",
                    }}
                  >
                    {item?.phoneNumber}
                  </td>
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
                      type="button"
                      onClick={() => confirm(item?.id, item?.customerID)}
                      className="btn btn-danger mr-2"
                      style={{ padding: 7 }}
                    >
                      Xác nhận <i className="fas fa-check"></i>
                    </button>
                    <button
                      type="button"
                      className="btn btn-danger mr-2 mt-2"
                      onClick={() => handleOnclick(item?.id)}
                      style={{ border: 0, width: 64.2, height: 53 }}
                    >
                      Huỷ
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
      {isOpen && (
        <Confirmm
          message="Bạn có chắc chắn muốn huỷ hoá đơn?"
          onConfirm={handleConfirm}
          onCancel={handleCancel}
        />
      )}
    </div>
  );
};

export default ListBill;
