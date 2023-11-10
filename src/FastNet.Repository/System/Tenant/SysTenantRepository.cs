using Furion.LinqBuilder;

namespace FastNet.Repository;



/// <summary>
/// 租户仓储
/// </summary>
public class SysTenantRepository : DatabaseRepository<SysTenant>, ISysTenantRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    public SysTenantRepository(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// 根据主机名获取租户信息
    /// </summary>
    /// <param name="HostName">用户名</param>
    /// <returns>找不到时返回默认租户</returns>
    public async Task<SysTenant> GetTenantAsync(string HostName)
    {
        var query = Context.Queryable<SysTenant>().Where(it => !it.IsDelete && it.Status == DataStatus.Enable && !SqlFunc.IsNullOrEmpty(it.Domains) && it.Domains == $",{HostName},");
        if (query.Count() > 0)
        {
            return await query.FirstAsync();
        }
        return await Context.Queryable<SysTenant>().Where(it => !it.IsDelete && it.Status == DataStatus.Enable && it.IsDefault).FirstAsync();
    }

    /// <summary>
    /// 根据租户编号获取租户信息
    /// </summary>
    /// <param name="TenantId">租户编号</param>
    /// <returns></returns>
    public async Task<SysTenant> GetTenantAsync(long TenantId)
    {
        return await Context.Queryable<SysTenant>().FirstAsync(x => x.Id == TenantId);
    }

    /// <summary>
    /// 插入租户信息
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysTenant> InsertTenantAsync(InsertTenantInput dto)
    {
        var tenant = dto.Adapt<SysTenant>();
        await InsertAsync(tenant);
        return tenant;
    }

    /// <summary>
    /// 更新租户信息
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysTenant> UpdateTenantAsync(UpdateTenantInput dto)
    {
        var tenant = dto.Adapt<SysTenant>();

        var dbTenant = await GetTenantAsync(dto.Id);
        if (dbTenant != null)
        {
            tenant.CreateUserId = dbTenant.CreateUserId;
            tenant.CreateTime = dbTenant.CreateTime;
            tenant.IsDelete = dbTenant.IsDelete;
        }

        await UpdateAsync(tenant);
        return tenant;
    }


 
     

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysTenantPageOutput>> GetPageListAsync(QueryTenantPagedInput dto)
    {
        return await Context.Queryable<SysTenant>()
            .Where(x => x.Id > 0)
            .FiltersConditions(dto.SearchFilterConditions)
            .OrderConditions(dto.OrderConditions)
            //.Select(x => x.Adapt<SysTenantPageOutput>())
            .ToPagedListAsync<SysTenantPageOutput, SysTenant>(dto.Index, dto.Size);
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

