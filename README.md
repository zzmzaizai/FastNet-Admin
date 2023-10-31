FastNet.Admin  看名字就知道这是一套可以用来快速开发的.net admin系统。前期为学习阶段，通过模仿他人的框架，是框架快速跑起来。后期根据经验调整优化加入适合个人或公司开发的功能模块。


# 双前端

计划使用双前端，其中vue采用前后端分离技术。

* BlazorUI 使用[`Ant Design Blazor`](https://github.com/ant-design-blazor/ant-design-blazor) 作为UI层

一套基于 Ant Design 和 Blazor 的企业级组件库，更新速度快，代码规范。


* SoybeanUI 使用[`Soybean`](https://github.com/honghuangdc/soybean-admin) 作为UI层 

Soybean Admin 是一个基于 Vue3、Vite3、TypeScript、NaiveUI、Pinia 和 UnoCSS 的清新优雅的中后台模版






# 进行中的任务
* [x]  框架分层搭建
* [x]  AppConfig读取配置 appsettings.json 
* [x]  AspectCore IoC
* [x]  Swagger 简单配置
* [ ]  Swagger 进阶玩法
* [ ]  JWT授权
* [ ]  SqlSugar 简单配置
* [ ]  SqlSugar 进阶玩法
* [ ]  缓存系统设计（支持分布式）
* [ ]  文件系统设计（支持分布式）
* [ ]  调度
* [x]  跨域
* [ ]  数据库设计
* [ ]  数据实体
* [ ]  数据服务
* [ ]  API控制器
* [ ]  
* [ ]  
* [ ]  
* [ ]  
* [ ]  


# 框架结构

#### FastNet.Admin
* ZmAdmin.sln `方案`
* Base `基础项目`
	* FastNet.Infrastructure `通用方法，扩展方法`
	* FastNet.SqlSugar `SqlSugar 的基础封装`
	* FastNet.Core `实体、枚举、常量`
	* FastNet.Application `仓储、中间件、日志、逻辑`
* Web `UI部分的处理项目`
	* FastNet.Blazor.Core `Blazor 页面逻辑等`
	* FastNet.Web.Core `Web 服务 API`
* AdminUI `项目UI实现`
	* FastNet.Admin.BlazorUI `Blazor 启动器`
	* FastNet.Admin.WebAPI `API 启动器`
	* FastNet.Admin.SoybeanUI `用于存放 Soybean 前端项目`
* Plugin `插件`
	* FastNet.Plugin.Tasks `任务调度插件`
* Tests `测试项目`
	* FastNet.UnitTests `测试项目`
* Solution Items `杂项`
	* .editorconfig `编辑器配置`
	* Directory.Build.props `全局项目编译信息`

	 



# 所用到的技术

* .net7
* SqlSugar
* Swagger
* JWT
* Redis
* Mapster
* Sundial


# 学习目的

配置.net Admin 后台管理程序

* 依赖注入/控制反转
* SqlSugar
* Swagger
* 数据映射
* 分布式缓存
* 安全鉴权
* 日志记录
* 定时任务
* 分布式文件系统
* Docker


 