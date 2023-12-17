import React from "react";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./components/Layout";
import Home from "./views/Home";
import About from "./views/About";
import Contact from "./views/Contact";
import OurStore from "./views/OurStore";
import Blog from "./views/Blog";
import CompareProduct from "./views/CompareProduct";
import Wishlist from "./views/Wishlist";
import Login from "./views/Login";
import Forgotpassword from "./views/Forgotpassword";
import Signup from "./views/Signup";
import Resetpassword from "./views/Resetpassword";
import SingleBlog from "./views/SingleBlog";
import PrivacyPolicy from "./views/PrivacyPolicy";
import RefundPloicy from "./views/RefundPloicy";
import ShippingPolicy from "./views/ShippingPolicy";
import TermAndContions from "./views/TermAndContions";
import SingleProduct from "./views/SingleProduct";
import Cart from "./views/Cart";
import Checkout from "./views/Checkout";
import ListProduct from "./components/Admin/Product/ListProduct";
import LayoutAdmin from "./components/Admin/LayoutAdmin/LayoutAdmin";
import ListBill from "./components/Admin/Bill/ListBill";
import ListTypeProduct from "./components/Admin/ListTypeProduct/ListTypeProduct";
import ListBills from "./components/Admin/Bill/ListBills";
import { CartProvider } from "./CartContext";
import Confirm from "./components/Purchase History/Confirm";
import Headers from "./components/Purchase History/Header";
import Canceled from "./components/Purchase History/Canceled";
import Deliveringg from "./components/Purchase History/Deliveringg";
import Done from "./components/Purchase History/Done";
import Profile from "./views/Profile";
import OrderDetail from "./components/Purchase History/OrderDetail";
import Statistics from "./components/Admin/Statistics/Statistics";
import { MyContextProvider } from "./encryptionKey";
import { Navigate } from "react-router-dom";
import Delivering from "./components/Admin/Bill/Delivering";
function App() {
  // const u = JSON.parse(localStorage.getItem('user'));
  const AdminRoute = ({ element }) => {
    if (localStorage.getItem("chucvu") !== "Manager") {
      // Nếu không phải là admin, chuyển hướng hoặc thực hiện xử lý khác
      return <Navigate to="/error-page" />;
    }

    return element;
  };
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route index element={<Home />} />
            <Route path="about" element={<About />} />
            <Route path="profile" element={<Profile />} />
            <Route path="contact" element={<Contact />} />
            <Route path="product" element={<OurStore />} />
            <Route path="product/:id" element={<SingleProduct />} />
            <Route path="product/?search=:search" element={<OurStore />} />
            <Route path="blogs" element={<Blog />} />
            <Route path="blog/:id" element={<SingleBlog />} />
            <Route path="cart" element={<Cart />} />
            <Route path="checkout" element={<Checkout />} />
            <Route path="compare-product" element={<CompareProduct />} />
            <Route path="wishlist" element={<Wishlist />} />
            <Route path="login" element={<Login />} />
            <Route path="forgot-password" element={<Forgotpassword />} />
            <Route path="signup" element={<Signup />} />
            <Route path="reset-password" element={<Resetpassword />} />
            <Route path="privacy-policy" element={<PrivacyPolicy />} />
            <Route path="refund-policy" element={<RefundPloicy />} />
            <Route path="shipping-policy" element={<ShippingPolicy />} />
            <Route path="term-conditions" element={<TermAndContions />} />
            <Route path="to-pay" element={<Headers />}>
              <Route index element={<Confirm />} />
              <Route path="to-cancel" element={<Canceled />} />
              <Route path="to-deliveringg" element={<Deliveringg />} />
              <Route path="done" element={<Done />} />
              <Route path="orderDetail" element={<OrderDetail />} />
            </Route>
          </Route>
        </Routes>
      </BrowserRouter>
      <MyContextProvider>
        <BrowserRouter>
          <Routes>
            <Route
              path="/admin"
              element={<AdminRoute element={<LayoutAdmin />} />}
            >
              <Route index element={<ListProduct />} />
              <Route path="list-product" element={<ListProduct />} />
              {/* <Route path="create-product" element={<CreateProduct />} /> */}
              <Route path="list-bill" element={<ListBill />} />
              <Route path="list-type-product" element={<ListTypeProduct />} />
              <Route path="list-bills" element={<ListBills />} />
              <Route path="delivering" element={<Delivering />} />
              <Route path="statistics" element={<Statistics />} />
              <Route path="orderDetaila" element={<OrderDetail />} />
            </Route>
          </Routes>
        </BrowserRouter>
      </MyContextProvider>
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="light"
      />
      {/* Same as */}
      <ToastContainer />
    </>
  );
}

export default App;
