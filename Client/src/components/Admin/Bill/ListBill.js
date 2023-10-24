import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './Bill.scss';
import { useNavigate } from 'react-router-dom';
const ListBill = (props) => {
  const [data, setData] = useState([]);
  const [show, setShow] = useState(false);
  const navigate = useNavigate();
  useEffect(() => {
    axios
      .get('/api/hoadon')
      .then((response) => {
        setData(response.data);
        console.log(response.data);

      })
      .catch((error) => {
        console.error(error);
      });
  }, []);

  const handleCheck = (id) => {
    axios.put(`http://localhost:8000/api/hoadon/${id}`);
    axios.put(`/api/ship/${id}`);
    setData(data.filter((data) => data.MaHD !== id));
  };
  const handleDelete = (id) => {
    axios.put(`http://localhost:8000/api/delete/${id}`);
    setData(data.filter((data) => data.MaHD !== id));
    axios.put(`/api/deletes/${id}`);
  };

  return (
    <div className="container">
      {/* <div className='mb-3'>
                <button class="btn btn-navbar" type="button" onClick={(e) => handleAddProduct(e)}>
                    <i class="fas fa-plus"></i>Thêm hoá đơn
                </button>
            </div> */}
      <div id="list-bill" style={{ width: "100%" }}>
        <table className="table table-striped">
          <thead>
            <tr className='text-center'>
              <th>Mã hoá đơn</th>
              <th>Tên khách hàng</th>
              <th>Số điện thoại</th>
              <th>Ngày lập hoá đơn</th>
              <th>Tổng tiền</th>
              <th>Ghi chú</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {data.map((item) => (
              <tr key={item.MaHD} className='text-center'>
                {item.TinhTrang == 'Chưa check' && (
                  <>
                    <td
                      onClick={() => {
                        setShow(show ? false : true);
                        localStorage.removeItem('mahd');
                        localStorage.setItem('mahd', item.MaHD);
                        navigate('/admin/list-bills');
                      }}
                      style={{
                        cursor: 'pointer',
                        color: 'red',
                        fontWeight: 900,
                      }}
                    >
                      #{item.MaHD}
                    </td>
                    <td>{item.TenKH}</td>
                    <td>{item.SDT}</td>
                    <td>{item.formattedDateTime}</td>
                    <td>{item.TongTien}</td>
                    <td>{item.GhiChu}</td>
                    <td>
                      <button
                        onClick={() => handleCheck(item.MaHD)}
                        className="btn btn-danger mr-2"
                      >
                        Xác nhận <i class="fas fa-check"></i>
                      </button>
                      <button
                        onClick={() => handleDelete(item.MaHD)}
                        className="btn btn-danger"
                      >
                        Huỷ
                      </button>
                    </td>
                  </>
                )}
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default ListBill;
