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
    Task<RESTfulResult<SqlSugarPagedList<SysRolePageOutput>>> GetPageListAsync([FromQuery] QueryRolePagedInput dto);

    /// <summary>
    /// 根据角色Id获取角色
    /// </summary>
    /// <param name="RoleId">角色编号</param>
    /// <returns></returns>
    Task<RESTfulResult<SysRole>> GetAsync(long RoleId);

    /// <summary>
    /// 插入角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysRole>> InsertAsync(InsertRoleInput dto);

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysRole>> UpdateAsync(UpdateRoleInput dto);

    /// <summary>
    /// 删除单个角色
    /// </summary>
    /// <param name="RoleId">角色Id</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteAsync(long RoleId);


    /// <summary>
    /// 批量删除角色
    /// </summary>
    /// <param name="RoleIds">角色Id集合</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteAsync(List<long> RoleIds);
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
    public async Task<RESTfulResult<SqlSugarPagedList<SysRolePageOutput>>> GetPageListAsync([FromQuery] QueryRolePagedInput dto)
    {
        return await roleHttp.GetPageListAsync(dto);
    }



    /// <summary>
    /// 根据角色Id获取角色
    /// </summary>
    /// <param name="RoleId">角色编号</param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysRole>> GetAsync(long RoleId)
    {
        return await roleHttp.GetAsync(RoleId);
    }

    /// <summary>
    /// 插入角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysRole>> InsertAsync(InsertRoleInput dto)
    {
        return await roleHttp.InsertAsync(dto);
    }

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysRole>> UpdateAsync(UpdateRoleInput dto)
    {
        return await roleHttp.UpdateAsync(dto);
    }

    /// <summary>
    /// 删除单个角色
    /// </summary>
    /// <param name="RoleId">角色Id</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteAsync(long RoleId)
    {
        return await roleHttp.DeleteAsync(RoleId);
    }


    /// <summary>
    /// 批量删除角色
    /// </summary>
    /// <param name="RoleIds">角色Id集合</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteAsync(List<long> RoleIds)
    {
        return await roleHttp.DeleteAsync(RoleIds);
    }

}
