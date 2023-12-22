namespace FastNet.Repository;


/// <summary>
/// 组织架构仓储接口
/// </summary>
public interface ISysOrganizationRepository : IDatabaseRepository<SysOrganization>, ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysOrganizationPageOutput>> GetPageListAsync(QueryOrganizationPagedInput dto);


    /// <summary>
    /// 根据组织架构Id获取组织架构
    /// </summary>
    /// <param name="OrganizationId">组织架构编号</param>
    /// <returns></returns>
    Task<SysOrganization> GetOrganizationAsync(long OrganizationId);

    /// <summary>
    /// 插入组织架构
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysOrganization> InsertOrganizationAsync(InsertOrganizationInput dto);


    /// <summary>
    /// 更新组织架构
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysOrganization> UpdateOrganizationAsync(UpdateOrganizationInput dto);

}

