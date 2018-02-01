
**前端开发语言**

* html（Hypertext Markup Language）—— 结构超文本标记语言

* css（Cascading Style Sheets）—— 样式层叠样式表

* js（javascript）—— 行为


**声明文档类型**

    <!DOCTYPE HTML>
    
     HTML5 不基于 SGML，因此不需要对DTD进行引用，但是需要doctype来规范浏览器的行为，
     告知浏览器的解析器用什么文档标准解析这个文档。DOCTYPE不存在或格式不正确会导致文档以兼容模式呈现。

     而HTML4.01基于SGML,所以需要对DTD进行引用，才能告知浏览器文档所使用的文档类型。


**meta**

     <meta charset="utf-8"/>  代码编码格式utf-8  国际标准  gb2321 中文简体标准
     
     <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
     
     <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
     
     <!-- 针对页面的简短描述（限制 150 字符）-->
     <!-- 在*某些*情况下，该描述是被用作搜索结果展示片段的一部分 -->
     <meta name="description" content="一个页面描述">



**样式出现的位置**

* 行间样式表

      <div style="……"></div>

* 内部样式表

      <style>…………</style>

* 外部样式表

      <link href="style.css" rel="stylesheet"/>




**参考资料**

[meta资料]（http://www.cnblogs.com/lovesong/p/5745893.html）
