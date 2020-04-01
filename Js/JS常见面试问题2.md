面试遇到的JS问题
========

**3.防抖和节流**

* 区别：防抖是只执行一次，节流是每隔一段时间执行一次，比如用户输入了5秒钟，如果wait都是1000，防抖只会执行一次，截流会执行5次

* 防抖：用户输入校验用到，将若干函数调用合成为一次（完成后再统⼀发送请求，最后⼀个⼈说了算 只认最后⼀次）

      //func是⽤户传⼊需要防抖的函数
      //wait是等待时间
      const debounce = (func, wait = 50) => {
         // 缓存⼀个定时器id
         let timer = 0
         // 这⾥返回的函数是每次⽤户实际调⽤的防抖函数
         // 如果已经设定过定时器了就清空上⼀次的定时器
         // 开始⼀个新的定时器，延迟执⾏⽤户传⼊的⽅法
         return function(...args) {
           if (timer) clearTimeout(timer)
           timer = setTimeout(() => {
              func.apply(this, args)
           }, wait)
         }
      }
     
* 节流：页面滚动和resize时用到，当达到了一定的时间间隔就会执行一次（隔⼀段时间只触发⼀次 第⼀个⼈说了算 在时间结束触发）

      //func是⽤户传⼊需要节流的函数
      //wait是等待时间
      const throttle = (func, wait = 50) => {
       //上⼀次执⾏该函数的时间
       let lastTime = 0
       return function(...args) {
         //当前时间
         let now = +new Date()
         //将当前时间和上⼀次执⾏函数时间对⽐
         //如果差值⼤于设置的等待时间就执⾏函数
         if (now - lastTime > wait) {
            lastTime = now
            func.apply(this, args)
          }
        }
      }
      setInterval(
         throttle(() => {
          console.log(1)
         }, 500),
       1)

**4.事件流和事件委托（代理）**   

* 事件流：描述的是从页面中接受事件的顺序

* 事件冒泡(event bubbling):即事件由开始时最具体的元素（文档中嵌套层次最深的那个节点）接收,然后逐级向上传播到较为不具体的节点(文档)

* 事件捕获(event capturing):不太具体的节点应该更早接收到事件,具体的节点应该最后接收到事件（在于在事件达到预定目标之前捕获它）

* 事件流的三个阶段，事件捕获阶段-》处于目标阶段-》事件冒泡阶段

* 事件委托：利用了事件冒泡，只指定一个事件处理程序，就可以管理某一个类型的所有事件

**5.事件循环(event Loop)**

  [Js执行机制](./Js/JsExecutionMechanism.md)
