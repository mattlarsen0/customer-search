import React, { useEffect, useState } from "react";
import { CustomerContext } from "./context/CustomerContext.js";
import { CustomerList } from "./components/CustomerList.js";
import { fetchCustomers } from "./utils/fetchCustomers.js";
import { CustomerSearchField } from "./components/CustomerSearchField.js";
import { CompanyDropdown } from "./components/CompanyDropdown.js";

export const App = () => {
    const currentUrl = new URL(window.location);

    const [customerState, setCustomerState] = useState({
        customers: [],
        searchOptions: {
            name: currentUrl.searchParams.get("search") ?? "",
            companyName: currentUrl.searchParams.get("filter_by_company_name") ?? "",
        },
        setSearchOptions: () => {},
        fetchAndSetCustomers: () => {},
    });
    
    useEffect(() => {
        customerState.setSearchOptions = (searchOptions) => {
            customerState.searchOptions = searchOptions;
            updateCustomerList(searchOptions, customerState, setCustomerState);

            // Update url to reflect new search options
            let urlParams = {};

            if (searchOptions.name)
            {
                urlParams.search = searchOptions.name;
            }

            if (searchOptions.companyName)
            {
                urlParams.filter_by_company_name = searchOptions.companyName;
            }

            const url = new URL("https://localhost:5001/");
            url.search = new URLSearchParams(urlParams).toString();

            window.history.pushState({}, "Customer Search Demo", url);
        };

        customerState.fetchAndSetCustomers = (searchOptions) => {
            updateCustomerList(searchOptions, customerState, setCustomerState);
        };
 
        updateCustomerList(customerState.searchOptions, customerState, setCustomerState);
    }, []);

    return (
        <CustomerContext.Provider value={customerState}>
            <div>
                <label>Search: <CustomerSearchField /></label>
            </div>
            <div>
                <label>Filter by company: <CompanyDropdown /></label>
            </div>
            <CustomerList />
        </CustomerContext.Provider>
    );
};

const updateCustomerList = async (searchOptions, customerState, setCustomerState) => {
    const result = await fetchCustomers(searchOptions);
    customerState.customers = result.customers;
    setCustomerState({
        ...customerState
    });
};