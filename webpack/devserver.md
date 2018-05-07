devserver
======

webpack 开发服务器 devserver

**安装**

* 安装 webpack-dev-server

        npm i -D webpack-dev-server


**在package.json中添加**

      {
        "name": "2",
        "version": "1.0.0",
        "description": "",
        "main": "webpack.config.js",
        "scripts": {
          "test": "echo \"Error: no test specified\" && exit 1",
          "dev": "webpack --config webpack.config.dev.js",
          "start":"webpack-dev-server  --config webpack.config.dev.js"      //start可以随意改名,添加webpack-dev-server，
                                                                         //并配置配置文件，配置文件默认webpack.config.js,
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
      
      
**运行webpack-dev-server**

        npm  start        
        
 **配置webpack-dev-serve服务器**
 
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
                    test: /\.js$/,
                    use: [{
                        loader: 'babel-loader',
                        options: {
                            presets: ['react']
                        }
                    }]
                }]
            },
            devServer: {
                open: true, //自动打开浏览器
                port: 9000  //默认监听8080端口，配置端口号
            }
        };

 **webpack-dev-server**
 
 * 自动监控文件的变化
 
 * 打包内容加载在内存中
 
 
