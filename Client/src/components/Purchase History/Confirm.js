import React, { useEffect, useState } from "react";
import axios from "axios";

const Confirm = () => {
  const MaKH = localStorage.getItem("id");
  const [data, setData] = useState([]);
  useEffect(() => {
    axios
      .get(`https://localhost:7295/api/OrderDetail/history?CustomerId=${MaKH}`)
      .then((response) => {
        setData(response.data);
        console.log(response.data);
      })
      .catch((err) => {
        console.error(err);
      });
  }, []);

  const handleCancel = (id) => {
    axios
      .put(`/api/cancel/${id}`)
      .then(() => {
        setData(
          data.filter((dt) => {
            return dt.MaCTHD !== id;
          })
        );
      })
      .catch((err) => {
        console.error(err);
      });
  };
  return (
    <>
      <div className="container-fuild">
        <ul style={{ padding: "0px", minHeight: 350 }}>
          {data.map((item) => (
            <div key={item.MaCTHD}>
              {item.TinhTrang !== null || (
                <li className="row d-flex align-items-center mt-2 border ">
                  <div className="col-1 d-flex justify-content-center ">
                    #{item.MaCTHD}
                  </div>
                  <div className="col-1">
                    <img
                      src={item.imageUrl}
                      alt={item.TenSP}
                      className="w-100"
                    />
                  </div>
                  <div className="col-2 font-weight-bold  d-flex justify-content-center ">
                    {item.TenSP}
                  </div>
                  <div className="col-1" style={{ color: "#ee4d2d" }}>
                    {item.moneyy}
                  </div>
                  <div className="col-1" style={{ color: "rgba(0,0,0,.87)" }}>
                    x{item.SoLuong}
                  </div>
                  <div className="col-2">
                    Ngày đặt hàng <br />
                    {item.formattedDateTime}
                  </div>
                  <div className="col-2 d-flex justify-content-center">
                    <p>Tổng tiền :</p>
                    <p
                      className="font-weight-bold"
                      style={{ color: "#ee4d2d" }}
                    >
                      130.000.000 {item.TongTienCTHD}
                    </p>
                    {item.TongTienCTHD}
                  </div>
                  <div className="col-2 d-flex justify-content-center">
                    <button
                      type="button"
                      className="btn btn-danger"
                      onClick={() => handleCancel(item.MaCTHD)}
                    >
                      Huỷ
                    </button>
                  </div>
                </li>
              )}
            </div>
          ))}
        </ul>
      </div>
    </>
  );
};

export default Confirm;
