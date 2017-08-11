### Js定时器

除了放置异步任务的事件，"任务队列"还可以放置定时事件，即指定某些代码在多少时间之后执行。这叫做"定时器"（timer）功能，也就是定时执行的代码。 

定时器最常用的两种：

    setTimeout()
    setInterval()

##### setTimeout()超时调用：

      函数用来指定某个函数或某段代码，在多少毫秒之后执行。它返回一个整数，表示定时器的编号，以后可以用来取消这个定时器。
      只执行一次,如果不再设置另一次超时调用，调用就会自行停止。
      
          var timerId = setTimeout(func|code, delay)   
          clearTimeout() //取消超时调用
          clearTimeout(timerId)
          
##### setInterval()间歇调用    

      setInterval函数的用法与setTimeout完全一致,区别仅仅在于setInterval指定某个任务每隔一段时间就执行一次，
      也就是无限次的定时执行,直至间歇调用被取消或者页面被卸载

          var interv=setInterval(func|code,delay);
          clearInterval()//取消间歇调用
##### 问题

      setInterval指定的是“开始执行”之间的间隔，并不是上一次func执行完了之后再过100ms才开始执行下一次func，
      而是每隔delay ms就将func放入主线程队列
      
#### 解决方案：
      使用超时调用来模拟间歇调用是一种最佳模式
      用循环调用setTimeout模拟setInterval
      
      var num=0;
      function interval(func, wait){	
        var interv = function(){num++;
          if(num<=5){
          func.call(null);
              setTimeout(interv, wait);} 
         };
        setTimeout(interv, wait);
      }
      interval(function(){  alert(num);},1000);


#### Js定时器的工作原理

    setTimeout和setInterval的运行机制是将指定的代码移出本次执行，等到下一轮Event Loop时，
    再检查是否到了指定时间。如果到了，就执行对应的代码；如果不到，就等到再下一轮Event Loop时重新判断。

    setTimeout和setInterval指定的代码，必须等到本轮Event Loop的所有同步任务都执行完，
    再等到本轮Event Loop的“任务队列”的所有任务执行完，才会开始执行。 由于前面的任务到底需要多少时间执行完，
    是不确定的，所以没有办法保证，setTimeout和setInterval指定的任务，一定会按照预定时间执行。
    
    
### 参考资料
  [定时器--JavaScript 标准参考教程（alpha）](http://javascript.ruanyifeng.com/advanced/timer.html#toc0)    
  [John Resig--How JavaScript Timers Work](https://johnresig.com/blog/how-javascript-timers-work/)



