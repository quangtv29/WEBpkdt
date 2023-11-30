import React from "react";
import { Outlet } from "react-router-dom";
import Footer from "./Footer";
import Header from "./Header";
import { CartProvider } from "../CartContext";
import { MyContextProvider } from "../encryptionKey";
import { SearchProvider } from "../SearchContext";
const Layout = () => {
  return (
    <>
      <SearchProvider>
        <MyContextProvider>
          <CartProvider>
            <Header />
            <Outlet />
            <Footer />
          </CartProvider>
        </MyContextProvider>
      </SearchProvider>
    </>
  );
};

export default Layout;
