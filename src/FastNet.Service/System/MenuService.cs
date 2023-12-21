namespace FastNet.Service;

/// <summary>
/// 菜单服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 60)]
public class MenuService : BaseApiController
{

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public async Task<List<SysMenu>> GetListAsync()
    {
        return await sysMenuRep.GetListAsync();
    }
 
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


    /// <summary>
    /// 获取指定用户的访问权限集合
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    public async Task<List<CheckPermissionOutput>> GetAuthButtonCodeList(long userId)
    {
        return await sysMenuRep.GetAuthButtonCodeList(userId);
    }



    /// <summary>
    /// 获取用户菜单列表
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<List<SysMenu>> GetMenuListAsync(long userId)
    {
        return await sysMenuRep.GetMenuListAsync(userId);
    }


    /// <summary>
    /// 获取用户菜单树形列表
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<List<SysMenu>> GetMenuTreeAsync(long userId)
    {
        return await sysMenuRep.GetMenuTreeAsync(userId);
    }


    /// <summary>
    /// 根据菜单Id获取菜单
    /// </summary>
    /// <param name="MenuId">菜单编号</param>
    /// <returns></returns>
    public async Task<SysMenu> GetAsync(long MenuId)
    {
        return await sysMenuRep.GetMenuAsync(MenuId);
    }

    /// <summary>
    /// 插入菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysMenu> InsertAsync(InsertMenuInput dto)
    {
        return await sysMenuRep.InsertMenuAsync(dto);
    }

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysMenu> UpdateAsync(UpdateMenuInput dto)
    {
        return await sysMenuRep.UpdateMenuAsync(dto);
    }



    /// <summary>
    /// 下载种子数据
    /// </summary>
    /// <returns></returns>
    [HttpGet, NonUnify]
    public async Task<IActionResult> DownloadSeedDataAsync()
    {
        var list = await sysMenuRep.GetListAsync();

        var json = new SeedDataRecords<SysMenu>
        {
            Records = list
        }.ToJson();

        return new FileContentResult(Encoding.UTF8.GetBytes(json), "application/octet-stream")
        {
            FileDownloadName = "seed_sys_menu.json" // 配置文件下载显示名
        };
    }


}
