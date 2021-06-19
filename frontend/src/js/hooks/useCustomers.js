import { useContext } from "react";
import { CustomerContext } from "../context/CustomerContext.js";

export const useCustomers = () => {
    const customerContext = useContext(CustomerContext);

    return {
        customers: customerContext.customers,
        fetchAndSetCustomers: customerContext.fetchAndSetCustomers
    };
};
