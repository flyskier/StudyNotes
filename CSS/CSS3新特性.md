CSS3新特性
====
1.使用的方法  
2.兼容性（IE9以下不支持）  
3.注意的问题   

**1、CSS选择器**




**参考资料**

[玩转CSS选择器（一） 之 使用方法介绍](https://segmentfault.com/a/1190000003088878#articleHeader25)

[玩转CSS选择器（二） 之 浏览器支持，常见Bug，性能优化](https://segmentfault.com/a/1190000003503374) 

[CSS选择器的浏览器支持](https://labs.qianduan.net/css-selector/)    

[w3 css3-selectors](https://www.w3.org/TR/css3-selectors/)



**2、新增颜色模式rgba()**
     
      r Red 红 0-255  
      g Green 绿 0-255   
      b Blue 蓝 0-255   
      a Alpha 透明 0-1   

   * 用于背景透明，文字不透明的效果
   * 文字透明,背景不透明
   * 边框颜色透明有问题
   
**3、文字阴影**
    
      text-shadow: x y blur color;
      参数
        x		横向偏移
        y		纵向偏移
        blur		模糊距离
        color		阴影颜色
 * 文字阴影可以叠加   text-shadow: x y blur color, x y blur color;
 * 阴影叠加过多会很卡
 * 叠加时先渲染后面的，再渲染前面的

**4、Text Stroke(文本描边)和text-fill-color(文本填充色)**
    
    -webkit-text-stroke:宽度 颜色  
    -webkit-text-fill-color：颜色 

  * 只有webkit内核的Safari和Chrome支持
  * 同时使用text-fill-color和color属性，text-fill-color将覆盖color属性的颜色值
  * text-fill-color可以使用透明值，即：text-fill-color：transparent
   
**5、text-overflow(文本溢出)**

        overflow: hidden;
        white-space: nowrap;

**6、@font-face自定义文字**

**7、弹性盒子**


**8、box-shadow盒模型阴影**
    
        box-shadow:[inset] x y blur [spread] color
        参数
        inset：投影方式
            inset：内投影
            不给：外投影
        x、y：阴影偏移
        blur：模糊半径
        spread：扩展阴影半径
            先扩展原有形状，再开始画阴影
        color

**参考资料**  

  [css实现跨浏览器的box-shadow盒阴影效果](http://www.zhangxinxu.com/wordpress/2010/07/css%E5%AE%9E%E7%8E%B0%E8%B7%A8%E6%B5%8F%E8%A7%88%E5%99%A8%E7%9A%84box-shadow%E7%9B%92%E9%98%B4%E5%BD%B1%E6%95%88%E6%9E%9C2/)


**9、圆角**

**10、边框**

**11、渐变**


**12、背景**

**13、Transition过渡**

     transition: property  duration   timing-function   delay;
     
          transition-property	 规定设置过渡效果的 CSS 属性的名称。
          transition-duration	 规定完成过渡效果需要多少秒或毫秒。
          transition-timing-function	规定速度效果的速度曲线。
               ease：（逐渐变慢）默认值
               linear：（匀速）
               ease-in：(加速)
               ease-out：（减速）
               ease-in-out：（先加速后减速）
               cubic-bezier 贝塞尔曲线（ x1, y1, x2, y2 )
          transition-delay	定义过渡效果何时开始。

* 发生在样式改变的时候
* 多样式的过渡，用逗号隔开就行
* [贝塞尔曲线](http://matthewlein.com/ceaser/)
* IE9,IE9+ 
* 请始终设置 transition-duration 属性，否则时长为 0，就不会产生过渡效果   
          
**过渡完成事件** 

发生transition完成之后  
问题1 过度完成一次就执行一次   

          Webkit内核： obj.addEventListener('webkitTransitionEnd',function(){},false);
          firefox:    obj.addEventListener('transitionend',function(){},false);

 
**14、transform 2D变换**

     transform:rotate()  skew() scale() translate();

     rotate()  旋转函数 取值度数
          deg  度数
          Transform-origin 旋转的基点
     skew() 倾斜函数 取值度数 
          skewX()
          skewY()
     scale() 缩放函数 取值 正数、负数和小数
          scaleX()
          scaleY()
     translate() 位移函数
          translateX()
          translateY()

* Transform 执行顺序问题 — 后写先执行
* IE10、Firefox、Opera 支持 transform 属性。
* IE9 支持替代的 -ms-transform 属性（仅适用于 2D 转换）。
* Safari 和 Chrome 支持替代的 -webkit-transform 属性（3D 和 2D 转换）。
* Opera 只支持 2D 转换。


**15、3d变换**

**16、animation**



