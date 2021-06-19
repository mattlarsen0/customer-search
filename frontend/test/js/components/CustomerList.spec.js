import { CustomerList } from "../../../src/js/components/CustomerList.js";
import React from "react";
import { render } from "@testing-library/react";
import "@testing-library/jest-dom/extend-expect";

const testCustomer1 = {
    id: 1,
    firstName: "first1",
    lastName: "last1",
    companyName: "company1"
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
        customers: [testCustomer1, testCustomer2, testCustomer3],
        fetchAndSetCustomers: jest.fn()
    }),
    __esModule: true
}));

test("basic render - matches snapshot", () => {
    expect(render(<CustomerList />)).toMatchSnapshot();
});
