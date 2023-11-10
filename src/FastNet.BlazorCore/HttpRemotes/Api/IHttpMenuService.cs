
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
    [Get("/api/system/menu/list")]
    Task<List<SysMenu>> GetListAsync();

    /// <summary>
    /// 校验权限
    /// </summary>
    /// <param name="code">权限标识</param>
    /// <returns></returns>
    [Post("/api/system/menu/check-permission/{code}")]
    Task<bool> CheckPermission(string code);


    /// <summary>
    /// 获取指定用户的访问权限集合
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    [Get("/api/system/menu/auth-button-code-list/{userid}")]
    Task<List<CheckPermissionOutput>> GetAuthButtonCodeList(long userId);


    /// <summary>
    /// 根据菜单Id获取菜单
    /// </summary>
    /// <param name="MenuId">菜单编号</param>
    /// <returns></returns>
    [Get("/api/system/menu/{menuid}")]
    Task<SysMenu> GetAsync(long MenuId);

    /// <summary>
    /// 插入菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("/api/system/menu")]
    Task<SysMenu> InsertAsync(InsertMenuInput dto);

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Put("/api/system/menu")]
    Task<SysMenu> UpdateAsync(UpdateMenuInput dto);





}
