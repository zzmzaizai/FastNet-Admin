namespace FastNet.Model;


/// <summary>
/// 导入角色表种子数据
/// </summary>
public class SysRoleSeedData : ISqlSugarEntitySeedData<SysRole>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysRole> SeedData()
    {
        return SeedDataUtil.GetSeedData<SysRole>("seed_sys_role.json");
    }
}
