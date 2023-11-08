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
}

