Number类型
========

* 10进制

* 8进制 ：第一位必须为0，然后是八进制数字序列（0-7）

* 16进制： 前两位必须是0x,然后是16进制数字（0-9）及（A-F），A-F可以小写也可以大写

* 进行算术计算的时候，八进制和16进制表示的数值最终将转换成10进制数值 

      例如   var a=070      -->56  =0*8的0次方+7*8的1次方
             var b= 0xA    -->10  A-F代表10-15
             var c= a+b;    -->66
             
**1、数值的范围**

      无穷大 Infinity,Infinity不是能够参入计算的数值 
      isFinity()函数判断某个数值是否位于最小值和最大值之间，是的话返回 true
      
      Number.MIN_VALUE   最小数值 5e-324
      Number.MAX_VALUE   最小数值 1.79...e+308
 
**2、NaN-非数值（Not a Number）**

     一个特殊的数值 表示一个本来要返回数值的操作数未返回数值的情况（这样久不会抛出错误）
     
     任何涉及NaN的操作都会返回NaN
     NaN与任何值都不相等，包括NaN本身
            NaN==NaN false
     出现NaN意味着进行非法的运算
     
     isNaN()函数内部根据Number()来转换，不能被转换成数值的返回true
 
 
**3、浮点数的计算问题**
 
 
**4、数值转换**
 
   * **显式类型转换（强制类型转换）**

            Nuber()    用于任何数据类型
            parseInt() 用于把字符串转换成数值
            parseFloat() 用于把字符串转换成数值
            String()
            Boolean()

   * **隐式类型转换**
   
 1、(+)变成字符串  
   
      var a=200+'3';
      var b='3'+200;
      console.log(a);  //2003
      console.log(b);  //3200
      
 2、(- * / %)变成数字
   
      var a=200-'3';
      var b='300'-200;
      console.log(a);   //197
      console.log(b)   //100  
   
3、(++ --)变成数字
 
      var a='200';
      a++;
      console.log(a); //201
        
 4、(> <)
      
      console.log('10'>9); //true
      console.log('1000'>'9'); //false
      数字的比较和字符串的比较是不同的
      数字的比较是数值的比较
      字符串的比较是一位一位的比较
      
 5、!（取反）
  
      把！右边的数据类型转换成布尔值
      console.log(!'');           //true
      console.log(!null);         //true
      console.log(!0);           //true
      console.log(!NaN);         //true
      console.log(!undefined);   //true
      console.log(!false);       //true
      
 6、==
 



* **数值转换注意点**

1、多个数字和数字字符串混合运算时，跟操作数的位置有关
      
      var a= 1+20+'31'; 
      console.log(a); //2131

      var a= '31'+1+20;
      console.log(a); //31120
      
 2、数字字符串之前存在正负号（+-）时会被转换成数字
 
      console.log(typeof +'3');//number
      var a=+'3'+4;
      console.log(a); //7   
      
      console.log(typeof -'3');//number
      var a=-'3'+4;
      console.log(a); //1
