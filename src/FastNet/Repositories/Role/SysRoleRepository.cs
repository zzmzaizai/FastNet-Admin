namespace FastNet.Repositories;



/// <summary>
/// 
/// </summary>
public class SysRoleRepository : DatabaseRepository<SysRole>, ISysRoleRepository
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysRolePageOutput>> GetPageListAsync(QueryRolePagedInput dto)
    {
        return await Context.Queryable<SysRole>()
            .Where(x => x.Id > 0)
            .FiltersConditions(dto.SearchFilterConditions)
            .OrderConditions(dto.OrderConditions)
            //.Select(x => x.Adapt<SysRolePageOutput>())
            .ToPagedListAsync<SysRolePageOutput, SysRole>(dto.Index, dto.Size);
    }
}

