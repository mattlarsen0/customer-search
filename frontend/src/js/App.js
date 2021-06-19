import React, { useEffect, useState } from "react";
import { CustomerContext } from "./context/CustomerContext.js";
import { CustomerList } from "./components/CustomerList.js";
import { fetchCustomers } from "./utils/fetchCustomers.js";
import { CustomerSearchField } from "./components/CustomerSearchField.js";
import { CompanyDropdown } from "./components/CompanyDropdown.js";

export const App = () => {
    const [customerState, setCustomerState] = useState({
        customers: [],
        searchOptions: {
            name: "",
            companyName: ""
        },
        setSearchOptions: () => {},
        fetchAndSetCustomers: () => {},
    });
    
    useEffect(() => {
        customerState.setSearchOptions = (searchOptions) => {
            customerState.searchOptions = searchOptions;
            updateCustomerList(searchOptions, customerState, setCustomerState);
        };

        customerState.fetchAndSetCustomers = (searchOptions) => {
            updateCustomerList(searchOptions, customerState, setCustomerState);
        };
 
        updateCustomerList(customerState.searchOptions, customerState, setCustomerState);
    }, []);

    return (
        <CustomerContext.Provider value={customerState}>
            <div>
                <label>Search<CustomerSearchField /></label>
            </div>
            <div>
                <CompanyDropdown />
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