Less和Scss
======

**Scss**

* 1.安装sass-loader 和node-sass(sass-loader依赖node-sass)

        npm i -D sass-loader node-sass
   
* 2.webpack.config.js中配置rules
        
          {
                 test: /\.scss$/,
                 use: [ 'style-loader' ,'css-loader','sass-loader' ] 
                 //从右至左依次处理 先sass-loader处理，再css-loader处理，再style-loader处理
           }
           
        处理后再模块化
          {
                 test: /\.scss$/,
                 use: [ 'style-loader' ,
                       {
                          loader:'css-loader,
                          option:{
                              module:true,
                              localIdentName: '[name]-[local]_[hash:base64:6]'//配置生成的类名
                          }

                       },
                       'sass-loader' 
                 ] 
                 //从右至左依次处理 先sass-loader处理，再css-loader处理，再style-loader处理
           }

**Less**

* 1.安装less-loader 和less(less-loader依赖less)

        npm i -D less-loader less
   
* 2.webpack.config.js中配置rules
   
       // '[path]-[name]-[local]-[hash:base64:6]'  文件路径--css文件名称-类名-6位长度的base64的字符串 
       {
           test: /\.less$/,
           use: [
               'style-loader' ,
               {
                   loader: 'css-loader',
                   options: {
                       module: true,
                       localIdentName: '[name]-[local]_[hash:base64:6]'//配置生成的类名
                   }
               }
               ,less-loader
           ],
           //排除文件夹不进行模块化处理
           exclude: [
               path.resolve(__dirname, 'node_modules'), // /排除node_modules下的文件夹
               path.resolve(__dirname, 'src/common')   // /排除src下的common文件夹
           ]
       },
       {
           test: /\.less$/,
           use: [ 'style-loader', 'css-loader','less-loader' ],//先css-loader处理，再style-loader处理
           include: [
               path.resolve(__dirname, 'node_modules'),
               path.resolve(__dirname, 'src/common')
           ]
       },

        
