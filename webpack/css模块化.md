css模块化
=====

* 1.在入口文件中引用css

       import  style from  'xx.css';
       <div class={style.class名称}></div>
       
* 2. 修改配置文件webpack.config.js
             
            // 处理 css文件中出现的 url, 会自动帮你引入里面要引入的模块
            // '[path]-[name]-[local]-[hash:base64:6]'  文件路径--css文件名称-类名-6位长度的base64的字符串 
            {
                test: /\.css$/,
                use: [
                    'style-loader' ,
                    {
                        loader: 'css-loader',
                        options: {
                            module: true,
                            localIdentName: '[name]-[local]_[hash:base64:6]'//配置生成的类名
                        }
                    }
                ],
                //排除文件夹不进行模块化处理
                exclude: [
                    path.resolve(__dirname, 'node_modules'), // /排除node_modules下的文件夹
                    path.resolve(__dirname, 'src/common')   // /排除src下的common文件夹
                ]
            },
            {
                test: /\.css$/,
                use: [ 'style-loader', 'css-loader' ],//先css-loader处理，再style-loader处理
                include: [
                    path.resolve(__dirname, 'node_modules'),
                    path.resolve(__dirname, 'src/common')
                ]
            },


