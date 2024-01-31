
using SqlSugar;

namespace FastNet.BlazorCore;


/// <summary>
/// 账户服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpAccountService : IBaseHttpRemote
{
    /// <summary>
    /// 插入用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("api/system/account")]
    Task<RESTfulResult<SysUser>> InsertAsync([Body("application/json")] InsertUserInput dto);

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Put("api/system/account")]
    Task<RESTfulResult<SysUser>> UpdateAsync([Body("application/json")] UpdateUserInput dto);

    /// <summary>
    /// 切换超级用户状态
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("api/system/account/change-super-user")]
    Task<RESTfulResult<bool>> ChangeSuperUserAsync([Body("application/json")] ChangeUserSuperInput dto);


    /// <summary>
    /// 获取单个用户信息
    /// </summary>
    /// <param name="UserName">用户名</param>
    /// <returns></returns>
    [Get("api/system/account/user-by-name/{username}")]
    Task<RESTfulResult<SysUser>> GetUserByNameAsync(string UserName);

    /// <summary>
    /// 获取单个用户信息
    /// </summary>
    /// <param name="UserId">用户Id</param>
    /// <returns></returns>
    [Get("api/system/account/{userid}")]
    Task<RESTfulResult<SysUser>> GetAsync(long UserId);

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Get("api/system/account/page-list")]
    Task<RESTfulResult<SqlSugarPagedList<SysUserPageOutput>>> GetPageAsync([FromQuery] QueryUserPagedInput dto);


    /// <summary>
    /// 删除单个用户
    /// </summary>
    /// <param name="UserId">用户Id</param>
    /// <returns></returns>
    [Delete("api/system/account/{userid}")]
    Task<RESTfulResult<bool>> DeleteAsync(long UserId);


    /// <summary>
    /// 批量删除用户
    /// </summary>
    /// <param name="UserIds">用户Id集合</param>
    /// <returns></returns>
    [Delete("api/system/account")]
    Task<RESTfulResult<bool>> DeleteAsync([FromQuery] List<long> UserIds);
}
