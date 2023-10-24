import BreadCrumb from "../components/BreadCrumb";
import Meta from "../components/Meta";
import Container from "../components/Container";
import { React, useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
const Signup = () => {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [phoneNumber, setPhone] = useState("");
  const [email, setEmail] = useState("");
  const navigate = useNavigate();
  const [checkuser, setCheckUser] = useState("");
  const checkInput = (e) => {
    e.preventDefault();
    if (
      firstName !== "" &&
      lastName !== "" &&
      email !== "" &&
      phoneNumber !== "" &&
      checkuser === "no" &&
      checkPW === true
    ) {
      setValidate(true);
    } else {
      setValidate(false);
    }
  };
  const checkUserName = (event) => {
    event.preventDefault();
    axios
      .post("https://localhost:7295/api/Authentication/checkUserId", {
        userName,
      })
      .then((res) => {
        if (res.data.data === -1) {
          setCheckUser("exists");
        } else if (res.data.data === 0) {
          setCheckUser("null");
        } else {
          setCheckUser("no");
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
      setcheckPW(true);
    } else {
      setcheckPW(false);
    }
  };

  const [validate, setValidate] = useState(true);
  const handleSubmit = (event) => {
    event.preventDefault();
    if (
      firstName === "" ||
      lastName === "" ||
      userName === "" ||
      password === "" ||
      email === "" ||
      phoneNumber === "" ||
      checkuser === "exists" ||
      checkuser === "null" ||
      checkPW === false
    ) {
      setValidate(false);
      return false;
    }
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
          .then(() => {
            console.log("done");
          });
        alert("Đăng kí tài khoản thành công");
        navigate("/login", { replace: true });
        setValidate(true);
      })
      .catch((err) => {
        console.error(err);
        setValidate(false);
        return false;
      });
    return true;
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
              {!validate && (
                <p
                  style={{
                    color: "red",
                    fontSize: 15,
                    margin: 0,
                    padding: 0,
                    position: "absolute",
                    top: 496,
                    left: 484,
                  }}
                >
                  Vui lòng nhập đầy đủ thông tin
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
                    borderColor: firstName === "" && !validate ? "red" : "",
                  }}
                  onBlur={checkInput}
                  // style={{ border: "1px solid red" }}
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
                    borderColor: lastName === "" && !validate ? "red" : "",
                  }}
                  onBlur={checkInput}
                />
                {checkuser === "exists" && (
                  <p
                    style={{
                      color: "red",
                      fontSize: 15,
                      margin: 0,
                      padding: 0,
                      position: "absolute",
                      left: -170,
                      bottom: 300,
                    }}
                  >
                    Tài khoản đã tồn tại -{">"}
                  </p>
                )}
                {!checkPW && (
                  <p
                    style={{
                      color: "red",
                      fontSize: 15,
                      margin: 0,
                      padding: 0,
                      position: "absolute",
                      left: -250,
                      bottom: 165,
                    }}
                  >
                    Mật khẩu phải từ 8 kí tự trở lên! -{">"}
                  </p>
                )}
                <input
                  type="text"
                  value={userName}
                  name="userName"
                  placeholder="Tài khoản"
                  className="form-control mt-1"
                  onChange={(e) => setUserName(e.target.value)}
                  onBlur={(e) => {
                    checkUserName(e);
                    checkInput(e);
                  }}
                  style={{
                    borderColor: userName === "" && !validate ? "red" : "",
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
                    borderColor: phoneNumber === "" && !validate ? "red" : "",
                  }}
                  onBlur={checkInput}
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
                    borderColor: password === "" && !validate ? "red" : "",
                  }}
                  onBlur={checkInput}
                />
                <input
                  type="text"
                  name="email"
                  placeholder="Email"
                  className="form-control mt-1"
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                  style={{
                    borderColor: email === "" && !validate ? "red" : "",
                  }}
                  onBlur={checkInput}
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
