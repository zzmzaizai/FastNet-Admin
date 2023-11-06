namespace FastNet.Model;


/// <summary>
/// 导入API资源表种子数据
/// </summary>
public class SysApiResourceSeedData : ISqlSugarEntitySeedData<SysApiResource>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysApiResource> SeedData()
    {
        return SeedDataUtil.GetSeedData<SysApiResource>("seed_sys_api_resource.json");
    }
}
