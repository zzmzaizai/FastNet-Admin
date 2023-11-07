namespace FastNet.Repositories;



/// <summary>
/// 
/// </summary>
public class SysUserRepository : DatabaseRepository<SysUser>, ISysUserRepository
{
    /// <summary>
    /// 根据用户名获取用户
    /// </summary>
    /// <param name="UserName">用户名</param>
    /// <returns></returns>
    public async Task<SysUser> GetUserAsync(string UserName)
    {
        return await Context.Queryable<SysUser>().FirstAsync(x => x.UserName == UserName);
    }

    /// <summary>
    /// 根据用户Id获取用户
    /// </summary>
    /// <param name="UserId">用户名</param>
    /// <returns></returns>
    public async Task<SysUser> GetUserAsync(long UserId)
    {
        return await Context.Queryable<SysUser>().FirstAsync(x => x.Id == UserId);
    }



    public async Task<SysUser> AddUser(bool IsSuperAdmin)
    {
        var user = new SysUser
        {
            UserName = $"User-{DateTime.Now.ToString("MM-dd-HH-mm-ss")}",
            Email = $"mail_{DateTime.Now.ToString("MM_dd_HH_mm_ss")}@qq.com",
            Password = "12345567",
            Secret = Guid.NewGuid().ToString(),
            IsSuperAdmin = IsSuperAdmin,
            Status = DataUserStatus.Enable,
            CreateTime = DateTime.Now,
            CreateUserId = 0
        };
        await InsertAsync(user);
        return user;
    }

    public async Task<List<SysUser>> GetAllUsers()
    {
        var query = Context.Queryable<SysUser>()
                        
                         .Where( it => it.Id > 0) 
                     
                         .OrderBy(it => it.CreateTime);//排序
        return await query.ToListAsync();
    }

}

