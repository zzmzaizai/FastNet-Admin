namespace FastNet.Model.SeedData;


/// <summary>
/// 导入字典数据表种子数据
/// </summary>
public class SysDictDataSeedData : ISqlSugarEntitySeedData<SysDictData>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysDictData> SeedData()
    {
        return SeedDataUtil.GetSeedData<SysDictData>("seed_sys_dict_data.json");
    }
}
