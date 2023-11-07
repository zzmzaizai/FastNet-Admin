namespace FastNet.Repositories;


/// <summary>
/// 
/// </summary>
public interface ISysUserRepository :  ITransient
{
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

