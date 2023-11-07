using FastNet.Services;

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

    /// <summary>
    /// 插入用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysUser> InsertUserAsync(InsertUserInput dto)
    {
        var user = dto.Adapt<SysUser>();
        user.CreateUserId = authManager.UserId;
        user.CreateTime = DateTime.Now;
        user.Secret = Guid.NewGuid().ToString();
        user.Password = MD5Encryption.Encrypt($"{user.Secret}{dto.Password}");
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

