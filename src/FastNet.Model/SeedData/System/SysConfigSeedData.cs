namespace FastNet.Model.SeedData;


/// <summary>
/// 导入系统配置表种子数据
/// </summary>
public class SysConfigSeedData : ISqlSugarEntitySeedData<SysConfig>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysConfig> SeedData()
    {
        return SeedDataUtil.GetSeedData<SysConfig>("seed_sys_config.json");
    }
}
