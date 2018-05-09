babel
=====

babel是Js编译器能将ES6语法编译成Es5,babel的运行是基于插件的，没有插件babel将一无是处

babel-core

plugins

presets

.babelrc

* 1.安装babel-cli
      
      npm install --save-dev babel-cli  (安装在项目中)
      npm i -D  babel-cli
      
      npm -i -g  babel-cli   (全局安装)
      
* 2.如何使用babel

        全局安装时才能直接是用babel命令
             babel  xx.js           
             babel  src/app.js
             
        安装在项目中时需要找到对应目录下的babel
             ./node_modules/.bin/babel   xx.js
             ./node_modules/.bin/babel  src/app.js
             
        package.json中配置babel命令后直接使用 npm run babel
            {
              "name": "babel",
              "version": "1.0.0",
              "description": "",
              "main": "index.js",
              "scripts": {
                "babel": "babel src/app.js"
              },
              "author": "",
              "license": "ISC",
              "devDependencies": {
                "babel-cli": "^6.26.0",
              }
            }
* 3.使用babel插件
     
       安装需要的插件
              如  npm install --save-dev babel-plugin-transform-es2015-arrow-functions
       
       使用插件时
              如  babel --plugins transform-es2015-arrow-functions xx.js
              
              或配置package.json中配置babel命令npm run babel
              
              多插件使用
              方法一
                package.json中配置babel命令后直接使用 npm run babel
                {
                  "name": "babel",
                  "version": "1.0.0",
                  "description": "",
                  "main": "index.js",
                  "scripts": {
                    "babel": "babel src/app.js --plugins transform-es2015-arrow-functions transform-es2015-classes"
                  },
                  "author": "",
                  "license": "ISC",
                  "devDependencies": {
                    "babel-cli": "^6.26.0",
                    "babel-plugin-transform-es2015-arrow-functions": "^6.22.0",
                    "babel-plugin-transform-es2015-classes": "^6.24.1",
                  }
                }
                
            方法二
            
              1.新建一个.babelrc的配置文件(json格式)
                {
                  "plugins": ["transform-react-jsx","transform-es2015-arrow-functions","transform-es2015-classes"],
                  "ignore": [
                    "foo.js",
                    "bar/**/*.js"
                  ]
                }
                
                2.package.json中配置babel命令后直接使用 npm run babel
                "scripts": {
                    "babel": "babel src/app.js"
                  },
            
            
 * 4.babel的预设
    
          1.下载安装
            npm install --save-dev babel-preset-env

          2..babelrc的配置文件(json格式)
            {
              "presets": ["env"]
            }

          3.配置编译后输出的目录
             "scripts": {
                  "babel": "babel src/app.js  -o out/a.js" //编译后输出到out文件夹的a.js
              },
    

**相关网址**

[babel官网](http://babeljs.io/)

[babel-cli安装](http://babeljs.io/docs/usage/cli/)

[babel插件](http://babeljs.io/docs/plugins/)

[.babelrc](http://babeljs.io/docs/usage/babelrc/)
