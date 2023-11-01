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
}

