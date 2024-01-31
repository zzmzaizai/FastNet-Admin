namespace FastNet.BlazorCore.HttpRemotes;


/// <summary>
/// 菜单服务接口
/// </summary>
public interface IMenuService : ITransient
{

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    Task<RESTfulResult<List<SysMenu>>> GetListAsync();

    /// <summary>
    /// 校验权限
    /// </summary>
    /// <param name="code">权限标识</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> CheckPermission(string code);


    /// <summary>
    /// 获取指定用户的访问权限集合
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    Task<RESTfulResult<List<CheckPermissionOutput>>> GetAuthButtonCodeList(long userId);

    /// <summary>
    /// 获取用户菜单列表
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    Task<RESTfulResult<List<SysMenu>>> GetMenuListAsync(long userId);

    /// <summary>
    /// 获取用户菜单树形列表
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    Task<RESTfulResult<List<SysMenu>>> GetMenuTreeAsync(long userId);

    /// <summary>
    /// 根据菜单Id获取菜单
    /// </summary>
    /// <param name="MenuId">菜单编号</param>
    /// <returns></returns>
    Task<RESTfulResult<SysMenu>> GetAsync(long MenuId);

    /// <summary>
    /// 插入菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysMenu>> InsertAsync(InsertMenuInput dto);

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysMenu>> UpdateAsync(UpdateMenuInput dto);
}


/// <summary>
/// 菜单服务
/// </summary>
public class MenuService : IMenuService
{
    /// <summary>
    /// 请求映射接口
    /// </summary>
    protected IHttpMenuService menuHttp { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_menuHttp"></param>
    public MenuService(IHttpMenuService _menuHttp)
    {
        menuHttp = _menuHttp;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public async Task<RESTfulResult<List<SysMenu>>> GetListAsync()
    {
        return await menuHttp.GetListAsync();
    }
 
    /// <summary>
    /// 校验权限
    /// </summary>
    /// <param name="code">权限标识</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> CheckPermission( string code)
    {
        return await menuHttp.CheckPermission(code);
    }


    /// <summary>
    /// 获取指定用户的访问权限集合
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    public async Task<RESTfulResult<List<CheckPermissionOutput>>> GetAuthButtonCodeList(long userId)
    {
        return await menuHttp.GetAuthButtonCodeList(userId);
    }

    /// <summary>
    /// 获取用户菜单列表
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    public async Task<RESTfulResult<List<SysMenu>>> GetMenuListAsync(long userId)
    {
        return await menuHttp.GetMenuListAsync(userId);
    }

    /// <summary>
    /// 获取用户菜单树形列表
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    public async Task<RESTfulResult<List<SysMenu>>> GetMenuTreeAsync(long userId)
    {
        return await menuHttp.GetMenuTreeAsync(userId);
    }


    /// <summary>
    /// 根据菜单Id获取菜单
    /// </summary>
    /// <param name="MenuId">菜单编号</param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysMenu>> GetAsync(long MenuId)
    {
        return await menuHttp.GetAsync(MenuId);
    }

    /// <summary>
    /// 插入菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysMenu>> InsertAsync(InsertMenuInput dto)
    {
        return await menuHttp.InsertAsync(dto);
    }

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysMenu>> UpdateAsync(UpdateMenuInput dto)
    {
        return await menuHttp.UpdateAsync(dto);
    }

     


}
