import React from "react";
import { useCustomers } from "../hooks/useCustomers.js";
import { useCustomerSearchOptions } from "../hooks/useCustomerSearchOptions.js";

export const CompanyDropdown = () => {
    const {customers} = useCustomers();
    const {searchOptions, setSearchOptions} = useCustomerSearchOptions();

    var companies = [...new Set(customers.map(c => c.companyName))];

    var companyOptions = companies.map(c => (
        <option key={`company-${c}`} value={c}>{c}</option>
    ));

    const onChange = (event) => {
        searchOptions.companyName = event.target.value;
        setSearchOptions(searchOptions);
    };

    return (
        <select data-testid="select" onChange={onChange}>
            <option value="">None</option>
            {companyOptions}
        </select>
    );
};
