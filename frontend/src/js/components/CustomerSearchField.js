import React, { useState } from "react";
import { useCustomerSearchOptions } from "../hooks/useCustomerSearchOptions.js";

export const CustomerSearchField = () => {
    const [refreshTimeout, setRefreshTimeout] = useState(null);
    const {searchOptions, setSearchOptions} = useCustomerSearchOptions();

    // after 100 ms with no changes, perform search
    const onChange = (event) => {
        if (refreshTimeout) {
            clearTimeout(refreshTimeout);
            setRefreshTimeout(null);
        }

        const newTimeout = setTimeout(() => {
            searchOptions.name = event.target.value;
            setSearchOptions(searchOptions);
        }, 100);
    
        setRefreshTimeout(newTimeout);
    };

    return (
        <input type="text" onChange={onChange} />
    );
};
