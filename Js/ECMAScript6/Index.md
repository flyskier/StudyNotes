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

   1、 箭头函数的注意事项

   2、this的指向会是函数所在的上下文环境
       



**模板字符串（template string）**

* 声明模板字符串用反引号

* 模板字符串中嵌入变量，需要将变量名写在${}之中

* 它可以当作普通字符串使用，也可以用来定义多行字符串，或者在字符串中嵌入变量。

       // 普通字符串
        `hello`; 
        
       // 多行字符串
       `In JavaScript this is
        not legal.`     
              
       // 字符串中嵌入变量
       let name = "Bob", 
           time = "today";
       `Hello ${name}, how are you ${time}?`



**解构赋值**

* 数组解构
   
* 对象解构
   
       对象的解构赋值的内部机制，是先找到同名属性，然后再赋给对应的变量。真正被赋值的是后者，而不是前者。

       let { foo: baz } = { foo: "aaa", bar: "bbb" };
       baz // "aaa"
       foo // error: foo is not defined
       foo是匹配的模式，baz才是变量。真正被赋值的是变量baz，而不是模式foo
       
 * 嵌套的解构
       
 * 在函数参数里面直接结构
 
       function log({fristName,lastName},n){
              console.log(`${fristName}  ${lastName} ${n}`)
       }
       log({fristName:'ss',lastName:'ll'},88);
       
       
**spread(展开)**

* 扩展运算符（spread）是三个点（`...`）

* 在函数参数里面展开一个数组

      function fn(a,b,c){
           console.log(a,b,c);
       }
       let arr=[1,2,3];

       fn(arr);        // [1, 2, 3] undefined undefined
       fn(...arr);     //1 2 3
       fn(...[1,2,3]); //1 2 3

* 在一个数组里面展开另外一个数组
       
       let arr=[1,2,3];
       console.log(['a','b',...arr,'c']); //["a", "b", 1, 2, 3, "c"]

* 展开对象

       let obj={ a:1,b:2};
       console.log(
       {
           a:20,
           name:'test',
           ...obj
        });  // {a: 1, name: "test", b: 2}

       console.log(
       {
           a:20,
           name:'test',
           ...obj,
           a:88
       });  //{a: 88, name: "test", b: 2}
       
**rest(剩余)**

* 运算符也是是三个点（`...`）

* 在函数形参里面使用rest
       
       function fn(a,b,...c){
              console.log(a,b,c);
       }
       fn(1,2,3,4,5);//1 2 [3, 4, 5]
       
* 在解构对象中使用rest

       let obj ={a:1,b:2,c:3,d:4};
       let {a,c,...f}=obj;
       console.log(a,c,f);//1 3 {b: 2, d: 4}

**类和类的继承**

* 类的声明

       class 类名{  
              //构造函数，初始化一个对象的属性
              constructor(){
                   //属性
              }
             方法名(){ }
       }
       
       class Human {
            constructor(){
               this.x='hello';
               this.y='world';
            }
            log(c,y){
               console.log('xx',c,y);
            }
            test(){
               console.log('I can sing');
            }
       }
       let a =new Human();

       a.log('test','class');//xx test class
       a.log(a.x,a.y);        //xx hello world
       a.test();               //I can sing
       
* 类的继承

       class Human {
           constructor(x,y){
               this.x=x;
               this.y=y;
           }
           log(c,y){
               console.log('Human',c,y);
           }
       }
       class QgHuman extends Human{
           constructor(x, y, color) {
               super(x, y); // 调用父类的constructor(x, y)
               this.color = color;
           }
           log(c,y){
               console.log('QgHuman',c,y);
           }

       }
       let a= new QgHuman('eye','close','blue');
       a.log(a.x,a.y);        //QgHuman eye close
       
* 类的this指向问题

       class Human {
           constructor(x,y){
               this.x=x;
               this.y=y;
           }
           log(c,y){
               console.log('Human',c,y);
           }
       }
       class QgHuman extends Human{
           constructor(x, y, name) {
               super(x, y); // 调用父类的constructor(x, y)
               this.name= name;
           }
           log(c,y){
               console.log(`${ this.name}`,c,y);
           }

       }
       let a= new QgHuman('eye','close','blue');
       a.log(a.x,a.y);        //blue eye close
       
       //变量接受类的方法时
       let c=a.log;
       c(a.x,a.y);// Cannot read property 'name' of undefined

       修正方法在 QgHuman的构造函数中添加 this.log=this.log.bind(this);



**参考资料**

 [ECMAScript6入门](http://es6.ruanyifeng.com/) 
