namespace FastNet.Model.SeedData;


/// <summary>
/// 导入用户表种子数据
/// </summary>
public class SysUserSeedData : ISqlSugarEntitySeedData<SysUser>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysUser> SeedData()
    {
        return SeedDataUtil.GetSeedData<SysUser>("seed_sys_user.json");
    }
}
