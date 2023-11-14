import { Link } from "react-router-dom";
import BreadCrumb from "../components/BreadCrumb";
import Meta from "../components/Meta";
import Container from "../components/Container";
import axios from "axios";
import React, { useContext, useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEye, faEyeSlash } from "@fortawesome/free-solid-svg-icons";
import { useNavigate } from "react-router-dom";
import CryptoJS from "crypto-js";
import { MyContext } from "../encryptionKey";

const Login = () => {
  const [Username, setUsername] = useState("");
  const [Password, setPassword] = useState("");
  const [login, setLogin] = useState(true);
  const { encryptionKey } = useContext(MyContext);
  const handleSubmit = (event) => {
    event.preventDefault();
    axios
      .post("https://localhost:7295/api/Authentication/login", {
        Username,
        Password,
      })
      .then((response) => {
        if (response.data.role[0] === "Manager") {
          const accessToken = response.data.data.accessToken;
          const encryptedId = CryptoJS.AES.encrypt(
            response.data.user.id,
            encryptionKey
          ).toString();
          localStorage.setItem("accessToken", accessToken);
          document.cookie = `accessToken=${accessToken}; path=/; HttpOnly`;
          localStorage.setItem("refreshToken", response.data.data.refreshToken);
          localStorage.setItem(
            "lastname",
            response.data.user.firstName + " " + response.data.user.lastName
          );
          localStorage.setItem("id", encryptedId);
          // navigate("/admin", { replace: true });
          window.location.href = "/admin";
        } else {
          const accessToken = response.data.data.accessToken;
          const encryptedId = CryptoJS.AES.encrypt(
            response.data.user.id,
            encryptionKey
          ).toString();
          localStorage.setItem("accessToken", accessToken);
          document.cookie = `accessToken=${accessToken}; path=/; HttpOnly`;
          localStorage.setItem("refreshToken", response.data.data.refreshToken);
          localStorage.setItem("id", encryptedId);
          axios.defaults.headers.common[
            "Authorization"
          ] = `Bearer ${accessToken}`;
          navigate("/", { replace: true });
        }
      })
      .catch((err) => {
        setLogin(false);
        console.error(err);
      });
  };

  const [status, setStatus] = useState(false);

  const isVisible = () => {
    setStatus(status ? false : true);
  };
  const navigate = useNavigate();

  useEffect(() => {
    // kiểm tra xem người dùng đã đăng nhập hay chưa
    const isLoggedIn = localStorage.getItem("id");

    if (isLoggedIn) {
      // nếu đã đăng nhập, chuyển hướng đến trangkhác
      navigate("/", { replace: true });
    }
  }, [navigate]);
  return (
    <>
      <Meta title={"Login"} />
      <BreadCrumb title="Login" />
      <Container class1="login-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-12">
            <div className="auth-card">
              <h3 className="text-center mb-3">Đăng nhập</h3>
              <form
                onSubmit={handleSubmit}
                action=""
                className="d-flex flex-column gap-15"
                name="formlogin"
              >
                <input
                  value={Username}
                  onChange={(e) => setUsername(e.target.value)}
                  type="text"
                  name="email"
                  placeholder="Tài khoản"
                  className=" form-control input"
                />
                <div
                  className="d-flex"
                  style={{ backgroundColor: "#F5F5F7", borderRadius: "10px" }}
                >
                  <input
                    value={Password}
                    onChange={(e) => setPassword(e.target.value)}
                    type={status ? "text" : "password"}
                    name="password"
                    placeholder="Mật khẩu"
                    className=" form-control input"
                    id="password"
                  />
                  <FontAwesomeIcon
                    style={{
                      marginTop: 18,
                      marginRight: 10,
                      cursor: "pointer",
                    }}
                    icon={status ? faEye : faEyeSlash}
                    onClick={isVisible}
                  />
                </div>
                <div>
                  {login || (
                    <p style={{ color: "red" }} className="text-center">
                      Sai tài khoản hoặc mật khẩu
                    </p>
                  )}
                  <Link to="/forgot-password">Forgot Password?</Link>
                  <div className="mt-3 d-flex justify-content-center gap-15 align-items-center">
                    <button
                      className="button border-0"
                      type="submit"
                      onClick={(e) => {
                        // e.preventDefault();
                      }}
                    >
                      Đăng nhập
                    </button>
                    <Link to="/signup" className="button signup">
                      Đăng ký
                    </Link>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </Container>
    </>
  );
};

export default Login;
