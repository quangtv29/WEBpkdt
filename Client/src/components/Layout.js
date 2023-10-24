import React from "react";
import { Outlet } from "react-router-dom";
import Footer from "./Footer";
import Header from "./Header";
import { CartProvider } from "../CartContext";
import { MyContextProvider } from "../encryptionKey";
const Layout = () => {
  return (
    <>
      <MyContextProvider>
        <CartProvider>
          <Header />
          <Outlet />
          <Footer />
        </CartProvider>
      </MyContextProvider>
    </>
  );
};

export default Layout;
