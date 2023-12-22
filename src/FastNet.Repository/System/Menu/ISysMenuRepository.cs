namespace FastNet.Repository;


/// <summary>
/// 系统菜单仓储接口
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


    /// <summary>
    /// 获取用户菜单列表
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<SysMenu>> GetMenuListAsync(long userId);


    /// <summary>
    /// 获取用户菜单树形列表
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<SysMenu>> GetMenuTreeAsync(long userId);


    /// <summary>
    /// 根据菜单Id获取菜单
    /// </summary>
    /// <param name="MenuId">菜单编号</param>
    /// <returns></returns>
    Task<SysMenu> GetMenuAsync(long MenuId);

    /// <summary>
    /// 插入菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysMenu> InsertMenuAsync(InsertMenuInput dto);

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysMenu> UpdateMenuAsync(UpdateMenuInput dto);
}

