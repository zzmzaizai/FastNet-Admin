namespace FastNet.Repositories;



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
    /// 获取分页数据
    /// </summary>
    /// <returns></returns>
    public async Task<List< SysTenant>> GetPage(TenantPagedInput input)
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


    #region "公用方法"


    /// <summary>
    /// 获取Sqlsugar的ISugarQueryable
    /// </summary>  
    /// <param name="input"></param>
    /// <returns></returns>
    private async Task<ISugarQueryable<SysTenant>> GetQuery(TenantPagedInput input)
    {
        var query = Context.Queryable<SysTenant>()
             .WhereIF(!string.IsNullOrEmpty(input.SearchText), u => u.Name.Contains(input.SearchText) || u.Domains.Contains(input.SearchText))//根据关键字查询
              .OrderBy(u => u.Id)//排序
              .OrderByIF(!string.IsNullOrEmpty(input.SortField), $"{input.SortField} {input.SortOrder}");




        //var query = Context.Queryable<SysTenant>().LeftJoin<SysOrg>((u, o) => u.OrgId == o.Id)
        //    .LeftJoin<SysPosition>((u, o, p) => u.PositionId == p.Id)
        //    .WhereIF(input.OrgId > 0, u => orgIds.Contains(u.OrgId))//根据组织
        //    .WhereIF(input.Expression != null, input.Expression?.ToExpression())//动态查询
        //    .WhereIF(!string.IsNullOrEmpty(input.UserStatus), u => u.UserStatus == input.UserStatus)//根据状态查询
        //    .WhereIF(!string.IsNullOrEmpty(input.SearchKey), u => u.Name.Contains(input.SearchKey) || u.Account.Contains(input.SearchKey))//根据关键字查询
        //    .OrderByIF(!string.IsNullOrEmpty(input.SortField), $"u.{input.SortField} {input.SortOrder}")
        //    .OrderBy(u => u.Id)//排序
        //    .Select((u, o, p) => new SysUser
        //    {
        //        Id = u.Id.SelectAll(),
        //        OrgName = o.Name,
        //        PositionName = p.Name,
        //        OrgNames = o.Names
        //    })
        //    .Mapper(u =>
        //    {
        //        u.Password = null;//密码清空
        //        u.Phone = CryptogramUtil.Sm4Decrypt(u.Phone);//手机号解密
        //    });
        return query;
    }


    #endregion


}

