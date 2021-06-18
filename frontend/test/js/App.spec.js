import React from "react";
import { render } from "@testing-library/react";
import "@testing-library/jest-dom/extend-expect";
import { App } from "../../src/js/App";

test("basic render - matches snapshot", () => {
    expect(render(<App />)).toMatchSnapshot();
});
