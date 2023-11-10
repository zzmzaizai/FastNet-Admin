namespace FastNet.BlazorCore.HttpRemotes;


/// <summary>
/// 账号服务接口
/// </summary>
public interface IAccountService : ITransient
{

    /// <summary>
    /// 插入用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysUser> InsertAsync(InsertUserInput dto);

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysUser> UpdateAsync(UpdateUserInput dto);

    /// <summary>
    /// 切换超级用户状态
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<bool> ChangeSuperUserAsync(ChangeUserSuperInput dto);


    /// <summary>
    /// 获取单个用户信息
    /// </summary>
    /// <param name="UserName">用户名</param>
    /// <returns></returns>
    Task<SysUser> GetUserByNameAsync(string UserName);

    /// <summary>
    /// 获取单个用户信息
    /// </summary>
    /// <param name="UserId">用户Id</param>
    /// <returns></returns>
    Task<SysUser> GetAsync(long UserId);

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysUserPageOutput>> GetPageAsync([FromQuery] QueryUserPagedInput dto);
}


/// <summary>
/// 账号服务
/// </summary>
public class AccountService : IAccountService
{
    /// <summary>
    /// 请求映射接口
    /// </summary>
    protected IHttpAccountService accountHttp { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_accountHttp"></param>
    public AccountService(IHttpAccountService _accountHttp)
    {
        accountHttp = _accountHttp;
    }

    /// <summary>
    /// 插入用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysUser> InsertAsync(InsertUserInput dto)
    {
        return await accountHttp.InsertAsync(dto);
    }

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysUser> UpdateAsync(UpdateUserInput dto)
    {
        return await accountHttp.UpdateAsync(dto);
    }

    /// <summary>
    /// 切换超级用户状态
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<bool> ChangeSuperUserAsync(ChangeUserSuperInput dto)
    {
        return await accountHttp.ChangeSuperUserAsync(dto);
    }


    /// <summary>
    /// 获取单个用户信息
    /// </summary>
    /// <param name="UserName">用户名</param>
    /// <returns></returns>
    public async Task<SysUser> GetUserByNameAsync(string UserName)
    {
        return await accountHttp.GetUserByNameAsync(UserName);
    }

    /// <summary>
    /// 获取单个用户信息
    /// </summary>
    /// <param name="UserId">用户Id</param>
    /// <returns></returns>
    public async Task<SysUser> GetAsync(long UserId)
    {
        return await accountHttp.GetAsync(UserId);
    }

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysUserPageOutput>> GetPageAsync([FromQuery] QueryUserPagedInput dto)
    {
        return await accountHttp.GetPageAsync(dto);
    }
 

}
