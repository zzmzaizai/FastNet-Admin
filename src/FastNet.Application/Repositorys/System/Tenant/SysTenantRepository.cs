using FastNet.Infrastructure.Extensions;

namespace FastNet.Application;



/// <summary>
/// 
/// </summary>
public class SysTenantRepository : DatabaseRepository<SysTenant>, ISysTenantRepository
{
    /// <summary>
    /// 根据主机名获取租户信息
    /// </summary>
    /// <param name="HostName"></param>
    /// <returns>主机名未找到时返回默认租户</returns>
    public SysTenant GetItemByHost(string HostName)
    {
        var query = Context.Queryable<SysTenant>().Where(it => !it.IsDelete && it.Status == DataStatus.Enable && it.Domains.SplitBySignWithoutEmpty(",").Where(x => x.Equals(HostName, StringComparison.OrdinalIgnoreCase)).Any());
        if(query.Any())
        {
            return query.First();
        }
        return Context.Queryable<SysTenant>().Where(it => !it.IsDelete && it.Status == DataStatus.Enable && it.IsDefault).First();
    }




}

