import { useContext } from "react";
import { CustomerContext } from "../context/CustomerContext.js";

export const useCustomerSearchOptions = () => {
    const customerContext = useContext(CustomerContext);

    return {
        searchOptions: customerContext.searchOptions,
        setSearchOptions: customerContext.setSearchOptions
    };
};
