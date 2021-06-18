import React from "react";
import { useCustomers } from "../hooks/useCustomers.js";
import { CustomerRow } from "./CustomerRow.js";

export const CustomerList = () => {
    const {customers} = useCustomers();
    
    return (
        <div className="customer-list">
            {customers.map(c => <CustomerRow key={c.id} customer={c} />)}
        </div>
    );
};
