# 功能点大纲设计

次文档主要用于设计草稿，整理的功能在此编写，完善后再移动到详细的文档中



# 多租户设计原理

* 利用域名读取该域名绑定的租户，如果未取到域名则分配为默认租户
* 后台右上角设计租户切换选项，只允许超级管理员操作
* 每个数据表中均使用租户Id进行数据隔离,利用中间件AOP加入租户编号的数据库操作
* 用户分为超级管理员、租户管理员、普通用户几类
    * 超级管理员 - 可对租户数据进行操作，可以切换租户操作所有数据
    * 租户管理员 - 只能对本租户内的数据进行操作
    * 普通用户 - 只能使用管理员分配的有限权力




# 后台菜单&模块

* 系统管理
    * 租户 
    * 菜单管理
    * 接口管理
    * 客户端管理
    * 附件管理
    * 任务管理
    * 字典管理
* 用户中心
    * 用户管理
    * 组织管理
    * 角色管理










租户
资源（菜单）
接口
部门
用户
角色
*.角色关联资源
客户端
*.客户端关联接口



字典
*.职位

附件