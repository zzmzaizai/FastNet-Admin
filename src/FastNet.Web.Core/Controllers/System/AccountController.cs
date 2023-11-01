

namespace FastNet.Web.Core.Controllers;

/// <summary>
/// 账号服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 100)]
public class AccountController : IDynamicApiController
{

    private readonly ISysUserRepository _userRep;
    public AccountController(ISysUserRepository userRep)
    {
        _userRep = userRep;
    }

    /// <summary>
    /// 获取信息(测试用)
    /// </summary>
    /// <returns></returns>
    public string GetInfo()
    {
        return $"现在时间是{DateTime.Now}";
    }

    /// <summary>
    /// 随便添加个用户
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<SysUser> AddUser()
    {
        return await _userRep.AddUser();
    }

    /// <summary>
    /// 获取所有用户
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<SysUser>> GetAllUsers()
    {
        return await _userRep.GetAllUsers();
    }



}
