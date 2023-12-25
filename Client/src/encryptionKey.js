import React, { createContext } from "react";

export const MyContext = createContext();

export const MyContextProvider = ({ children }) => {
  const encryptionKey = "violet110";

  const contextValue = {
    encryptionKey,
  };

  return (
    <MyContext.Provider value={contextValue}>{children}</MyContext.Provider>
  );
};
