import React from "react";
import { useCustomers } from "../hooks/useCustomers.js";
import { useCustomerSearchOptions } from "../hooks/useCustomerSearchOptions.js";

export const CompanyDropdown = () => {
    const {customers} = useCustomers();
    const {searchOptions, setSearchOptions} = useCustomerSearchOptions();

    const allCompanyNames = customers.map(c => c.companyName).filter(c => c);

    const companies = [...new Set(allCompanyNames)];

    const companyOptions = companies.map(c => (
        <option key={`company-${c}`} value={c}>{c}</option>
    ));

    const onChange = (event) => {
        searchOptions.companyName = event.target.value;
        setSearchOptions(searchOptions);
    };

    return (
        <select data-testid="select" onChange={onChange}>
            <option value="">None Selected</option>
            {companyOptions}
        </select>
    );
};
