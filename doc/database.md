# 数据表设计

#### SysTenant `租户表`

* Id `编号`
* Name `租户名、公司名`
* Domains `绑定域名` - 多个域名逗号间隔
* StartDate `开始时间`
* EndDate `结束时间`
* Tel  `电话`
* Email  `邮箱`
* Contact  `联系人`
* Remark `备注`
* IsDefault `默认站点`
* Status `状态` - 租户状态枚举


#### SysRelation `系统关系表`

* Id `编号`
* SourceId `源编号`
* TargetId `目标编号`
* RelationType `关系类型` - 用户角色、用户组织、角色组织、角色菜单、客户端API
* ExtraData `额外数据`


#### SysUser `用户表`

* Id `用户编号`
* UserName `用户名`
* Password `密码`
* Secret `密钥` - 用户密码二次加密
* Email `邮箱`
* NickName `昵称`
* FullName `全名`
* Tel  `电话`
* Avatar  `头像`
* Sex `性别` - 字典编号
* Title `职位` - 字典编号
* IsSuperAdmin `是否超级管理员`
* Status `状态` - 用户状态枚举
* LoginIP  `登录IP`
* LoginDate `登录时间`



#### SysOrganization `组织部门表`

* Id `组织编号`
* Name `名称`
* ParentId `上级组织编号`
* Leader `负责人`
* Tel  `电话`
* Email `邮箱`
* Remark `备注`
* Order `排序`
* Status `状态` - 组织部门状态枚举


#### SysRole `角色表`

* Id `角色编号`
* Name `名称`
* Remark `备注`
* Status `状态` - 角色状态枚举


#### SysMenu `菜单表`

* Id `角色编号`
* Name `名称`
* ParentId `上级菜单编号`
* Router `页面路由`
* Path `页面资源路径`
* Actions `拥有动作集合` - 多个动作枚举之间逗号分割
* Order `排序`
* Status `状态` - 菜单状态枚举

#### SysApiResource `Api资源表`

* Id `API编号`
* Name `名称`
* Group `分组名称` - 用字典定义资源分组
* Router `API路由`
* Path `API资源路径`
* Method `请求方法`
* Summary `摘要`
* Remark `备注`
* Order `排序`
* Status `状态` - API状态枚举

#### SysClientApp `客户端应用表`

* Id `客户端编号`
* Name `名称`
* ClientCode `客户端编码`
* SecretKey `私钥`
* Tel  `电话`
* Email `邮箱`
* Contact  `联系人`
* Remark `备注`
* Status `状态` - 客户端状态枚举





#### SysDictType `字典类型表`

* Id `编号`
* DictTypeName `字典类型名称`
* DictType `字典类型`
* Order `排序`

#### SysDictData `字典数据表`


* Id `编号`
* DictType `字典类型编号`
* DictName `字典名称`
* DictValue `字典名称`
* Order `排序`
* Status `状态` - 字典状态枚举

#### SysConfig `系统配置表`

* Id `编号`
* Lable `配置名称`
* Key `配置Key`
* Value `配置值`



## 后一期再设计的表

#### SysTask `任务配置表`

#### SysTaskLog `任务日志表`

#### SysOperLog `操作日志表`

#### SysLoginLog `登录日志表`