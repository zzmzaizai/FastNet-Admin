
namespace FastNet.Repositories;

/// <summary>
/// 用户插入
/// </summary>
public class InsertUserInput
{
    /// <summary>
    /// 账号
    ///</summary>
    public string UserName { get; set; }


    /// <summary>
    /// 密码
    ///</summary>
    public string Password { get; set; }


    /// <summary>
    /// 邮箱
    ///</summary>
    public string Email { get; set; }


    /// <summary>
    /// 昵称
    ///</summary>
    public string NickName { get; set; }


    /// <summary>
    /// 全名
    ///</summary>
    public string FullName { get; set; }

    /// <summary>
    /// 头像
    ///</summary>
    public string Avatar { get; set; }


    /// <summary>
    /// 电话
    ///</summary>
    public string Tel { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    public string Sex { get; set; }

    /// <summary>
    /// 职位
    /// </summary>
    public string Title { get; set; }


    /// <summary>
    /// 是否超级管理员
    /// </summary>
    public bool IsSuperAdmin { get; set; }


    /// <summary>
    /// 状态
    /// </summary>
    public DataUserStatus Status { get; set; }
}
