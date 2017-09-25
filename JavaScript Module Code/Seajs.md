Seajs
=======

seaJs的使用

* 引入Seajs的库 

        <script type="text/javascript" src="sea.js"></script>
        
* 全局函数define定义模块
      
      require,exports,module  3个参数 sea下的参数不允许修改
      
      exports：对外提供接口的对象
      
      define(function(require,exports,module){
          function show(){
              alert(1);
          }
      })
      
*  调用模块

        --exports

        --seajs.use

* 引入依赖模块

        --require
        
  
  
**参考资料**      
        
[seajs- API 快速参考](https://github.com/seajs/seajs/issues/266)
