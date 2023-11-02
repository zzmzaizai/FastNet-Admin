using FastNet.Infrastructure.Extensions;
using StackExchange.Profiling.Internal;
using System.Collections.Generic;

namespace FastNet.Application;



/// <summary>
/// 
/// </summary>
public class SysTenantRepository : DatabaseRepository<SysTenant>, ISysTenantRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SysTenantRepository(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }



    /// <summary>
    /// 根据主机名获取租户信息
    /// </summary>
    /// <param name="HostName"></param>
    /// <returns>主机名未找到时返回默认租户</returns>
    public SysTenant GetItemByHost(string HostName)
    {
        var query = Context.Queryable<SysTenant>().Where(it => !it.IsDelete && it.Status == DataStatus.Enable && !SqlFunc.IsNullOrEmpty(it.Domains) && it.Domains == $",{HostName},");
        if(query.Count() > 0)
        {
            return query.Single();
        }
        return Context.Queryable<SysTenant>().Where(it => !it.IsDelete && it.Status == DataStatus.Enable && it.IsDefault).Single();
    }

    /// <summary>
    /// 根据租户编号查询租户信息
    /// </summary>
    /// <param name="TenantId"></param>
    /// <returns></returns>
    public async Task<SysTenant> GetItemByTenantId(long TenantId)
    {
        return await  Context.Queryable<SysTenant>().InSingleAsync(TenantId);
    }

    /// <summary>
    /// 获取所有租户
    /// </summary>
    /// <returns></returns>
    public async Task<List< SysTenant>> GetAllList()
    {
        return await Context.Queryable<SysTenant>().ToListAsync();
    }



    /// <summary>
    /// 填充默认的租户
    /// </summary>
    /// <returns></returns>
    public async Task<SysTenant> FillTenant(bool IsDefault,string DomainName)
    {
      
            if(IsDefault)
            {
                var Query = Context.Queryable<SysTenant>().Where(it => !it.IsDelete && it.Status == DataStatus.Enable && it.IsDefault);
                if (!Query.Any())
                {
                    //不存在则填充
                    await InsertAsync(new SysTenant
                    {
                        Name = "Default",
                        Domains = $",{_httpContextAccessor.HttpContext.Request.Host.ToString()},",
                        IsDefault = true,
                        Email = "washala@qq.com",
                        Tel = "",
                        Contact = "",
                        Status = DataStatus.Enable
                    });
                }
            }else
            {
                //不存在则填充
                await InsertAsync(new SysTenant
                {
                    Name = DomainName,
                    Domains = $",{DomainName},",
                    IsDefault = false,
                    Email = $"{Guid.NewGuid()}@qq.com",
                    Tel = "",
                    Contact = "",
                    Status = DataStatus.Enable
                }); ;
            }
        return await Context.Queryable<SysTenant>().Where(it => !it.IsDelete && it.Status == DataStatus.Enable).OrderByDescending(x=>x.CreateTime).FirstAsync();
    }


}

