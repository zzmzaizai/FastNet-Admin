namespace FastNet.Core;


/// <summary>
/// 导入系统关系表种子数据
/// </summary>
public class SysRelationSeedData : ISqlSugarEntitySeedData<SysRelation>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysRelation> SeedData()
    {
        return SeedDataUtil.GetSeedData<SysRelation>("seed_sys_relation.json");
    }
}
