namespace FastNet.Repositories;



/// <summary>
/// 客户端APP仓储
/// </summary>
public class SysClientAppRepository : DatabaseRepository<SysClientApp>, ISysClientAppRepository
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysClientAppPageOutput>> GetPageListAsync(QueryClientAppPagedInput dto)
    {
        return await Context.Queryable<SysClientApp>()
            .Where(x => x.Id > 0)
            .FiltersConditions(dto.SearchFilterConditions)
            .OrderConditions(dto.OrderConditions)
            //.Select(x => x.Adapt<SysClientAppPageOutput>())
            .ToPagedListAsync<SysClientAppPageOutput, SysClientApp>(dto.Index, dto.Size);
    }


    /// <summary>
    /// 根据客户端APPId获取客户端APP
    /// </summary>
    /// <param name="ClientAppId">客户端APP编号</param>
    /// <returns></returns>
    public async Task<SysClientApp> GetClientAppAsync(long ClientAppId)
    {
        return await Context.Queryable<SysClientApp>().FirstAsync(x => x.Id == ClientAppId);
    }

    /// <summary>
    /// 插入客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysClientApp> InsertClientAppAsync(InsertClientAppInput dto)
    {
        var user = dto.Adapt<SysClientApp>();
        await InsertAsync(user);
        return user;
    }

    /// <summary>
    /// 更新客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysClientApp> UpdateClientAppAsync(UpdateClientAppInput dto)
    {
        var role = dto.Adapt<SysClientApp>();

        var dbRole = await GetClientAppAsync(dto.Id);
        if (dbRole != null)
        {
            role.CreateUserId = dbRole.CreateUserId;
            role.CreateTime = dbRole.CreateTime;
            role.TenantId = dbRole.TenantId;
            role.IsDelete = dbRole.IsDelete;
        }
        await UpdateAsync(role);
        return role;
    }
}

