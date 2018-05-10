jsx
====

jsx是一种语法用于描述页面的结构，最终生产一个对象

**属性定义**

* 注意js的关键字和保留字

        class  -------className

* 不规范的属性，react不显示

        自定义属性需要加上data-前缀，不加会报错
        
 * 表达式
 
        在jsx中嵌套表达式
        
         let w='Hello'
          ReactDOM.render(
              <div>{w}</div>,
              document.getElementById('root')
          );
       
        jsx本身当作表达式
        
         let s=<span>Hello</span>
          ReactDOM.render(
              <div>{s}</div>,
              document.getElementById('root')
          );
* 样式

       行内样式
       ReactDOM.render(
          <div style={{color:"red" }}>Hello World</div>,
           document.getElementById('root')
      );
       
       

