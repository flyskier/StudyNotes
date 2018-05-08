
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
        webpack.config.js(webpack的配置文件)配置入口（src/app.js）和出口(dist)

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













**相关网址**

[nodejs下载安装](https://nodejs.org/en/download/)

[webstorm官网](http://www.jetbrains.com/webstorm/)

[webstorm激活破解方法](https://blog.csdn.net/voke_/article/details/76418116)

[webstorm中文文档](https://doc.webpack-china.org/concepts/)
