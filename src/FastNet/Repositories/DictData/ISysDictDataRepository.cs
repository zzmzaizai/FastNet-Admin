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
}

