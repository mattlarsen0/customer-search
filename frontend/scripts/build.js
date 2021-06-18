import webpack from "webpack";
import webpackConfig from "../webpack.config.js";

const compiler = webpack(webpackConfig);

compiler.run((err) => {
    if (err) {
        console.error(err);
    }
});