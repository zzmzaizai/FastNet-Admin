namespace FastNet.Repositories;

/// <summary>
/// 用户注册输入项
/// </summary>
public class RegisterInput
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
    /// 二次输入密码
    /// </summary>
    public string SecondaryPassword { get; set; }

    /// <summary>
    /// 邮箱
    ///</summary>
    public string Email { get; set; }


    /// <summary>
    /// 昵称
    ///</summary>
    public string NickName { get; set; }
}

