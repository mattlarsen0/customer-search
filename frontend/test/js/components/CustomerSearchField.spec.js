import { CustomerSearchField } from "../../../src/js/components/CustomerSearchField.js";
import React from "react";
import { render, screen } from "@testing-library/react";
import "@testing-library/jest-dom/extend-expect";
import userEvent from "@testing-library/user-event";

const testName = "Test Name Entry";
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

test("can render", () => {
    expect(render(<CustomerSearchField />)).toMatchSnapshot();
});

test("does call hook on change", (done) => {
    render(<CustomerSearchField />);
    const input = screen.getByRole("textbox");

    userEvent.type(input, testName);

    setTimeout(() => {
        expect(mockSetSearchOptions).toHaveBeenCalledWith({
            name: testName,
            companyName: ""
        });
        expect(mockSetSearchOptions).toHaveBeenCalledTimes(1);
        done();
    }, 100);
});
