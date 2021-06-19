import { useContext } from "react";
import { CustomerContext } from "../context/CustomerContext.js";

export const useCustomerSearchOptions = () => {
    var customerContext = useContext(CustomerContext);

    return {
        searchOptions: customerContext.searchOptions,
        setSearchOptions: customerContext.setSearchOptions
    };
};
