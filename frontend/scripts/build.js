const webpack = require("webpack");
const webpackConfig = require("../config/webpack.config");

const compiler = webpack(webpackConfig);

compiler.run((err, res) => {
    if (err) {
        console.error(err);
    }
});