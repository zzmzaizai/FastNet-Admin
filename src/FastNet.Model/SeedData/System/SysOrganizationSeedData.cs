namespace FastNet.Model;


/// <summary>
/// 导入组织部门表种子数据
/// </summary>
public class SysOrganizationSeedData : ISqlSugarEntitySeedData<SysOrganization>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysOrganization> SeedData()
    {
        return SeedDataUtil.GetSeedData<SysOrganization>("seed_sys_organization.json");
    }
}
