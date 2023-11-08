namespace FastNet.Repositories;



/// <summary>
/// 
/// </summary>
public class SysApiResourceRepository : DatabaseRepository<SysApiResource>, ISysApiResourceRepository
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysApiResourcePageOutput>> GetPageListAsync(QueryApiResourcePagedInput dto)
    {
        return await Context.Queryable<SysApiResource>()
            .Where(x => x.Id > 0)
            .FiltersConditions(dto.SearchFilterConditions)
            .OrderConditions(dto.OrderConditions)
            //.Select(x => x.Adapt<SysApiResourcePageOutput>())
            .ToPagedListAsync<SysApiResourcePageOutput, SysApiResource>(dto.Index, dto.Size);
    }


    /// <summary>
    /// 根据API资源Id获取API资源
    /// </summary>
    /// <param name="ApiResourceId">API资源编号</param>
    /// <returns></returns>
    public async Task<SysApiResource> GetApiResourceAsync(long ApiResourceId)
    {
        return await Context.Queryable<SysApiResource>().FirstAsync(x => x.Id == ApiResourceId);
    }

    /// <summary>
    /// 插入API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysApiResource> InsertApiResourceAsync(InsertApiResourceInput dto)
    {
        var user = dto.Adapt<SysApiResource>();
        await InsertAsync(user);
        return user;
    }

    /// <summary>
    /// 更新API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysApiResource> UpdateApiResourceAsync(UpdateApiResourceInput dto)
    {
        var role = dto.Adapt<SysApiResource>();

        var dbRole = await GetApiResourceAsync(dto.Id);
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

