import React, { createContext, useState } from "react";

const SearchContext = createContext();

const SearchProvider = ({ children }) => {
  const [search, setSearch] = useState("");
  const [status, setStatus] = useState(false);
  const [record, setRecord] = useState();
  const [click, setClick] = useState(false);
  return (
    <SearchContext.Provider
      value={{
        search,
        setSearch,
        setStatus,
        status,
        record,
        setRecord,
        click,
        setClick,
      }}
    >
      {children}
    </SearchContext.Provider>
  );
};

export { SearchContext, SearchProvider };
