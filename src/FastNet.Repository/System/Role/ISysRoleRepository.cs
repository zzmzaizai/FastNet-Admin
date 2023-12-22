namespace FastNet.Repository;


/// <summary>
/// 系统角色仓储接口
/// </summary>
public interface ISysRoleRepository : IDatabaseRepository<SysRole>, ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysRolePageOutput>> GetPageListAsync(QueryRolePagedInput dto);


    /// <summary>
    /// 根据角色Id获取角色
    /// </summary>
    /// <param name="RoleId">角色编号</param>
    /// <returns></returns>
    Task<SysRole> GetRoleAsync(long RoleId);

    /// <summary>
    /// 插入角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysRole> InsertRoleAsync(InsertRoleInput dto);

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysRole> UpdateRoleAsync(UpdateRoleInput dto);
}

