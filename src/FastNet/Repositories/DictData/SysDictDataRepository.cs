namespace FastNet.Repositories;



/// <summary>
/// 
/// </summary>
public class SysDictDataRepository : DatabaseRepository<SysDictData>, ISysDictDataRepository
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysDictDataPageOutput>> GetPageListAsync(QueryDictDataPagedInput dto)
    {
        return await Context.Queryable<SysDictData>()
            .Where(x => x.Id > 0)
            .FiltersConditions(dto.SearchFilterConditions)
            .OrderConditions(dto.OrderConditions)
            //.Select(x => x.Adapt<SysDictDataPageOutput>())
            .ToPagedListAsync<SysDictDataPageOutput, SysDictData>(dto.Index, dto.Size);
    }
}

