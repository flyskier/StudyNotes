1章
========
**1.JavaScript诞生于1995**

**2.JavaScript组成**

* 核心（ECMAScript）

    European Computer Manufacturers Association(欧洲计算机制造商协会)
    
      语法
      类型 
      语句
      关键字
      保留字
      操作符
      对象     
* 文档对象模型（DOM，Document Object Model）
   
       提供访问和操作网页内容的方法和接口（document）
       
       DOM0 
       DOM1 
       DOM2 
       DOM3
       
   
* 浏览器对象模型（BOM,Browser Object Model）

      提供与浏览器交互的方法和接口（window）
      
      
2章
====

**1.<script>元素**

 * 属性  
  async：表示应该立即下载脚本，不妨碍页面中的其他操作，比如下载其他资源或等待加载其他脚本，只对外部脚本有效  
  defer：表示脚本可以延迟到文档完全被解析和显示之后再执行。只对外部脚本才有效   
  src    
  type 
  
  
  * 嵌入脚本与外部脚本
  
         解析嵌入式JS代码和解析外部JS文件（包括下载文件）时，页面的处理都会暂时停止
         
  * 只要不存在defer和async属性，浏览器都会按照<script>元素的页面中出现的先后顺序对它们一次进行解析
  
  * JS引用放在body元素中页面内容的后面
  
          如果在文档的<head>元素中包含所有JS文件，意味着必须等到全部js代码都被下载，解析和执行完成以后，才能开始呈现页面的内容
      
        （浏览器在遇到<body>标签是才会开始呈现内容）

* 延迟脚本

* 异步脚本



**2.文档模式**

  * 混杂模式（quirks mode）
  * 标准模式（standards mode）


