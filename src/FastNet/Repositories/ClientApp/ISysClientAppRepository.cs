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



    /// <summary>
    /// 根据客户端APPId获取客户端APP
    /// </summary>
    /// <param name="ClientAppId">客户端APP编号</param>
    /// <returns></returns>
    Task<SysClientApp> GetClientAppAsync(long ClientAppId);

    /// <summary>
    /// 插入客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysClientApp> InsertClientAppAsync(InsertClientAppInput dto);

    /// <summary>
    /// 更新客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysClientApp> UpdateClientAppAsync(UpdateClientAppInput dto);
}

