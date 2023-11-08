namespace FastNet.Repositories;


/// <summary>
/// 
/// </summary>
public interface ISysApiResourceRepository : IDatabaseRepository<SysApiResource>, ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysApiResourcePageOutput>> GetPageListAsync(QueryApiResourcePagedInput dto);
}

