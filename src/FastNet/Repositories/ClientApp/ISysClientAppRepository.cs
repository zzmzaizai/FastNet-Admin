namespace FastNet.Repositories;


/// <summary>
/// 
/// </summary>
public interface ISysClientAppRepository : IDatabaseRepository<SysClientApp>, ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysClientAppPageOutput>> GetPageListAsync(QueryClientAppPagedInput dto);
}

