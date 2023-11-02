namespace FastNet.Application;


/// <summary>
/// 
/// </summary>
public interface ISysTenantRepository : ITransient
{
    /// <summary>
    /// 根据主机名获取租户信息
    /// </summary>
    /// <param name="HostName"></param>
    /// <returns>主机名未找到时返回默认租户</returns>
    SysTenant GetItemByHost(string HostName);

    /// <summary>
    /// 根据租户编号查询租户信息
    /// </summary>
    /// <param name="TenantId"></param>
    /// <returns></returns>
    Task<SysTenant> GetItemByTenantId(long TenantId);

    /// <summary>
    /// 获取所有租户
    /// </summary>
    /// <returns></returns>
    Task<List<SysTenant>> GetAllList();

    /// <summary>
    /// 填充默认的租户
    /// </summary>
    /// <returns></returns>
    Task<SysTenant> FillTenant(bool IsDefault, string DomainName);
}

