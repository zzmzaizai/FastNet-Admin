namespace FastNet.Repositories;


/// <summary>
/// 
/// </summary>
public interface ISysUserRepository :  ITransient
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
    /// 随便添加个用户
    /// </summary>
    /// <returns></returns>
    Task<SysUser> AddUser(bool IsSuperAdmin);
    /// <summary>
    /// 获取所有用户
    /// </summary>
    /// <returns></returns>
    Task<List<SysUser>> GetAllUsers();
}

