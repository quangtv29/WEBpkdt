// CartContext.js
import React, { createContext, useEffect, useState } from 'react';

export const CartContext = createContext();

export const CartProvider = ({ children }) => {
  const [cartItems, setCartItems] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const addToCart = (item) => {
    const existItem = cartItems.find((x) => x.MaSP === item.MaSP);
    if (existItem) {
      setCartItems(
        cartItems.map((x) =>
          x.MaSP === item.MaSP
            ? {
                ...existItem,
                quantity:
                  parseInt(existItem.quantity, 10) +
                  parseInt(item.quantity, 10),
                prices:
                  parseInt(existItem.quantity, 10) * existItem.GiaBan +
                  parseInt(item.quantity, 10) * existItem.GiaBan,
              }
            : x
        )
      );
    } else {
      setCartItems([...cartItems, { ...item }]);
    }
  };

  const removeFromCart = (item) => {
    const newCartItems = cartItems.filter((x) => x.MaSP !== item.MaSP);
    console.log(item);
    setCartItems(newCartItems);
  };

  const updateCart = (item, updatedQuantity) => {
    const updatedCartItems = cartItems.map((x) =>
      x.MaSP === item.MaSP
        ? {
            ...x,
            quantity: updatedQuantity,
            prices: parseInt(x.GiaBan, 10) * updatedQuantity,
          }
        : x
    );
    setCartItems(updatedCartItems);
  };

  const totalPrice = cartItems.reduce(
    (acc, item) => acc + parseInt(item.prices),
    0
  );

  const cartCount = cartItems.reduce(
    (acc, item) => acc + parseInt(item.quantity, 10),
    0
  );

  useEffect(() => {
    const storedCartItems = localStorage.getItem('cartItems');
    if (storedCartItems) {
      setCartItems(JSON.parse(storedCartItems));
    }
  }, []);

  useEffect(() => {
    localStorage.setItem('cartItems', JSON.stringify(cartItems));
  }, [cartItems]);

  return (
    <CartContext.Provider
      value={{
        cartItems,
        addToCart,
        removeFromCart,
        updateCart,
        cartCount,
        totalPrice,
        searchTerm,
        setSearchTerm,
      }}
    >
      {children}
    </CartContext.Provider>
  );
};
