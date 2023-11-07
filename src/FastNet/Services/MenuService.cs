namespace FastNet.Services;

/// <summary>
/// 菜单服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 60)]
public class MenuService : BaseApiController
{





    /// <summary>
    /// 校验权限
    /// </summary>
    /// <param name="code">权限标识</param>
    /// <returns></returns>
    public async Task<bool> CheckPermission( string code)
    {
        if (authManager.IsSuperAdmin) return true;
        return await sysMenuRep.CheckPermission(authManager.UserId, code);
    }











    }
