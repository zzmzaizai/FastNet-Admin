namespace FastNet.Models;


/// <summary>
/// 导入客户端APP表种子数据
/// </summary>
public class SysClientAppSeedData : ISqlSugarEntitySeedData<SysClientApp>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysClientApp> SeedData()
    {
        return SeedDataUtil.GetSeedData<SysClientApp>("seed_sys_client_app.json");
    }
}
