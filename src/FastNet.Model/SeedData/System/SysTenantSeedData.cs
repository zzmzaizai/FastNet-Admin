namespace FastNet.Model;


/// <summary>
/// 导入租户表种子数据
/// </summary>
public class SysTenantSeedData : ISqlSugarEntitySeedData<SysTenant>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysTenant> SeedData()
    {
        return SeedDataUtil.GetSeedData<SysTenant>("seed_sys_tenant.json");
    }
}
