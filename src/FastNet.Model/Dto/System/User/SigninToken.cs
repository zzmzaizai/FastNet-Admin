
namespace FastNet.Model.Dto;

/// <summary>
/// 用户登录信息DTO
/// </summary>
public class SigninToken:IRegister
{
    /// <summary>
    /// 刷新 Token
    ///</summary>
    public string RefreshToken { get; set; }


    /// <summary>
    /// 访问 Token
    ///</summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// 过期时间
    /// </summary>
    public DateTimeOffset ExpiredTime { get; set; }


    /// <summary>
    /// 用户编号
    /// </summary>
    public long UserId { get; set; }
 
    /// <summary>
    /// 账号
    ///</summary>
    public string UserName { get; set; }

    /// <summary>
    /// 邮箱
    ///</summary>
    public string Email { get; set; }


    /// <summary>
    /// 昵称
    ///</summary>
    public string NickName { get; set; }
 
    /// <summary>
    /// 是否超级管理员
    /// </summary>
    public bool IsSuperAdmin { get; set; }


    /// <summary>
    /// 注册 Mapster
    /// </summary>
    /// <param name="config"></param>
    public void Register(TypeAdapterConfig config)
    {
        //改变映射的值
        config.ForType<SysUser, SigninToken>()
            .Map(dest => dest.UserId, src => src.Id)

        ;
    }

}
