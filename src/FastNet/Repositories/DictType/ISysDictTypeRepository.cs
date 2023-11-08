namespace FastNet.Repositories;


/// <summary>
/// 
/// </summary>
public interface ISysDictTypeRepository : IDatabaseRepository<SysDictType>, ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysDictTypePageOutput>> GetPageListAsync(QueryDictTypePagedInput dto);


    /// <summary>
    /// 根据字典类型Id获取字典类型
    /// </summary>
    /// <param name="DictTypeId">字典类型编号</param>
    /// <returns></returns>
    Task<SysDictType> GetDictTypeAsync(long DictTypeId);

    /// <summary>
    /// 插入字典类型
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysDictType> InsertDictTypeAsync(InsertDictTypeInput dto);

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysDictType> UpdateDictTypeAsync(UpdateDictTypeInput dto);
}

