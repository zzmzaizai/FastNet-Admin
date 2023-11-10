namespace FastNet.Repository;


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


    /// <summary>
    /// 根据API资源Id获取API资源
    /// </summary>
    /// <param name="ApiResourceId">API资源编号</param>
    /// <returns></returns>
    Task<SysApiResource> GetApiResourceAsync(long ApiResourceId);

    /// <summary>
    /// 插入API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysApiResource> InsertApiResourceAsync(InsertApiResourceInput dto);

    /// <summary>
    /// 更新API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysApiResource> UpdateApiResourceAsync(UpdateApiResourceInput dto);
}

