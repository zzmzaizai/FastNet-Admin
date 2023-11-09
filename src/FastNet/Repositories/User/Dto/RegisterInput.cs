namespace FastNet.Repositories;

/// <summary>
/// 用户注册输入项
/// </summary>
public class RegisterInput
{
    /// <summary>
    /// 账号
    ///</summary>
    [Required]
    public string UserName { get; set; }

    /// <summary>
    /// 密码
    ///</summary>
    [Required]
    public string Password { get; set; }

    /// <summary>
    /// 二次输入密码
    /// </summary>
    [Required]
    [Compare(nameof(Password))]
    public string SecondaryPassword { get; set; }

    /// <summary>
    /// 邮箱
    ///</summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; }


    /// <summary>
    /// 昵称
    ///</summary>
    public string NickName { get; set; }
}

