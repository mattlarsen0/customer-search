import React from "react";
import { render, screen } from "@testing-library/react";
import "@testing-library/jest-dom/extend-expect";
import { App } from "../../src/js/App";

test("basic render - matches snapshot", async () => {
    expect(render(<App />)).toMatchSnapshot();
});

test("contains 'hello world' text", async () => {
    const helloWorldText = "HELLO FROM REACT WORLD";
    render(<App />);

    expect(screen.getByRole("heading")).toHaveTextContent(helloWorldText);
});
