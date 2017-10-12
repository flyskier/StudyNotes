BOM——浏览器对象模型(Browser Object Model) 
=================

定义了Js操作浏览器的方法

**Window对象**

**1.常用方法**

* window.open("URL","新窗口名字"，"新窗口特性");
      
      返回值：返回新打开窗口的window的对象
      
* window.close（）
      
      1.ff(火狐)：默认无法关闭
      2.Chrome：默认直接关闭
      3.IE：询问用户
      
      可以关闭在本窗口中通过js方法打开的新窗口
      
**2.常用属性**

  * window.navigator
   
        window.navigator.userAgent     //浏览器信息

        判断是不是IE
        if(window.navigator.userAgent.indexOf('MSIE')!=-1)
        {
            alert('IE');
        }
        else
        {
             alert('非IE');
        }
        
  * window.location        //浏览器地址栏信息
  
        window.location.href   //浏览器地址栏地址   URL
        
        window.location.search   // url  ?后面的内容  包含?
        
        window.location.hash     //url  #后面的内容 包含#
        
        
**文档宽高**

 * 可视区的尺寸 clientWidth   clientHeight      
   
   	  包含内边距，但不包括水平滚动条、边框和外边距
	 
          document.documentElement.clientWidth --文档元素的可视区宽度  
          document.documentElement.clientHeight ---文档元素的可视区高度 
	  
          clientHeight 可以通过 CSS height + CSS padding - 水平滚动条高度 (如果存在)来计算.
     
 
 * 滚动距离  scrollTop scrollLeft
  
        滚动条滚动距离----scrollTop可视区顶部到到文档顶部的距离
                     ----scrollLeft 可视区左边到文档左部的距离

        document.documentElement.scrollTop   --IE，火狐 ，Chrome有些版本不能识别
        document.body.scrollTop              --Chrome

        document.documentElement.scrollLeft
        document.body.scrollTop.scrollLeft

          document.onclick=function(){
		//alert(document.documentElement.scrollTop);
		// alert(document.documentElement.scrollLeft);
		 alert(document.body.scrollTop);
		 alert(document.body.scrollLeft);  
             var scrollTop=document.documentElement.scrollTop||document.body.scrollTop;
	      }

* 内容高 scrollHeight

        document.body.scrollHeight
        
* 文档高    offsetHeight
       
 
**窗口事件**

* onsroll:当滚动条滚动的时候触发-----按时间来计算触发次数
   
	   window.onscroll = function (e) {
	    // 当页面的滚动条滚动时,会执行这里的代码
	   }
   
* onresize 在窗口大小改变之后,就会触发resize事件.---按时间来计算触发次数

	  window.onresize= function (e) {
	    // 当窗口大小发生改变的时候,会执行这里的代码
	   }
 
  
  **参考资料**
  
  [WebAPI接口-WindWindow](https://developer.mozilla.org/zh-CN/docs/Web/API/Window)
  
  [WebAPI接口-Element](https://developer.mozilla.org/zh-CN/docs/Web/API/Element)
     
