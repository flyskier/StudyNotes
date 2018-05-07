loader
======

loader就是webpack用来预处理模块的，在一个模块被引用前，就预先使用loader处理模块内容

**安装**

* 安装loader相关的包 

          npm i -D babel-loader babel-core   
          
* 安装预设相关包

          npm i -D babel-preset-react




**package.json**
        
        {
          "name": "2",
          "version": "1.0.0",
          "description": "",
          "main": "webpack.config.js",
          "scripts": {
            "test": "echo \"Error: no test specified\" && exit 1",
            "dev": "webpack --config webpack.config.dev.js"
          },
          "keywords": [],
          "author": "",
          "license": "ISC",
          "devDependencies": {
            "babel-core": "^6.26.0",
            "babel-loader": "^7.1.2",
            "babel-preset-react": "^6.24.1",
            "html-webpack-plugin": "^2.30.1",
            "webpack": "^3.5.5"
          },
          "dependencies": {
            "react": "^15.6.1",
            "react-dom": "^15.6.1"
          }
        }


**webpack.config.js**

      const HtmlWebpackPlugin = require('html-webpack-plugin');
      const path = require('path');

      module.exports = {
          entry: './src/app.js',
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
              rules: [{
                  test: /\.js$/, //匹配到js文件，用loader来处理
                  use: [{
                      loader: 'babel-loader',
                      options: {
                          presets: ['react']   //不同预设处理不同语法
                      }
                  }]
              }]
          }
      };

      
