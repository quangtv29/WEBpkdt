import BreadCrumb from "../components/BreadCrumb";
import Meta from "../components/Meta";
import Container from "../components/Container";
import { React, useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { toast } from "react-toastify";
const Signup = () => {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [phoneNumber, setPhone] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const [email, setEmail] = useState("");
  const [isEmailValid, setIsEmailValid] = useState(false);
  const navigate = useNavigate();
  const [checkuser, setCheckUser] = useState("");
  const validateEmail = (value) => {
    // Biểu thức chính quy để kiểm tra định dạng email
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    const isValid = emailRegex.test(value);
    setIsEmailValid(isValid);
  };
  const checkUserName = (event) => {
    event.preventDefault();
    axios
      .post("https://localhost:7295/api/Authentication/checkUserId", {
        userName,
      })
      .then((res) => {
        if (res.data.data === -1) {
          setErrorMessage("Tài khoản đã tồn tại");
        } else if (res.data.data === 0) {
          setCheckUser("null");
        } else {
          setErrorMessage("");
        }
      })
      .catch((err) => {
        console.error(err);
      });
  };
  const [checkPW, setcheckPW] = useState(true);
  const checkPassword = (event, value) => {
    event.preventDefault();
    if (value >= 8) {
      setErrorMessage("");
    } else {
      setcheckPW(false);
      setErrorMessage("Mật khẩu phải có tối thiểu 8 kí tự.");
    }
  };
  const [border, setBorder] = useState([true, true, true, true, true, true]);
  const handleSubmit = (event) => {
    event.preventDefault();
    if (
      firstName === "" ||
      lastName === "" ||
      userName === "" ||
      password === "" ||
      phoneNumber === "" ||
      checkuser === "exists" ||
      checkuser === "null" ||
      checkPW === false
    ) {
      var a = [...border];
      if (firstName === "") {
        a[0] = false;
      }
      if (lastName === "") {
        a[1] = false;
      }
      if (userName === "") {
        a[2] = false;
      }
      if (phoneNumber === "") {
        a[3] = false;
      }
      if (password === "" || checkPW === false) {
        a[4] = false;
      }
      if (email === "") {
        a[5] = false;
      }
      setBorder(a);
      setErrorMessage("Vui lòng nhập đầy đủ thông tin.");
      return false;
    }
    validateEmail(email);
    if (isEmailValid) {
      axios
        .post("https://localhost:7295/api/Authentication", {
          firstName,
          lastName,
          userName,
          password,
          email,
          phoneNumber,
        })
        .then((res) => {
          let id = res.data.id;
          axios
            .post("https://localhost:7295/api/Customer/createCustomer", {
              id,
            })
            .then(() => {});
          setErrorMessage("");
          toast("Đăng kí tài khoản thành công");
          setTimeout(function () {
            navigate("/login", { replace: true });
          }, 4000);
        })
        .catch((err) => {
          alert("Lỗi");
          return false;
        });
      return true;
    } else {
      setErrorMessage("Email không đúng định dạng.");
    }
  };

  return (
    <>
      <Meta title={"Sign Up"} />
      <BreadCrumb title="Sign Up" />
      <Container class1="login-wrapper py-5 home-wrapper-2">
        <div className="row">
          <div className="col-12">
            <div className="auth-card" style={{ style: "relative" }}>
              <h3 className="text-center mb-3">Sign Up</h3>
              {errorMessage && (
                <p
                  style={{
                    color: "red",
                    marginTop: 0,
                    marginBottom: 10,
                    fontSize: 16,
                    textAlign: "center",
                  }}
                >
                  {errorMessage}
                </p>
              )}

              <form
                action=""
                className="d-flex flex-column gap-15"
                style={{ position: "relative" }}
              >
                <input
                  type="text"
                  value={firstName}
                  name="firstName"
                  placeholder="Họ"
                  className="form-control mt-2"
                  onChange={(e) => {
                    return setFirstName(e.target.value);
                  }}
                  style={{
                    borderColor: !border[0] ? "red" : "",
                  }}
                  onBlur={(e) => {
                    e.preventDefault();
                    if (firstName !== "") {
                      var a = [...border];
                      a[0] = true;
                      setBorder(a);
                    }
                  }}
                />

                <input
                  type="text"
                  value={lastName}
                  name="lastName"
                  placeholder="Tên"
                  className="form-control mt-1"
                  onChange={(e) => {
                    return setLastName(e.target.value);
                  }}
                  style={{
                    borderColor: !border[1] ? "red" : "",
                  }}
                  onBlur={(e) => {
                    e.preventDefault();
                    if (lastName !== "") {
                      var a = [...border];
                      a[1] = true;
                      setBorder(a);
                    }
                  }}
                />
                <input
                  type="text"
                  value={userName}
                  name="userName"
                  placeholder="Tài khoản"
                  className="form-control mt-1"
                  onChange={(e) => setUserName(e.target.value)}
                  onBlur={(e) => {
                    checkUserName(e);
                  }}
                  style={{
                    borderColor: !border[2] ? "red" : "",
                  }}
                />

                <input
                  type="tel"
                  name="phoneNumber"
                  placeholder="Số điện thoại"
                  className="form-control mt-1"
                  value={phoneNumber}
                  onChange={(e) => setPhone(e.target.value)}
                  style={{
                    borderColor: !border[3] ? "red" : "",
                  }}
                  onBlur={(e) => {
                    e.preventDefault();
                    if (phoneNumber !== "") {
                      var a = [...border];
                      a[3] = true;
                      setBorder(a);
                    }
                  }}
                />

                <input
                  type="password"
                  name="password"
                  placeholder="Mật khẩu"
                  className="form-control mt-1"
                  value={password}
                  onChange={(e) => {
                    setPassword(e.target.value);
                    checkPassword(e, e.target.value.length);
                  }}
                  style={{
                    borderColor: !border[4] ? "red" : "",
                  }}
                />
                <input
                  type="email"
                  name="email"
                  placeholder="Email"
                  className="form-control mt-1"
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                  style={{
                    borderColor: !border[5] ? "red" : "",
                  }}
                  onBlur={(e) => {
                    e.preventDefault();
                    if (email !== "") {
                      var a = [...border];
                      a[5] = true;
                      setBorder(a);
                    }
                  }}
                />
                <div>
                  <div className="mt-3 d-flex justify-content-center gap-15 align-items-center">
                    <button
                      className="button border-0"
                      onClick={(e) => handleSubmit(e)}
                    >
                      Sign Up
                    </button>
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

export default Signup;
