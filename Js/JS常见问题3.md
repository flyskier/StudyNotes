面试遇到的JS问题
========

**6.new一个对象的具体过程**
  
    function myNew(F){
      var son={}
      F.apply(son,arguments);
      son.__proto__ = F.prototype;
      rerun son
    }

    (1) 创建一个空对象 son {}
    (2) 重新绑定this，使构造函数的this指向新对象F.call(this)
    (3) 为 son 准备原型链连接son.__proto__ = F.prototype
    (4) 为新对象属性赋值son.name
    (5) 返回son，此时的新对象就拥有了构造函数的方法和属性了

**7.apply,call,bind**

**8.创建对象的方法**

  * 1.创建一个object的实例，再为它添加属性和方法
    
        var obj=new Object();
        
  * 2.对象字面量语法
  
        var obj={}
        
        方法1，2适合用于创建单个对象，创建多个对象的时候会产生大量的重复代码
   
   * 3.工厂模式：用函数来封装已以特定的接口创建对象的细节
  
          function obj(name,age){
            var o=new Object();
            o.name=name;
            o.age=age;
            o.say=function(){
            }
            return o;
          }
          var obj1=obj('我','12');
          解决了多个相似的问题，但没有解决对象识别的问题（对象的类型）
        
   * 4.构造函数模式：用来创建特定类型的对象
  
          function Obj(name,age){
            this.name=name
            this.age=age
            this.say=function(){
            }
          }
          var obj1=new Obj('我','12');

          工厂模式和构造函数模式的不同：构造函数没有显式的创建对象，直接将属性赋给了this对象，没有return，函数名首字母大写
          问题：
        
   * 5.原型模式:
   
**9.原型链**

* 原型对象(prototype)：所有原型对象都会自动获得一个constructor（构造函数）属性 ，是一个指向构造函数的指针

* 构造函数(constructor)：可以通过new来新建一个对象的函数，每个函数都有一个prototype（原型）属性，这个属性是个指针，指向函数的原型对象

* 实例(instance)：通过构造函数new创建出来的对象，包含一个指向原型对象的内部指针__proto__([[prototype]]) 属性和一个constructor（构造函数）属性

   每个构造函数都有一个prototype（原型）属性,原型对象都包含一个指向构造函数的指针,而实例都包含一个指向原型对象的内部指针__proto__([[prototype]]) 属性.

   实例的 __proto__ 属性等于其构造函数的 prototype 属性
   
**10.对象的继承**


**11.this的指向**

* 在全局函数中，this对象等于window对象

* 在函数作为某对象方法时。this等于该对象

* 匿名函数具有全局性，this和arguments是俩特殊的变量，内部函数在搜索这俩个变量时，只会搜索到自己的活动对象。因此永远也不可能直接访问外部函数的这俩变量。
