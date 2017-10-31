# Dome10-30
会员登陆代码演示

#### 描述
- 项目分成接口部分和前端部分
- 密码加密
- 接口部分使用的是Web API ,前端部分是普通的 HTML 页面
- 接口和前端运行在不同的端口中 所以需要在 API 的web.config 中修改 ACAO 配置所配置的地址
- 前端部分也需要在 common.js  的 ajax 方法中修改 API 所在的地址

#### 功能
- 会员的注册/登陆,个人信息查看/登出
- 做了权限拦截, 部分 API 需要登陆权限之后才能访问(个人信息/登出)

#### 问题
- 最初只想着用 前后端分离的方式去实现,但是遇到很多问题.
- 登陆时候如果被抓包比较容易在不知道密码的情况下写入cookie,从而跳过登陆页面直接能查看到个人信息(尝试在页面载入的时候给页面一个 token 但是貌似依然很容易绕过)
- web api 跨域写cookie 是之前没遇到过的问题,大部分时间浪费在这个上面
