import React from "react";
import axios from "axios";

const Delivering = () => {
    return (
        <div className='container'>
            {/* <div className='mb-3'>
                <button class="btn btn-navbar" type="button" onClick={(e) => handleAddProduct(e)}>
                    <i class="fas fa-plus"></i>Thêm hoá đơn
                </button>
            </div> */}
            <div  >
                <table className="table table-striped">
                    <thead>
                        <tr>

                            <th>Mã hoá đơn</th>
                            <th>Mã khách hàng</th>
                            <th>Ngày lập hoá đơn</th>
                            <th>Khuyến mãi</th>
                            <th>Tổng tiền</th>
                            <th>Ghi chú</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.map(item => (
                            <tr key={item.MaHD}   >

                                {item.TinhTrang == "Chưa check" &&
                                    <>
                                        <td
                                            onClick={() => {
                                                setShow(show ? false : true)
                                                localStorage.removeItem('mahd');
                                                { localStorage.setItem('mahd', item.MaHD) }
                                                navigate('/admin/list-bills')
                                            }}
                                            style={{ cursor: 'pointer', color: 'red', fontWeight: 900 }}
                                        >
                                            {item.MaHD}</td>
                                        <td>{item.MaKH}</td>
                                        <td>{item.formattedDateTime}</td>
                                        <td>{item.KhuyenMai}</td>
                                        <td>{item.TongTien}</td>
                                        <td>{item.GhiChu}</td>
                                        <td className='check'><button onClick={() => handleCheck(item.MaHD)
                                        } className='btn'>Check <i class="fas fa-check"></i></button></td>
                                    </>

                                }

                            </tr>
                        ))}

                    </tbody>
                </table>
            </div>

        </div>
    )
}

export default Delivering;