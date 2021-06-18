import { CustomerRow } from "../../../src/js/components/CustomerRow.js";
import React from "react";
import { render, screen } from "@testing-library/react";
import "@testing-library/jest-dom/extend-expect";

const testCustomer = {
    id: 1,
    firstName: "first",
    lastName: "last",
    companyName: "company"
};

test("basic render - matches snapshot", () => {
    expect(render(<CustomerRow customer={testCustomer} />)).toMatchSnapshot();
});

test("contains first and last name", () => {
    render(<CustomerRow customer={testCustomer} />);
    const name = screen.getByText(`Name: ${testCustomer.firstName} ${testCustomer.lastName}`);
    expect(name).toBeDefined();
});

test("contains company name", () => {
    render(<CustomerRow customer={testCustomer} />);
    const name = screen.getByText(`Company: ${testCustomer.companyName}`);
    expect(name).toBeDefined();
});
