namespace FastNet.Services;

/// <summary>
/// 账号服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 90)]
public class AccountService : BaseApiController
{

    /// <summary>
    /// 插入用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysUser> InsertAsync(InsertUserInput dto)
    {
        return await sysUserRep.InsertUserAsync(dto);
    }

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysUser> UpdateAsync(UpdateUserInput dto)
    {
        return await sysUserRep.UpdateUserAsync(dto);
    }

    /// <summary>
    /// 获取单个用户信息
    /// </summary>
    /// <param name="UserName">用户名</param>
    /// <returns></returns>
    public async Task<SysUser> GetUserByNameAsync(string UserName)
    {
        return await sysUserRep.GetUserAsync(UserName);
    }

    /// <summary>
    /// 获取单个用户信息
    /// </summary>
    /// <param name="UserId">用户Id</param>
    /// <returns></returns>
    public async Task<SysUser> GetAsync(long UserId)
    {
        return await sysUserRep.GetUserAsync(UserId);
    }

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysUserPageOutput>> GetPageAsync([FromQuery] QueryUserPagedInput dto)
    {
        return await sysUserRep.GetPageListAsync(dto);
    }



}
