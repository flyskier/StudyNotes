DOM事件流
=====

**Dom事件流包括三个阶段**

* 第一阶段：从window对象传导到目标节点，称为“捕获阶段”（capture phase）

* 第二阶段：在目标节点上触发，称为“目标阶段”（target phase）

* 第三阶段：从目标节点传导回window对象，称为“冒泡阶段”（bubbling phase）



**事件函数的绑定**

给一个对象绑定一个事件处理函数的几种方法

* 1.赋值
       function fn1(){};
       function fn2(){};
       obj.onclick=fn1;
       obj.onclick=fn2;   //fn2覆盖方法fn1
       
 * 2.给一个对象的同一个事件绑定多个不同的函数（兼容性问题）
      
       ie下: obj.attachEVent(事件名称，事件函数)       
             1.没有捕获
             2.事件名称有on
             3.事件函数的执行的顺序：标准ie（IE9及其以上）=>正序，  非标准ie=>倒序
             4.事件函数里的this 指向的是window
                   
                   document.attachEVent('onclick',fn1);
                   document.attachEVent('onclick',fn2);
              
        标准浏览器： obj.addEventListener(事件名称，事件函数，是否捕获)  默认是false  false：冒泡 true 捕获
                    1.有捕获
                    2.事件名称没有有on
                    3.事件函数的执行的顺序正序
                    4.事件函数里的this 指向触发该事件的对象
                    
                     document.addEventListener('click',fn1，false);  
                     document.addEventListener('click',fn2，false);
                   
       兼容问题解决方案：
       
                  call() 
                  fn1(); 相当于fn1.call();
                  call方法的第一个参数可以改变函数执行过程中内部this的指向
                  call方法的第二个参数开始就是原来函数的列表
                  
                  function bind(obj, evname, fn) {
                    if (obj.addEventListener) {
                        obj.addEventListener(evname, fn, false);
                    } else {
                        obj.attachEvent('on' + evname, function() {
                            fn.call(obj);
                        });
                    }
                }

                bind(document, 'click', fn1);
                bind(document, 'click', fn2);

**事件函数的取消**

* 1.赋值形式的取消
  
        obj.onclick=null;//取消
        
* 2.给一个对象的同一个事件取消多个不同的函数


        IE：obj.dettachEvent(事件名称，事件函数)
        标准：obj.removeEventListener(事件名称,事件函数,是否捕获) 默认是false  false：冒泡 true 捕获
 


**事件捕获**

    从根节点到目标元素       

**事件冒泡**

    从目标元素到根节点，当一个元素接收到事件的时候，会把他接收到的所有事件传播给他的父级，一直到window




**阻止事件冒泡**

* 1.Js阻止事件冒泡

    在W3c中，使用stopPropagation（）方法    
    
    在IE下 在事件调用函数中调用  ev.cancelBubble = true  
    
        //阻止事件冒泡函数
        function stopBubble(e)
        {
            if (e && e.stopPropagation)
                e.stopPropagation()
            else
                event.cancelBubble=true
        }

* 2.Jq阻止事件冒泡

    jQuery.Event提供了一个非常简单的方法来阻止事件冒泡：event.stopPropagation();
    
        $("p").click(function(event){
             event.stopPropagation();
             // do something
        })
        
   但是这个方法对使用live绑定的事件没有作用，需要一个更简单的方法阻止事件冒泡：return false;
       
       $("#div1").mousedown(function(event){
            return false;
        });
  区别:
  
        return false 不仅阻止了事件往上冒泡，而且阻止了事件本身。
        event.stopPropagation() 则只阻止事件往上冒泡，不阻止事件本身。



**注意事项**

* 并不是所有事件都能冒泡
* 事件冒泡是默认存在的




**参考资料**

[理解DOM事件流的三个阶段](https://segmentfault.com/a/1190000004463384)

[avaScript 标准参考教程（alpha）--事件模型](http://javascript.ruanyifeng.com/dom/event.html#toc9)

