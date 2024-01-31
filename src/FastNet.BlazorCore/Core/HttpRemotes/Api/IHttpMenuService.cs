
namespace FastNet.BlazorCore;


/// <summary>
/// 菜单服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpMenuService : IBaseHttpRemote
{


    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    [Get("api/system/menu/list")]
    Task<RESTfulResult<List<SysMenu>>> GetListAsync();

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Get("api/system/menu/page-list")]
    Task<RESTfulResult<SqlSugarPagedList<SysMenuPageOutput>>> GetPageAsync([FromQuery] QueryMenuPagedInput dto);

    /// <summary>
    /// 校验权限
    /// </summary>
    /// <param name="code">权限标识</param>
    /// <returns></returns>
    [Post("api/system/menu/check-permission/{code}")]
    Task<RESTfulResult<bool>> CheckPermission(string code);


    /// <summary>
    /// 获取指定用户的访问权限集合
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    [Get("api/system/menu/auth-button-code-list/{userid}")]
    Task<RESTfulResult<List<CheckPermissionOutput>>> GetAuthButtonCodeList(long userId);


    /// <summary>
    /// 获取用户菜单列表
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    [Get("api/system/menu/menu-list/{userid}")]
    Task<RESTfulResult<List<SysMenu>>> GetMenuListAsync(long userId);


    /// <summary>
    /// 获取用户菜单树形列表
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    [Get("api/system/menu/menu-tree/{userid}")]
    Task<RESTfulResult<List<SysMenu>>> GetMenuTreeAsync(long userId);


    /// <summary>
    /// 根据菜单Id获取菜单
    /// </summary>
    /// <param name="MenuId">菜单编号</param>
    /// <returns></returns>
    [Get("api/system/menu/{menuid}")]
    Task<RESTfulResult<SysMenu>> GetAsync(long MenuId);

    /// <summary>
    /// 插入菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("api/system/menu")]
    Task<RESTfulResult<SysMenu>> InsertAsync([Body("application/json")] InsertMenuInput dto);

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Put("api/system/menu")]
    Task<RESTfulResult<SysMenu>> UpdateAsync([Body("application/json")] UpdateMenuInput dto);



    /// <summary>
    /// 删除单个菜单
    /// </summary>
    /// <param name="MenuId">菜单Id</param>
    /// <returns></returns>
    [Delete("api/system/menu/{menuid}")]
    Task<RESTfulResult<bool>> DeleteAsync(long MenuId);


    /// <summary>
    /// 批量删除菜单
    /// </summary>
    /// <param name="MenuIds">菜单Id集合</param>
    /// <returns></returns>
    [Delete("api/system/menu")]
    Task<RESTfulResult<bool>> DeleteAsync([Body("application/json")] List<long> MenuIds);


}
