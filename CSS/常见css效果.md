常见css效果
=======

**1.圆角**

   * i.切图制作，兼容所有浏览器
   
   * ii.Css3的圆角 （IE6,7,8不支持）
     
           border-radius：50% （圆）
           border-radius:左上 右上 右下 左下;  
           
   **圆角图片**

   * i.把图片切成圆角的，兼容所有浏览器
   
   * ii.图片是直角的用样式来做圆角（IE6,7,8不支持）
     
           <div class="main_ad"><a><img /></a></div>
           .main_ad { border-radius:6px; overflow:hidden; }
           
   **自适应宽度兼容圆角制作**
   
   * 最外层的标签a主体内容 strong左边角， sapn 右边角   
   * 背景图制作：切图时竖着切，摆放放一次是 左 右 中间拼接而成,每个高度都为图片的高度3分之一
            
          <a href="#">
              <strong>
                  <span>hello</span>
              </strong>
          </a>
   
   **自适应高度兼容性圆角制作**        
            
   * 最外层的div主体内容背景 content_top头部， content_bottom页脚   
   * 切图时横着切，摆放依次是 上 中 下拼接而成 宽度为图片的宽度的3分之一
   
         <div id="content">
             <div id="content_top">
                <div id="content_bottom">
                  内容
                </div>
           </div>
        </div>
      
      
      
      
**2.三角形的制作**   

  * i.切图制作，兼容所有浏览器
     
  * ii.使用height:0px; width:0px;
          
           { width:0; height:0; overflow:hidden; border-left:4px solid transparent;
              border-right:4px solid transparent;
           }
           { border-bottom:4px solid #ca0309; }//向下三角形
           { border-top:4px solid #ca0309; } //向上三角形
           
  * iii.利用CSS3旋转正方形
      
           {  width: 13px;
              height: 13px;
              border-left: 1px solid #e2e5e8;
              border-top: 1px solid #e2e5e8;
              transform: rotate(45deg);
              background: #fff;
            }
          
     


           
**3.渐变**
   
  * i.兼容所有浏览器的话采用图片的方法来制作
   
  * ii.Css3的渐变 IE6,7不兼容 （优雅降级）

        #div1 { width:200px; height:200px; border:1px solid #333;
             background:-moz-linear-gradient(top, #FFFFFF, #f8f8f8);  /*ff */
             background:-webkit-linear-gradient(top, #FFFFFF, #f8f8f8); /* chrome*/
             background:-ms-linear-gradient(top, #FFFFFF, #f8f8f8); /* IE */
             background:linear-gradient(top, #FFFFFF, #f8f8f8);
             -ms-filter:"progid:DXImageTransform.Microsoft.gradient (GradientType=0, startColorstr=#FFFFFF, endColorstr=#f8f8f8)"; 
             /* IE9，IE8   IE滤镜渐变 */
             +background:#f9f9f9; /*IE6,7下不渐变  */
