ECMAScript6 (ECMAScript2015)
========

**let 命令**

* 不存在变量提升
* 使用let，声明的变量仅在块级作用域内有效
       
       do{
         let a=9;   
       }while(0);
       console.log(a);
       Uncaught ReferenceError: a is not defined
       
* 暂时性死区
* 不允许重复声明
     
      let a=8;
      let a=9;
      console.log(a);
      Uncaught SyntaxError: Identifier 'a' has already been declared
    

**const 命令**

* const声明一个只读的常量。一旦声明，常量的值就不能再次赋值，是
    对象时可以改变变量的内容 
      
       const a=9;
       a=8;
       console.log(a);
       Uncaught TypeError: Assignment to constant variable.
       
       const a={};
       a.b=9;
       console.log(a);
       //{b: 9}
   
* 只声明不赋值，会报错（声明的时候要初始化）。
     
       const a;
       console.log(a);
       Uncaught SyntaxError: Missing initializer in const declaration

* 只在声明所在的块级作用域内有效
      
       do{
           const a=9;
       }while(0);
       console.log(a);
       Uncaught ReferenceError: a is not defined
       
* 暂时性死区

* 不可重复声明

      const a=8;
      const  a=9;
      console.log(a);
      Uncaught SyntaxError: Identifier 'a' has already been declared


* 不存在变量提升


**函数的扩展**

* 可以给函数的参数指定默认值

       function log(x, y = '2') {
              console.log(x, y);
       }

       log('1');//1 2
       log('1', '3');//1 3
       log('1', '') ; //1 
       
* 参数变量是默认声明的，不能用let或const再次声明

        function foo(x = 5) {
         let x = 1; // error
         const x = 2; // error
        }
       
* 箭头函数



**模板字符串**


**解构赋值**


**spread-rest**


**类**








**参考资料**

 [ECMAScript6入门](http://es6.ruanyifeng.com/) 
