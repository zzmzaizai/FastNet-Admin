namespace FastNet.Repositories;



/// <summary>
/// 
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
}

