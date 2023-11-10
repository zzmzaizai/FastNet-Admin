namespace FastNet.Model.SeedData;


/// <summary>
/// 导入字典类型表种子数据
/// </summary>
public class SysDictTypeSeedData : ISqlSugarEntitySeedData<SysDictType>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysDictType> SeedData()
    {
        return SeedDataUtil.GetSeedData<SysDictType>("seed_sys_dict_type.json");
    }
}
