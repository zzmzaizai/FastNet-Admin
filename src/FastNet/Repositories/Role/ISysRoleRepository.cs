namespace FastNet.Repositories;


/// <summary>
/// 
/// </summary>
public interface ISysRoleRepository : IDatabaseRepository<SysRole>, ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysRolePageOutput>> GetPageListAsync(QueryRolePagedInput dto);
}

