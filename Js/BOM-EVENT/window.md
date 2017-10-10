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
        
        

         
         
        
        
