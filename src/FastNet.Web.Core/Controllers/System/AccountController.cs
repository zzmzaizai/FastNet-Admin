

namespace FastNet.Web.Core.Controllers;

/// <summary>
/// 账号服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 100)]
public class AccountController : BaseApiController
{

 



    /// <summary>
    /// 随便添加个用户
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<SysUser> AddUser(bool IsSuperAdmin)
    {
        return await sysUserRep.AddUser(IsSuperAdmin);
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
