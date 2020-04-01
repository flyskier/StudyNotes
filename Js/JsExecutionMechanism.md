
### Js执行机制

JavaScript语言的一大特点就是单线程     

    简单地说就是同一时间只能做一件事，当有多个任务时，只能按照一个完成了再执行下一个。
    
    Js为啥是单线程的：假定JavaScript同时有两个线程，一个线程在某个DOM节点上添加内容，  
    另一个线程删除了这个节点，这时浏览器应该以哪个线程为准？
    
    HTML5中允许JavaScript脚本创建多个线程，但是子线程完全受主线程控制，且不得操作DOM，所以JavaScript运行的本质还是单线程。
    
任务队列  

    一个接一个地完成任务也就意味着待完成的任务是需要排队,如果前一个任务耗时很长，后一个任务就不得不一直等着。  

通常排队有以下两种原因： 

    1.任务计算量过大，CPU处于忙碌状态；  
    2.任务所需的东西未准备好所以无法继续执行，导致CPU闲置。比如有的任务需要通过Ajax获取到数据才能往下执行     
      针对第二种排队为了提高运行速度，先运行后面已经就绪的任务,也就是把等待中的任务先挂起放到一边，等得到需要的东西再执行 
      
同步任务（synchronous）

	在主线程上排队执行的任务，只有前一个任务执行完毕，才能执行后一个任务


异步任务（asynchronous）    

    异步任务指的是，没有马上被执行但需要执行的任务，不进入主线程、而进入"任务队列"（task queue）的任务，  
    只有"任务队列"通知主线程，某个异步任务可以执行了，该任务才会进入主线程执行

异步执行的运行机制如下。（同步执行也是如此，因为它可以被视为没有异步任务的异步执行） 

    （1）所有同步任务都在主线程上执行，形成一个执行栈（execution context stack）。

    （2）主线程之外，还存在一个"任务队列"（task queue）。只要异步任务有了运行结果，就在"任务队列"之中放置一个事件。

    （3）一旦"执行栈"中的所有同步任务执行完毕，系统就会读取"任务队列"，看看里面有哪些事件。那些对应的异步任务，于是结束    
        等待状态，进入执行栈，开始执行。

    （4）主线程不断重复上面的第三步。

回调函数（callback）

	  就是那些会被主线程挂起来的代码。异步任务必须指定回调函数，当主线程开始执行异步任务，就是执行对应的回调函数
 
 Event Loop(事件循环)
 
      主线程从"任务队列"中读取事件，这个过程是循环不断的，所以整个的这种运行机制又称为Event Loop（事件循环）

 主线程运行的时候，产生堆（heap）和栈（stack），栈中的代码调用各种外部API，它们在"任务队列"中加入各种事件   
(click，load，done).只要栈中的代码执行完毕，主线程就会去读取"任务队列"，依次执行那些事件所对应的回调函数

任务队列有两种，⼀种是 Macrotask(宏任务)，另外⼀种是 Microtask（微任务），Microtask 优先级是⾼于Macrotask 的。

Microtask 当中的任务也是在执⾏栈当中的任务执⾏完成后再进⾏执⾏，执⾏的时候和Macrotask 有⼀些区别，Microtask 当中任务不会⼀个⼀个压⼊执⾏栈，⽽是所有任务直接压⼊栈中，当 Microtask 当中的任务执⾏完毕后，然后我们再从 Macrotask 中取栈顶的第⼀个任务进⾏执⾏。

Macrotask：setTimeout、setInterval、I/O、UI Rendering、script当中的所有代码、setImmediate(Node) 

Microtask：process.nextTick(node) 、Promise 、MutationObserver

Microtask 当中各种任务的优先级，具体的优先级如下：process.nextTick > Promise > MutationOberser

    
### 参考资料

 [阮一峰的JavaScript 运行机制详解：再谈Event Loop](http://www.ruanyifeng.com/blog/2014/10/event-loop.html)
 
 [js执行机制](https://www.jianshu.com/p/1368d375aa66)
    
    



