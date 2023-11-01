namespace FastNet.Core;


/// <summary>
/// 导入菜单表种子数据
/// </summary>
public class SysMenuSeedData : ISqlSugarEntitySeedData<SysMenu>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysMenu> SeedData()
    {
        return SeedDataUtil.GetSeedData<SysMenu>("seed_sys_menu.json");
    }
}
