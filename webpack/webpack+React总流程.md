
webpack打包总流程
=======

**1、安装node环境**
      
 * 检查是否已安装成功
 
        Win+R 打开CMD
        输入npm -v(npm --version)/ node -v (node --version)
        出现版本号即为已安装
      
 * 安装node
      
        安装完后，会自动在系统的path环境变量中配置了node.exe的目录路径，
        但是可能你安装完成后，在dos命令下输入node提示错误
        打开系统环境变量，发现确实已经配置了，但是dos下运行“set path”又看不到nodejs的配置，重启电脑重新加载就可以了。
        也可以删掉自动配置的，手动再加上即可。如：打开计算机属性-高级系统设置-环境变量，在系统变量列表中找到path变量
 
**2、安装webstorm**


**3、新建项目**

      src文件夹（放置项目源代码）
      dist文件夹（打包后项目文件）
      新建webpack.config.js(webpack的配置文件)配置入口（src/app.js）和出口(dist)
      src/common（放置公共资源）
      src/index.html（初始化html代码）

**4、初始化项目文件（package.json）**
      
      webstorm 显示终端 terminal 的快捷键 alt+f12
      或用Win+R 打开CMD 进入对应项目路径
      
         npm  init      以交互方式完成package.json的创建。
         npm  init -y   生成默认package.json，连交互式界面都不会出现

**5、安装webpack**

      webpack可以全局安装也可以安装在项目中一般推荐安装在项目中
      
      npm i -D webpack @3   安装指定版本(devDependencies项目开发的依赖)
      
      安装webpack后默认生成node_modules文件

**6、运行webpack命令**
      
      1. 在package.json的script中配置
          {
              "name": "webpackTest",
              "version": "1.0.0",
              "description": "",
              "main": "webpack.config.js",
              "scripts": {
                "test": "echo \"Error: no test specified\" && exit 1",
                "dev":"webpack" //默认使用webpack.config.js的文件
              },
              "keywords": [],
              "author": "",
              "license": "ISC",
              "devDependencies": {
                "webpack": "^4.8.1"
              }
            }

       2.npm run dev(执行过程中会先安装webpack-cli)
       

**7、安装依赖**
      
  * 1、生产依赖 react react-dom
            
            npm i -s react react-dom
            
  * 2、开发依赖
  
            npm i -D babel-loader babel-core   

            npm i -D babel-preset-react

            npm i -D babel-preset-env 

            省时的浏览器同步测试工具
            Browsersync能让浏览器实时、快速响应您的文件更改（html、js、css、sass、less等）并自动刷新页面
            npm i -D  browser-sync

            处理css
            npm i -D css-loader
            npm i -D style-loader

            处理img
            npm i -D file-loader
            npm i -D url-loader

            express服务器
            npm i -D express

            webpack 开发服务器 devserver
            npm i -D webpack-dev-server

            //根据html模板生成html文件
            npm i -D html-webpack-plugin

            热加载
            npm i -D react-hot-loader

            npm i -D webpack-dev-middleware

            npm i -D webpack-hot-middleware

**8、packag.json文件**

      {
        "name": "reactTest",
        "version": "1.0.0",
        "description": "",
        "main": "webpack.config.js",
        "scripts": {
          "test": "echo \"Error: no test specified\" && exit 1",
          "dev": "webpack",
          "start":"node server",
          "ser":"node ser"
        },
        "keywords": [],
        "author": "",
        "license": "ISC",
        "devDependencies": {
          "babel-core": "^6.26.3",
          "babel-loader": "^7.1.4",
          "babel-preset-env": "^1.6.1",
          "babel-preset-react": "^6.24.1",
          "browser-sync": "^2.24.4",
          "express": "^4.16.3",
          "html-webpack-plugin": "^3.2.0",
          "react-hot-loader": "^4.1.3",
          "webpack": "^4.8.1",
          "webpack-cli": "^2.1.3",
          "webpack-dev-middleware": "^3.1.3",
          "webpack-hot-middleware": "^2.22.1"
        },
        "dependencies": {
          "react": "^16.3.2",
          "react-dom": "^16.3.2"
        }
      }       
            
**9、webpack的配置文件(webpark.config.js)**



**10、babel的配置(.babelrc)**
      
      {
          "presets": ["env","react"]
      }


**11、服务器配置文件(server.js)**


      //热加载在不刷新浏览器的情况下替换编译好的内容，保存原来视图的状态
      const  webpack=require('webpack');
      const path=require('path');


      const webpackDevMiddleware = require('webpack-dev-middleware');
      const webpackHotMiddleware = require('webpack-hot-middleware');
      const config=require('./webpack.config');
      // const bs = require('browser-sync').create();

      //在入口插入
      config.entry.unshift('webpack-hot-middleware/client?reload=true')

      let app = new (require('express'))();//启用express服务器

      let port = 9000;

      let compiler = webpack(config);//编译器

      //注册中间件
      //webpackDevMiddleware 跟webpack结合起来进行资源打包。打包好的东西放到内存中，服务器会替换这些资源
      app.use( webpackDevMiddleware(compiler, {publicPath: '/assets/'}) );
      //webpackHotMiddleware热加载，替换页面内容
      app.use( webpackHotMiddleware(compiler) );

      app.get('/', (req, res)=> res.sendFile(path.resolve(__dirname, 'src/index.html') ) )

      app.listen(port);













**相关网址**

[nodejs下载安装](https://nodejs.org/en/download/)

[npm官网](https://www.npmjs.com/)

[webstorm官网](http://www.jetbrains.com/webstorm/)

[webstorm激活破解方法](https://blog.csdn.net/voke_/article/details/76418116)

[webstorm中文文档](https://doc.webpack-china.org/concepts/)

[babel官网](http://babeljs.io/)

[browsersync](http://www.browsersync.cn/)
