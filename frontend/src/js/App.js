import React, { useState } from "react";
import { CustomerContext } from "./context/CustomerContext.js";
import { CustomerList } from "./components/CustomerList.js";

export const App = () => {
    const [customerState] = useState({
        customers: []
    });

    return (
        <CustomerContext.Provider value={customerState}>
            <CustomerList />
        </CustomerContext.Provider>
    );
};