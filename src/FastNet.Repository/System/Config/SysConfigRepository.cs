namespace FastNet.Repository;



/// <summary>
/// 
/// </summary>
public class SysConfigRepository : DatabaseRepository<SysConfig>, ISysConfigRepository
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysConfigPageOutput>> GetPageListAsync(QueryConfigPagedInput dto)
    {
        return await Context.Queryable<SysConfig>()
            .Where(x => x.Id > 0)
            .FiltersConditions(dto.SearchFilterConditions)
            .OrderConditions(dto.OrderConditions)
            //.Select(x => x.Adapt<SysConfigPageOutput>())
            .ToPagedListAsync<SysConfigPageOutput, SysConfig>(dto.Index, dto.Size);
    }
}

