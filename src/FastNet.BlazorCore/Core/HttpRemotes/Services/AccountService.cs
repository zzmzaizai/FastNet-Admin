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
    Task<RESTfulResult<SysUser>> InsertAsync(InsertUserInput dto);

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysUser>> UpdateAsync(UpdateUserInput dto);

    /// <summary>
    /// 切换超级用户状态
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> ChangeSuperUserAsync(ChangeUserSuperInput dto);


    /// <summary>
    /// 获取单个用户信息
    /// </summary>
    /// <param name="UserName">用户名</param>
    /// <returns></returns>
    Task<RESTfulResult<SysUser>> GetUserByNameAsync(string UserName);

    /// <summary>
    /// 获取单个用户信息
    /// </summary>
    /// <param name="UserId">用户Id</param>
    /// <returns></returns>
    Task<RESTfulResult<SysUser>> GetAsync(long UserId);

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SqlSugarPagedList<SysUserPageOutput>>> GetPageAsync(QueryUserPagedInput dto);

    /// <summary>
    /// 删除单个用户
    /// </summary>
    /// <param name="UserId">用户Id</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteAsync(long UserId);

    /// <summary>
    /// 批量删除用户
    /// </summary>
    /// <param name="UserIds">用户Id集合</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteAsync(List<long> UserIds);
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
    public async Task<RESTfulResult<SysUser>> InsertAsync(InsertUserInput dto)
    {
        return await accountHttp.InsertAsync(dto);
    }

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysUser>> UpdateAsync(UpdateUserInput dto)
    {
        return await accountHttp.UpdateAsync(dto);
    }

    /// <summary>
    /// 切换超级用户状态
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> ChangeSuperUserAsync(ChangeUserSuperInput dto)
    {
        return await accountHttp.ChangeSuperUserAsync(dto);
    }


    /// <summary>
    /// 获取单个用户信息
    /// </summary>
    /// <param name="UserName">用户名</param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysUser>> GetUserByNameAsync(string UserName)
    {
        return await accountHttp.GetUserByNameAsync(UserName);
    }

    /// <summary>
    /// 获取单个用户信息
    /// </summary>
    /// <param name="UserId">用户Id</param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysUser>> GetAsync(long UserId)
    {
        return await accountHttp.GetAsync(UserId);
    }

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SqlSugarPagedList<SysUserPageOutput>>> GetPageAsync(QueryUserPagedInput dto)
    {
        return await accountHttp.GetPageAsync(dto);
    }

    /// <summary>
    /// 删除单个用户
    /// </summary>
    /// <param name="UserId">用户Id</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteAsync(long UserId)
    {
        return await accountHttp.DeleteAsync(UserId);
    }

    /// <summary>
    /// 批量删除用户
    /// </summary>
    /// <param name="UserIds">用户Id集合</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteAsync(List<long> UserIds)
    {
        return await accountHttp.DeleteAsync(UserIds);
    }


}
