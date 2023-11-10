namespace FastNet.Repository;



/// <summary>
/// 字典类型仓储
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


    /// <summary>
    /// 根据字典类型Id获取字典类型
    /// </summary>
    /// <param name="DictTypeId">字典类型编号</param>
    /// <returns></returns>
    public async Task<SysDictType> GetDictTypeAsync(long DictTypeId)
    {
        return await Context.Queryable<SysDictType>().FirstAsync(x => x.Id == DictTypeId);
    }

    /// <summary>
    /// 插入字典类型
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysDictType> InsertDictTypeAsync(InsertDictTypeInput dto)
    {
        var user = dto.Adapt<SysDictType>();
        await InsertAsync(user);
        return user;
    }

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysDictType> UpdateDictTypeAsync(UpdateDictTypeInput dto)
    {
        var role = dto.Adapt<SysDictType>();

        var dbRole = await GetDictTypeAsync(dto.Id);
        if (dbRole != null)
        {
            role.TenantId = dbRole.TenantId;
        }
        await UpdateAsync(role);
        return role;
    }
}

