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
    Task<List<SysMenu>> GetListAsync();

    /// <summary>
    /// 校验权限
    /// </summary>
    /// <param name="code">权限标识</param>
    /// <returns></returns>
    Task<bool> CheckPermission(string code);


    /// <summary>
    /// 获取指定用户的访问权限集合
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    Task<List<CheckPermissionOutput>> GetAuthButtonCodeList(long userId);


    /// <summary>
    /// 根据菜单Id获取菜单
    /// </summary>
    /// <param name="MenuId">菜单编号</param>
    /// <returns></returns>
    Task<SysMenu> GetAsync(long MenuId);

    /// <summary>
    /// 插入菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysMenu> InsertAsync(InsertMenuInput dto);

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysMenu> UpdateAsync(UpdateMenuInput dto);
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
    public async Task<List<SysMenu>> GetListAsync()
    {
        return await menuHttp.GetListAsync();
    }
 
    /// <summary>
    /// 校验权限
    /// </summary>
    /// <param name="code">权限标识</param>
    /// <returns></returns>
    public async Task<bool> CheckPermission( string code)
    {
        return await menuHttp.CheckPermission(code);
    }


    /// <summary>
    /// 获取指定用户的访问权限集合
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    public async Task<List<CheckPermissionOutput>> GetAuthButtonCodeList(long userId)
    {
        return await menuHttp.GetAuthButtonCodeList(userId);
    }


    /// <summary>
    /// 根据菜单Id获取菜单
    /// </summary>
    /// <param name="MenuId">菜单编号</param>
    /// <returns></returns>
    public async Task<SysMenu> GetAsync(long MenuId)
    {
        return await menuHttp.GetAsync(MenuId);
    }

    /// <summary>
    /// 插入菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysMenu> InsertAsync(InsertMenuInput dto)
    {
        return await menuHttp.InsertAsync(dto);
    }

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysMenu> UpdateAsync(UpdateMenuInput dto)
    {
        return await menuHttp.UpdateAsync(dto);
    }

     


}
