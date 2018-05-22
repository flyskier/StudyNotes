vue
====

是一套用于构建用户界面的渐进式JavaScript框架，

**Vue特点**

* 1、Vue 的核心库只关注视图层

* 2、简单易学，简洁，轻量，快速

* 3、渐进式框架

**理解渐进式**

所谓渐进式，可以一步一步，有阶段性的使用Vue，不需要一上手就把所有东西全用上

* 声明式渲染（Declarative Rendering）

* 组件系统（Components System）

* 客户端路由（vue-router）

* 大规模的状态管理(vuex)

* 构建工具（vue-li）

声明式渲染和组建系统是Vue的核心库所包含内容，

而客户端路由、状态管理、构建工具都有专门解决方案。

这些解决方案相互独立，你可以在核心的基础上任意选用其他的部件，不一定要全部整合在一起


**Vue的核心点**

* 1、响应式的数据绑定

        当数据发生改变-->视图自动更新
        专注于操作数据

* 2、可组合的视图组件


**实例**

实例一
      
          <div id="app">
                <p>{{message}}</p>
                <p>数据1</p>
          </div>
          <script>
              var message = 'hello,my frist Vue';
              // 根实例 启动应用
              // 传入一个对象作为参数，称之为选项对象，告诉vue做什么事情
              new Vue({
                  el: '#app', // element 可以写css选择器 node(元素节点)
                  data:{  // 数据对象
                     message
                  }
              })
          </script>
        
 实例二
 
            <div id="app">
                <p>{{ msg }}</p>
                <p>数据2</p>
            </div>
            <script>
                var message = 'hello,my frist Vue';
                // 根实例 启动应用
                // 传入一个对象作为参数，称之为选项对象，告诉vue做什么事情
                var app = document.getElementById('app');
                new Vue({
                    el: app, // element 可以写css选择器 node(元素节点)
                    data:{  // 数据对象
                        msg:message
                    }
                })
            </script>


**相关网址**

[vue官网](https://cn.vuejs.org/)

[例子todomvc](http://todomvc.com/examples/vue/)

[渐进式](https://mp.weixin.qq.com/s?__biz=MzUxMzcxMzE5Ng==&mid=2247485737&amp;idx=1&amp;sn=14fe8a5c72aaa98c11bf6fc57ae1b6c0&source=41#wechat_redirect)
