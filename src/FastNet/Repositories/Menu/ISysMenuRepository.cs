namespace FastNet.Repositories;


/// <summary>
/// 
/// </summary>
public interface ISysMenuRepository : IDatabaseRepository<SysMenu>, ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysMenuPageOutput>> GetPageListAsync(QueryMenuPagedInput dto);

    /// <summary>
    /// 校验权限
    /// </summary>
    /// <param name="code">权限标识</param>
    /// <param name="UserId"></param>
    /// <returns></returns>
    Task<bool> CheckPermission(long UserId, string code);

    /// <summary>
    /// 获取指定用户的访问权限集合
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    Task<List<CheckPermissionOutput>> GetAuthButtonCodeList(long userId);
}

