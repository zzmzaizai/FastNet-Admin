namespace FastNet.Repositories;



/// <summary>
/// 
/// </summary>
public class SysDictTypeRepository : DatabaseRepository<SysDictType>, ISysDictTypeRepository
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<SqlSugarPagedList<SysDictTypePageOutput>> GetPageListAsync([FromQuery] QueryDictTypePagedInput dto)
    {
        return await Context.Queryable<SysDictType>()
            .Where(x => x.Id > 0)
            .FiltersConditions(dto.SearchFilterConditions)
            .OrderConditions(dto.OrderConditions)
            //.Select(x => x.Adapt<SysDictTypePageOutput>())
            .ToPagedListAsync<SysDictTypePageOutput, SysDictType>(dto.Index, dto.Size);
    }
}

