import React from "react";

export const CustomerRow = (props) => {
    const {firstName, lastName, companyName} = props.customer;
    
    return (
        <div className="customer-list-row">
            <div className="customer-name">
                Name: {firstName} {lastName}
            </div>
            <div className="customer-company-name">
                Company: {companyName}
            </div>
        </div>
    );
};
