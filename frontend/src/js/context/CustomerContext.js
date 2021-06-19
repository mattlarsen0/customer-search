import React from "react";

export const CustomerContext = React.createContext({
    customers: [],
    searchOptions: {
        name: "",
        companyName: ""
    }
});