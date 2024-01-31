namespace FastNet.Repository;


/// <summary>
/// 系统用户仓储接口
/// </summary>
public interface ISysUserRepository : IDatabaseRepository<SysUser>, ITransient
{
    /// <summary>
    /// 根据用户名获取用户
    /// </summary>
    /// <param name="UserName">用户名</param>
    /// <returns></returns>
    Task<SysUser> GetUserAsync(string UserName);

    /// <summary>
    /// 根据用户Id获取用户
    /// </summary>
    /// <param name="UserId">用户编号</param>
    /// <returns></returns>
    Task<SysUser> GetUserAsync(long UserId);

    /// <summary>
    /// 插入用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysUser> InsertUserAsync(InsertUserInput dto);

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysUser> UpdateUserAsync(UpdateUserInput dto);


    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysUserPageOutput>> GetPageListAsync(QueryUserPagedInput dto);
}

