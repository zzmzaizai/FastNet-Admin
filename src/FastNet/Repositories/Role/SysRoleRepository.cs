using Furion.LinqBuilder;

namespace FastNet.Repositories;



/// <summary>
/// 系统角色仓储
/// </summary>
public class SysRoleRepository : DatabaseRepository<SysRole>, ISysRoleRepository
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysRolePageOutput>> GetPageListAsync(QueryRolePagedInput dto)
    {
        return await Context.Queryable<SysRole>()
            .Where(x => x.Id > 0)
            .FiltersConditions(dto.SearchFilterConditions)
            .OrderConditions(dto.OrderConditions)
            //.Select(x => x.Adapt<SysRolePageOutput>())
            .ToPagedListAsync<SysRolePageOutput, SysRole>(dto.Index, dto.Size);
    }


    /// <summary>
    /// 根据角色Id获取角色
    /// </summary>
    /// <param name="RoleId">角色编号</param>
    /// <returns></returns>
    public async Task<SysRole> GetRoleAsync(long RoleId)
    {
        return await Context.Queryable<SysRole>().FirstAsync(x => x.Id == RoleId);
    }

    /// <summary>
    /// 插入角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysRole> InsertRoleAsync(InsertRoleInput dto)
    {
        var user = dto.Adapt<SysRole>();
        user.CreateUserId = authManager.UserId;
        user.CreateTime = DateTime.Now;
        await InsertAsync(user);
        return user;
    }

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysRole> UpdateRoleAsync(UpdateRoleInput dto)
    {
        var role = dto.Adapt<SysRole>();

        var dbRole = await GetRoleAsync(dto.Id);
        if (dbRole != null)
        {
            role.CreateUserId = dbRole.CreateUserId;
            role.CreateTime = dbRole.CreateTime;
            role.TenantId = dbRole.TenantId;
            role.IsDelete = dbRole.IsDelete;
        }
        role.UpdateUserId = authManager.UserId;
        role.UpdateTime = DateTime.Now;

 
        await UpdateAsync(role);
        return role;
    }
}

