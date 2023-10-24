import { React, useEffect, useState } from "react";
import { Link, Outlet } from "react-router-dom";


const Headers = () => {
    return (
        <>
            <div className="container-fluid">
                <div className="row">
                    <div className="col-md-12" style={{ padding: "0px" }}>
                        <ul className="nav d-flex nav-justified bg-secondary " >
                            <li className="nav-item mr-4  ">
                                <Link to='/to-pay' className="nav-link  text-light">Chờ xác nhận</Link>
                            </li>
                            <li className="nav-item mr-4  ">
                                <Link to='/to-pay/to-deliveringg' className="nav-link text-light">Đang vận chuyển</Link>
                            </li>
                            <li className="nav-item mr-4 ">
                                <Link to='/to-pay/done' className="nav-link text-light">Hoàn thành</Link>
                            </li>
                            <li className="nav-item mr-4  ">
                                <Link to='/to-pay/to-cancel' className="nav-link text-light">Đã huỷ</Link>
                            </li>
                        </ul>
                        <Outlet />
                    </div>
                </div>
            </div>
        </>
    )
}

export default Headers;