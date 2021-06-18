import { useContext } from "react";
import { CustomerContext } from "../context/CustomerContext.js";

export const useCustomers = () => {
    var customerContext = useContext(CustomerContext);

    return {
        customers: customerContext.customers
    };
};
