const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const path = require("path");
const distPath = path.resolve(__dirname, "../dist");
const env = process.env.NODE_ENV;
const generateSourceMaps = env == "development";

module.exports = {
  mode: env || "production",
  entry: "./src/js/index.js",
  output: {
    path: distPath,
    filename: "bundle.js",
  },
  module: {
    rules: [
      {
        test: /\.m?js$/,
        exclude: /(node_modules|bower_components)/,
        use: {
          loader: "babel-loader",
          options: {
            presets: ["@babel/preset-env"]
          }
        }
      },
      {
        test: /\.s[ac]ss$/i,
        use: [
          MiniCssExtractPlugin.loader,
          {
            loader: "css-loader",
            options: {
              sourceMap: generateSourceMaps,
            },
          }
        ],
      },
    ]
  },
  plugins: [
    new MiniCssExtractPlugin({
      filename: "bundle.css",
    }),
  ]
};