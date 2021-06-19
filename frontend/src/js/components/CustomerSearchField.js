import React from "react";
import { useCustomerSearchOptions } from "../hooks/useCustomerSearchOptions.js";

export const CustomerSearchField = () => {
    const {searchOptions, setSearchOptions} = useCustomerSearchOptions();

    const onChange = (event) => {
        searchOptions.name = event.target.value;
        setSearchOptions(searchOptions);
    };

    return (
        <input type="text" onChange={onChange} />
    );
};
