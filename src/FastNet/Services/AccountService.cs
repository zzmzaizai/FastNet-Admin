

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
    [HttpPost]
    public async Task<SysUser> InsertUserAsync(InsertUserInput dto)
    {
        return await sysUserRep.InsertUserAsync(dto);
    }

    /// <summary>
    /// 获取所有用户
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<SysUser>> GetAllUsers()
    {
        return await sysUserRep.GetAllUsers();
    }



}
