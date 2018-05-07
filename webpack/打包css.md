打包css
===========


* 在入口文件中引用css

      import  'xx.css';
   
* 安装 css-loader (打包css)

      npm i -D css-loader
    
* 安装 style-loader (把打包好的样式插入网页结构中)

      npm i -D style-loader

* 修改配置文件webpack.config.js

      const HtmlWebpackPlugin = require('html-webpack-plugin');
      const path = require('path');

      module.exports = {
          entry: './src/app.js',    //入口文件
          output: {
              path: path.resolve(__dirname, 'dist'),
              filename: 'app.js',
          },

          plugins: [
              new HtmlWebpackPlugin({
                  filename: 'index.html',
                  template: 'src/index.html'
              })
          ],

          module: {
              rules: [
                  {
                      test: /\.js$/,
                      use: [
                          {
                              loader: 'babel-loader',
                              options: {
                                  presets: ['react']
                              }
                          }
                      ]
                  },
                  {
                      test: /\.css$/,
                      use: [ 'style-loader' ,'css-loader' ]
                  }
              ]
          },

          devServer: {
              open: true,
              port: 9000
          }
      };



