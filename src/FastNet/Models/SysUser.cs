namespace FastNet.Models;


/// <summary>
/// 用户信息表实体
///</summary>
[SugarTable("sys_user", TableDescription = "用户表")]
[Tenant("FastNet")]
public class SysUser : DataEntityBase
{

    /// <summary>
    /// 账号
    ///</summary>
    [SugarColumn(ColumnDescription = "账号", Length = 50, IsNullable = false)]
    public virtual string UserName { get; set; }


    /// <summary>
    /// 密码
    ///</summary>
    [SugarColumn(ColumnDescription = "密码", Length = 100, IsNullable = false)]
    public virtual string Password { get; set; }


    /// <summary>
    /// 密钥
    ///</summary>
    [SugarColumn(ColumnDescription = "密钥", Length = 100, IsNullable = false)]
    public virtual string Secret { get; set; }

    /// <summary>
    /// 邮箱
    ///</summary>
    [SugarColumn(ColumnDescription = "邮箱", Length = 50, IsNullable = true)]
    public virtual string Email { get; set; }


    /// <summary>
    /// 昵称
    ///</summary>
    [SugarColumn(ColumnDescription = "昵称", Length = 50, IsNullable = true)]
    public virtual string NickName { get; set; }


    /// <summary>
    /// 全名
    ///</summary>
    [SugarColumn(ColumnDescription = "全名", Length = 30, IsNullable = true)]
    public virtual string FullName { get; set; }

    /// <summary>
    /// 头像
    ///</summary>
    [SugarColumn(ColumnDescription = "头像", Length = 200, IsNullable = true)]
    public virtual string Avatar { get; set; }


    /// <summary>
    /// 电话
    ///</summary>
    [SugarColumn(ColumnDescription = "电话", Length = 20, IsNullable = true)]
    public virtual string Tel { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [SugarColumn(ColumnDescription = "性别", Length = 50, IsNullable = true)]
    public virtual string Sex { get; set; }

    /// <summary>
    /// 职位
    /// </summary>
    [SugarColumn(ColumnDescription = "职位", Length = 50, IsNullable = true)]
    public virtual string Title { get; set; }


    /// <summary>
    /// 是否超级管理员
    /// </summary>
    [SugarColumn(ColumnDescription = "是否超级管理员", IsNullable = false, DefaultValue = "0")]
    public virtual bool IsSuperAdmin { get; set; }


    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态", IsNullable = false)]
    public virtual DataUserStatus Status { get; set; }
}
