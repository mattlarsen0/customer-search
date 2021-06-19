import { CompanyDropdown } from "../../../src/js/components/CompanyDropdown.js";
import React from "react";
import { render, screen, fireEvent } from "@testing-library/react";
import "@testing-library/jest-dom/extend-expect";

const mockSetSearchOptions = jest.fn();

jest.mock("../../../src/js/hooks/useCustomerSearchOptions.js", () => ({
    useCustomerSearchOptions: () => ({
        searchOptions: {
            name: "",
            companyName: ""
        },
        setSearchOptions: mockSetSearchOptions
    }),
    __esModule: true
}));

const testCompanyName = "test company";
const testCustomer1 = {
    id: 1,
    firstName: "first1",
    lastName: "last1",
    companyName: "test company"
};

const testCustomer2 = {
    id: 2,
    firstName: "first2",
    lastName: "last2",
    companyName: "company2"
};

const testCustomer3 = {
    id: 3,
    firstName: "first3",
    lastName: "last3",
    companyName: "company3"
};

jest.mock("../../../src/js/hooks/useCustomers.js", () => ({
    useCustomers: () => ({
        customers: [testCustomer1, testCustomer2, testCustomer3]
    }),
    __esModule: true
}));

test("can render", () => {
    expect(render(<CompanyDropdown />)).toMatchSnapshot();
});

test("does call hook on change", (done) => {
    render(<CompanyDropdown />);
    const companySelect = screen.getByTestId("select");

    fireEvent.change(companySelect, { target: { value: testCompanyName } });

    setTimeout(() => {
        expect(mockSetSearchOptions).toHaveBeenCalledWith({
            name: "",
            companyName: testCompanyName
        });
        expect(mockSetSearchOptions).toHaveBeenCalledTimes(1);
        done();
    }, 100);
});
