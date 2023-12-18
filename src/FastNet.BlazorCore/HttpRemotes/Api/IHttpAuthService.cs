
using FastNet.Repositories;

namespace FastNet.BlazorCore;


/// <summary>
/// 授权服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpAuthService : IBaseHttpRemote
{
    /// <summary>
    /// 测试
    /// </summary>
    /// <returns></returns>
    [Get("/api/system/auth/sign-in")]
    Task<object> SignIn(LoginInput dto);



    /// <summary>
    /// 系统用户退出
    /// </summary>
    /// <returns></returns>
    [Patch("/api/system/auth/sign-out")]
    Task<bool> SignOut();

    /// <summary>
    /// 注册用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("/api/system/auth/register")]
    Task<SysUser> Register(RegisterInput dto);

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("/api/system/auth/change-password")]
    Task<bool> ChangePassword(ChangePasswordInput dto);

    /// <summary>
    /// 获取当前用户信息
    /// </summary>
    /// <returns></returns>
    [Get("/api/system/auth/current")]
    Task<SysUser> GetCurrent();

}
