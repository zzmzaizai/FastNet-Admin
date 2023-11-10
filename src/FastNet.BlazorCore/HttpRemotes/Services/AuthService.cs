
namespace FastNet.BlazorCore.HttpRemotes;

/// <summary>
/// 授权服务接口
/// </summary>
public interface IAuthService: ITransient
{
    /// <summary>
    /// 系统用户登录
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<object> SignIn(LoginInput dto);

    /// <summary>
    /// 系统用户退出
    /// </summary>
    /// <returns></returns>
    Task<bool> SignOut();


    /// <summary>
    /// 注册用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysUser> Register(RegisterInput dto);

    /// <summary>
    /// 获取当前用户信息
    /// </summary>
    /// <returns></returns>
    Task<SysUser> GetCurrent();
}

/// <summary>
/// 授权服务
/// </summary>
public class AuthService : IAuthService
{
    /// <summary>
    /// 授权请求映射接口
    /// </summary>
    protected IHttpAuthService authHttp {  get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_authHttp"></param>
    public AuthService(IHttpAuthService _authHttp)
    {
        authHttp = _authHttp;
    }



    /// <summary>
    /// 系统用户登录
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<object> SignIn(LoginInput dto)
    {
         return await authHttp.SignIn(dto);
    }

    /// <summary>
    /// 系统用户退出
    /// </summary>
    /// <returns></returns>
    public async Task<bool> SignOut()
    {
        return await authHttp.SignOut();
    }


    /// <summary>
    /// 注册用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysUser> Register(RegisterInput dto)
    {
        return await authHttp.Register(dto);
    }

    /// <summary>
    /// 获取当前用户信息
    /// </summary>
    /// <returns></returns>
    public async Task<SysUser> GetCurrent()
    {
        return await authHttp.GetCurrent();
    }


}