webpack
=====
JavaScript 应用程序的模块打包器(module bundler)

**作用**



**相关知识点**
* ECMAScript6
* npm
* CommonJs(Node.js的相关语法)

**安装**
* 1、安装node环境(检查是否安装成功npm -v/ node -v) 
* 2、安装webpack


      1、 安装在项目中：
      （devDependencies项目开发的依赖）
      npm i -D (npm install --save-dev的简写)
      安装指定版本：npm i -D webpack @version        npm i -D webpack @3 
      安装最新版：npm i -D webpack
      安装最新体验版本：npm i -D webpack @beta

      （写入到 dependencies 对象）
       npm  install -s webpack
      
      2、全局安装：
       npm i -g webpack
       npm install -g webpack
       
      检查是否安装成功  webpack -v
      
**配置**
webpack.config.js

运行webpack命令的时候加载的配置文件，当webpack命令运行的时候，会加载该文件，根据该文件的配置内容进行执行
      
      const path = require('path');
      module.exports = {
          entry: './src/app.js',
          output: {
              path: path.resolve(__dirname, 'dist'),
              filename: 'bundle.js'
          },
          mode:'development'
      };

 npm init -y  (得到package.json)
 
          {
              "name": "webpackTest",
              "version": "1.0.0",
              "description": "",
              "main": "webpack.config.js",
              "scripts": {
                "test": "echo \"Error: no test specified\" && exit 1",
                "dev": "webpack"    //webpack --config  my.config.js
              },
              "keywords": [],
              "author": "",
              "license": "ISC",
              "devDependencies": {
                "webpack": "^4.6.0",
                "webpack-cli": "^2.0.15"
              }
            }        
 
 npm i -D webpack (得到node_modules)
 
 npm run dev (重新打包)
 
**相关网址**

[node下载](https://nodejs.org/en/download/) 

[babel的链接](https://babeljs.io)

[webpack官网](https://webpack.js.org/)

[webpack中文文档](https://doc.webpack-china.org/concepts/)


