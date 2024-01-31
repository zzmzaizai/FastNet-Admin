
using SqlSugar;
using System.Text;

namespace FastNet.BlazorCore;


/// <summary>
/// 角色服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpRoleService : IBaseHttpRemote
{
 
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Get("api/system/role/page-list")]
    [HttpGet]
    Task<RESTfulResult<SqlSugarPagedList<SysRolePageOutput>>> GetPageListAsync([FromQuery] QueryRolePagedInput dto);



    /// <summary>
    /// 根据角色Id获取角色
    /// </summary>
    /// <param name="RoleId">角色编号</param>
    /// <returns></returns>
    [Get("api/system/role/{roleid}")]
    Task<RESTfulResult<SysRole>> GetAsync(long RoleId);

    /// <summary>
    /// 插入角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("api/system/role")]
    Task<RESTfulResult<SysRole>> InsertAsync([Body("application/json")] InsertRoleInput dto);

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Put("api/system/role")]
    Task<RESTfulResult<SysRole>> UpdateAsync([Body("application/json")] UpdateRoleInput dto);



    /// <summary>
    /// 删除单个角色
    /// </summary>
    /// <param name="RoleId">角色Id</param>
    /// <returns></returns>
    [Delete("api/system/role/{roleid}")]
    Task<RESTfulResult<bool>> DeleteAsync(long RoleId);


    /// <summary>
    /// 批量删除角色
    /// </summary>
    /// <param name="RoleIds">角色Id集合</param>
    /// <returns></returns>
    [Delete("api/system/role")]
    Task<RESTfulResult<bool>> DeleteAsync([Body("application/json")] List<long> RoleIds);
}
