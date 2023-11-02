namespace FastNet.Application;



/// <summary>
/// 
/// </summary>
public class SysUserRepository : DatabaseRepository<SysUser>, ISysUserRepository
{
    public async Task<SysUser> AddUser(bool IsSuperAdmin)
    {
        var user = new SysUser
        {
            UserName = $"User-{DateTime.Now.ToString("MM-dd-HH-mm-ss")}",
            Email = $"mail_{DateTime.Now.ToString("MM_dd_HH_mm_ss")}@qq.com",
            Password = "12345567",
            Secret = Guid.NewGuid().ToString(),
            IsSuperAdmin = IsSuperAdmin,
            Status = DataUserStatus.RoleMenu,
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

