JavaScript中的正则表达式
========

正则是用来操作字符串的

**Js中字符串的常见操作**

* indexOf          ---查找
* substring        ---获取自字符串
* charAt           ---获取单个字符串
* split            ---分割字符串，获得数组

**找出字符串中所有的数字**

* 传统的方法

      var str="oo64ert23fddddd8980eriui8778";
      function findNum(str){
        var arr=[];
        var temp=''
        for(var i=0;i<str.length;i++)
        {
          if(str.charAt(i)<='9'&&str.charAt(i)>='0')
          {
            //arr.push(str.charAt(i));
            temp+=str.charAt(i);
          }
          else
          {
            if(temp){
              arr.push(temp);
              temp='';
            }
          }
        }
        if(temp){
          arr.push(temp);
          temp='';
        }
        return arr;
      }
      alert(findNum(str));

* 正则表达式

          function findNums(str){
             return str.match(/\d+/g);
          }
          alert(findNums(str));
