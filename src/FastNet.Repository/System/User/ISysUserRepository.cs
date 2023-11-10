namespace FastNet.Repository;


/// <summary>
/// 
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
    /// <param name="UserId">用户名</param>
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

