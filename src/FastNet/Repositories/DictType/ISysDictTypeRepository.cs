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
}

