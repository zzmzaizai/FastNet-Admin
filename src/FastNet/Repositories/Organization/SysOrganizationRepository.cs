namespace FastNet.Repositories;



/// <summary>
/// 
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
}

