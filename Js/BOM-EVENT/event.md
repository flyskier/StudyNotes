事件
=====

**焦点事件**

* onfocus获取焦点事件
    
    当元素获取焦点时触发  
        
        鼠标点击   
        tab键   
        js设置 obj.focus();   

* onblur失去焦点事件

    当元素失去焦点的时候触发   
    
      js设置 obj.blur();     
      obj.select();--选中指定元素里的文本内容
      
      
事件对象（event）(注意兼容)
======

 * 事件对象必须在一个事件调用的函数里面使用才有内容
 
 * 事件函数：事件调用的函数
 
        一个函数是否是事件函数，不在于定义的时候，而在取决于这个函数调用的时候
          function fn1(){
            alert(event);
          }
          obj.onclick=fn1; --此时函数是事件函数，event有内容

          fn1(); --此时函数不是事件函数，event无内容
          
          如果一个函数是被事件调用的，那么这个函数定义的第一个参数就是事件对象（event） 
 
 * ie/chrome：event是一个内置的全局对象
 
 * 标准浏览器（ff火狐,ie,chrome）：事件对象是通过事件函数的第一个参数传入 
  
        解决兼容性的方法
        obj.onclick=function(e)
        {
           var eve=e||event;
          alert(eve);
        }

 * clientX[Y]当事件发生时，鼠标到页面可视区的距离
  
       document.onclick=function(e)
        {
           var eve=e||event;
          //alert(eve);
          alert(eve.clientX);
          alert(eve.clientY);
        }

--例子（div随着鼠标位置移动）

       document.onmousemove=function(e)
       {
         var obox=document.getElementById('box');

         var eve=e||event;

         var clientX=eve.clientX;  //相对可视区的距离
         var clientY=eve.clientY;

         var scrollTop=document.documentElement.scrollTop||document.body.scrollTop;
         var scrollLeft=document.documentElement.scrollLeft||document.body.scrollLeft;

        //div需要给出定位，position:position:absolute;
         obox.style.left=clientX+scrollLeft+'px';
         obox.style.top=clientY+scrollTop+'px';  //相对文档(document)的距离	 
      }


**键盘事件**

* onkeydown:当键盘按键按下的时候触发  如果按下不抬起，那么会连续触发

* onkeyup:当键盘抬起的时候触发

      event.keyCode : 数字类型 键盘按键的值 键值
      
      document.onkeydown = function(ev) {
            var ev = ev || event;
             alert(ev.keyCode);
        }

	  ctrlKey,shiftKey,altKey 布尔值
	  当一个事件发生的时候，如果ctrl || shift || alt 是按下的状态，返回true，否则返回false
             
        document.onclick = function(ev) {
            var ev = ev || event;
            alert(ev.ctrlKey);
        }

* 注意不是所有元素都能接收键盘事件，能够响应用户输入的元素，能够接收焦点的元素就能接收键盘事件


**事件默认行为**

当一个事件发生的时候浏览器自己会默认做的事情

* 阻止事件默认行为

        1.找到这个行为是啥事件触发的
        2.在这个事件的处理函数中使用return false；

        //oncontextmenu : 右键菜单事件，当右键菜单（环境菜单）显示出来的时候触发
         document.oncontextmenu = function() {
                //alert(1)
                return false;
            }

**参考资料**

[事件模型](http://javascript.ruanyifeng.com/dom/event.html)

