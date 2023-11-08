namespace FastNet.Repositories;



/// <summary>
/// 
/// </summary>
public class SysRelationRepository : DatabaseRepository<SysRelation>, ISysRelationRepository
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysRelationPageOutput>> GetPageListAsync(QueryRelationPagedInput dto)
    {
        return await Context.Queryable<SysRelation>()
            .Where(x => x.Id > 0)
            .FiltersConditions(dto.SearchFilterConditions)
            .OrderConditions(dto.OrderConditions)
            //.Select(x => x.Adapt<SysRelationPageOutput>())
            .ToPagedListAsync<SysRelationPageOutput, SysRelation>(dto.Index, dto.Size);
    }
}

