namespace FastNet.Repositories;


/// <summary>
/// 
/// </summary>
public interface ISysDictDataRepository : IDatabaseRepository<SysDictData>, ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysDictDataPageOutput>> GetPageListAsync(QueryDictDataPagedInput dto);


    /// <summary>
    /// 根据字典数据Id获取字典数据
    /// </summary>
    /// <param name="DictDataId">字典数据编号</param>
    /// <returns></returns>
    Task<SysDictData> GetDictDataAsync(long DictDataId);

    /// <summary>
    /// 插入字典数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysDictData> InsertDictDataAsync(InsertDictDataInput dto);

    /// <summary>
    /// 更新字典数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysDictData> UpdateDictDataAsync(UpdateDictDataInput dto);
}

