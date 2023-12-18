
using Furion.UnifyResult;

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
    Task<RESTfulResult<SigninToken>> SignIn(LoginInput dto);

    /// <summary>
    /// 系统用户退出
    /// </summary>
    /// <returns></returns>
    Task<RESTfulResult<bool>> SignOut();


    /// <summary>
    /// 修改密码
    /// </summary>
    /// <returns></returns>
    Task<RESTfulResult<bool>> ChangePassword(ChangePasswordInput dto);


    /// <summary>
    /// 注册用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysUser>> Register(RegisterInput dto);

    /// <summary>
    /// 获取当前用户信息
    /// </summary>
    /// <returns></returns>
    Task<RESTfulResult<SysUser>> GetCurrent();
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
    public async Task<RESTfulResult<SigninToken>> SignIn(LoginInput dto)
    {
         return await authHttp.SignIn(dto);
    }

    /// <summary>
    /// 系统用户退出
    /// </summary>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> SignOut()
    {
        return await authHttp.SignOut();
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> ChangePassword(ChangePasswordInput dto)
    {
        return await authHttp.ChangePassword(dto);
    }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<RESTfulResult<SysUser>> Register(RegisterInput dto)
    {
        return await authHttp.Register(dto);
    }

    /// <summary>
    /// 获取当前用户信息
    /// </summary>
    /// <returns></returns>
    public async Task<RESTfulResult<SysUser>> GetCurrent()
    {
        return await authHttp.GetCurrent();
    }


}