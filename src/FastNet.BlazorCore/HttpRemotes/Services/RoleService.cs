namespace FastNet.BlazorCore.HttpRemotes;


/// <summary>
/// 授权角色服务接口
/// </summary>
public interface IRoleService : ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysRolePageOutput>> GetPageListAsync([FromQuery] QueryRolePagedInput dto);

    /// <summary>
    /// 根据角色Id获取角色
    /// </summary>
    /// <param name="RoleId">角色编号</param>
    /// <returns></returns>
    Task<SysRole> GetAsync(long RoleId);

    /// <summary>
    /// 插入角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysRole> InsertAsync(InsertRoleInput dto);

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysRole> UpdateAsync(UpdateRoleInput dto);
}


/// <summary>
/// 授权角色服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 80)]
public class RoleService : IRoleService
{
    /// <summary>
    /// 请求映射接口
    /// </summary>
    protected IHttpRoleService roleHttp { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_roleHttp"></param>
    public RoleService(IHttpRoleService _roleHttp)
    {
        roleHttp = _roleHttp;
    }

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysRolePageOutput>> GetPageListAsync([FromQuery] QueryRolePagedInput dto)
    {
        return await roleHttp.GetPageListAsync(dto);
    }



    /// <summary>
    /// 根据角色Id获取角色
    /// </summary>
    /// <param name="RoleId">角色编号</param>
    /// <returns></returns>
    public async Task<SysRole> GetAsync(long RoleId)
    {
        return await roleHttp.GetAsync(RoleId);
    }

    /// <summary>
    /// 插入角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysRole> InsertAsync(InsertRoleInput dto)
    {
        return await roleHttp.InsertAsync(dto);
    }

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysRole> UpdateAsync(UpdateRoleInput dto)
    {
        return await roleHttp.UpdateAsync(dto);
    }


    
}
