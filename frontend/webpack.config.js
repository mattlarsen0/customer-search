import MiniCssExtractPlugin from "mini-css-extract-plugin";
import path from "path";

const __dirname = path.resolve();
const distPath = path.resolve(__dirname, "../backend/wwwroot/bundles");
const env = process.env.NODE_ENV;
const generateSourceMaps = env == "development";

export default {
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