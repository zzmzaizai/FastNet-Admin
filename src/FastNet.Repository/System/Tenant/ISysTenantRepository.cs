namespace FastNet.Repository;


/// <summary>
/// 租户仓储接口
/// </summary>
public interface ISysTenantRepository : IDatabaseRepository<SysTenant>, ITransient
{

    /// <summary>
    /// 根据主机名获取租户信息
    /// </summary>
    /// <param name="HostName">主机名</param>
    /// <returns>找不到时返回默认租户</returns>
    Task<SysTenant> GetTenantAsync(string HostName);

    /// <summary>
    /// 根据租户编号获取租户信息
    /// </summary>
    /// <param name="TenantId">租户编号</param>
    /// <returns></returns>
    Task<SysTenant> GetTenantAsync(long TenantId);

    /// <summary>
    /// 插入租户信息
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysTenant> InsertTenantAsync(InsertTenantInput dto);

    /// <summary>
    /// 更新租户信息
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysTenant> UpdateTenantAsync(UpdateTenantInput dto);



    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysTenantPageOutput>> GetPageListAsync(QueryTenantPagedInput dto);

    /// <summary>
    /// 填充默认的租户
    /// </summary>
    /// <returns></returns>
    Task<SysTenant> FillTenant(bool IsDefault, string DomainName);
}

