namespace FastNet.Repository;



/// <summary>
/// 字典数据仓储
/// </summary>
public class SysDictDataRepository : SysDatabaseRepository<SysDictData>, ISysDictDataRepository
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


    /// <summary>
    /// 根据字典数据Id获取字典数据
    /// </summary>
    /// <param name="DictDataId">字典数据编号</param>
    /// <returns></returns>
    public async Task<SysDictData> GetDictDataAsync(long DictDataId)
    {
        return await Context.Queryable<SysDictData>().FirstAsync(x => x.Id == DictDataId);
    }

    /// <summary>
    /// 插入字典数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysDictData> InsertDictDataAsync(InsertDictDataInput dto)
    {
        var user = dto.Adapt<SysDictData>();
        await InsertAsync(user);
        return user;
    }

    /// <summary>
    /// 更新字典数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysDictData> UpdateDictDataAsync(UpdateDictDataInput dto)
    {
        var role = dto.Adapt<SysDictData>();

        var dbRole = await GetDictDataAsync(dto.Id);
        if (dbRole != null)
        {
            role.TenantId = dbRole.TenantId;
        }

        await UpdateAsync(role);
        return role;
    }
}

