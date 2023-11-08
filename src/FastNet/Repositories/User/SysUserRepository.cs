using FastNet.Services;
using Furion.LinqBuilder;

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
    /// <param name="UserId">用户编号</param>
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

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysUser> UpdateUserAsync(UpdateUserInput dto)
    {
        var user = dto.Adapt<SysUser>();

        var dbUser = await GetUserAsync(dto.Id);
        if(dbUser != null)
        {
            user.CreateUserId = dbUser.CreateUserId;
            user.CreateTime = dbUser.CreateTime;
            user.TenantId = dbUser.TenantId;
            user.IsDelete = dbUser.IsDelete;
            user.Password = dbUser.Password;
        }
        user.UpdateUserId = authManager.UserId;
        user.UpdateTime = DateTime.Now;

        //填写了密码的情况下更改密码
        if (!dto.Password.IsNullOrEmpty())
        {
            user.Password = MD5Encryption.Encrypt($"{user.Secret}{dto.Password}");
        }
        await UpdateAsync(user);
        return user;
    }


    /// <summary>
    /// 用户分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysUserPageOutput>> GetPageListAsync(QueryUserPagedInput dto)
    {
        return await Context.Queryable<SysUser>()

            //.WhereIF(dto.Status.)
            .Where(x => x.Id > 0)
            .FiltersConditions(dto.SearchFilterConditions)
            .OrderConditions(dto.OrderConditions)
            //.Select(x => x.Adapt<SysUserPageOutput>())
            .ToPagedListAsync<SysUserPageOutput, SysUser>(dto.Index, dto.Size);
    }

}

