namespace FastNet.Repository;



/// <summary>
/// 组织架构仓储
/// </summary>
public class SysOrganizationRepository : DatabaseRepository<SysOrganization>, ISysOrganizationRepository
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysOrganizationPageOutput>> GetPageListAsync(QueryOrganizationPagedInput dto)
    {
        return await Context.Queryable<SysOrganization>()
            .Where(x => x.Id > 0)
            .FiltersConditions(dto.SearchFilterConditions)
            .OrderConditions(dto.OrderConditions)
            //.Select(x => x.Adapt<SysOrganizationPageOutput>())
            .ToPagedListAsync<SysOrganizationPageOutput, SysOrganization>(dto.Index, dto.Size);
    }


    /// <summary>
    /// 根据组织架构Id获取组织架构
    /// </summary>
    /// <param name="OrganizationId">组织架构编号</param>
    /// <returns></returns>
    public async Task<SysOrganization> GetOrganizationAsync(long OrganizationId)
    {
        return await Context.Queryable<SysOrganization>().FirstAsync(x => x.Id == OrganizationId);
    }

    /// <summary>
    /// 插入组织架构
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysOrganization> InsertOrganizationAsync(InsertOrganizationInput dto)
    {
        var user = dto.Adapt<SysOrganization>();
        await InsertAsync(user);
        return user;
    }

    /// <summary>
    /// 更新组织架构
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysOrganization> UpdateOrganizationAsync(UpdateOrganizationInput dto)
    {
        var role = dto.Adapt<SysOrganization>();

        var dbRole = await GetOrganizationAsync(dto.Id);
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

