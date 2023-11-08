namespace FastNet.Repositories;


/// <summary>
/// 
/// </summary>
public interface ISysOrganizationRepository : IDatabaseRepository<SysOrganization>, ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysOrganizationPageOutput>> GetPageListAsync(QueryOrganizationPagedInput dto);
}

