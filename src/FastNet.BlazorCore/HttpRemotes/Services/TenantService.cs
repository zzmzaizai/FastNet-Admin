namespace FastNet.BlazorCore.HttpRemotes;


/// <summary>
/// 租户服务接口
/// </summary>
public interface ITenantService : ITransient
{

    /// <summary>
    /// 插入租户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysTenant>> InsertAsync(InsertTenantInput dto);

    /// <summary>
    /// 更新租户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysTenant>> UpdateAsync(UpdateTenantInput dto);

    /// <summary>
    /// 根据主机名获取租户信息
    /// </summary>
    /// <param name="HostName">主机名</param>
    /// <returns>找不到时返回默认租户</returns>
    /// <returns></returns>
    Task<RESTfulResult<SysTenant>> GetTenantByHostNameAsync(string HostName);

    /// <summary>
    /// 获取单个租户信息
    /// </summary>
    /// <param name="TenantId">租户Id</param>
    /// <returns></returns>
    Task<RESTfulResult<SysTenant>> GetAsync(long TenantId);

    /// <summary>
    /// 获取当前租户信息
    /// </summary>
    /// <returns></returns>
    Task<RESTfulResult<SysTenant>> GetCurrent();



    /// <summary>
    /// 获取当前租户Id
    /// </summary>
    /// <returns></returns>
    Task<RESTfulResult<long>> GetCurrentTenantId();

    /// <summary>
    /// 填充一个默认租户
    /// </summary>
    /// <returns></returns>
    Task<RESTfulResult<SysTenant>> FillTenant(bool IsDefault, string DomainName);

    /// <summary>
    /// 切换租户站点
    /// </summary>
    /// <param name="TenantId">租户编号</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> ChangeTenantSite(long TenantId);


    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SqlSugarPagedList<SysTenantPageOutput>>> GetPageListAsync([FromQuery] QueryTenantPagedInput dto);
}


/// <summary>
/// 租户服务
/// </summary>
public class TenantService : ITenantService
{
    /// <summary>
    /// 请求映射接口
    /// </summary>
    protected IHttpTenantService tenantHttp { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_tenantHttp"></param>
    public TenantService(IHttpTenantService _tenantHttp)
    {
        tenantHttp = _tenantHttp;
    }



    /// <summary>
    /// 插入租户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysTenant>> InsertAsync(InsertTenantInput dto)
    {
        return await tenantHttp.InsertAsync(dto);
    }

    /// <summary>
    /// 更新租户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysTenant>> UpdateAsync(UpdateTenantInput dto)
    {
        return await tenantHttp.UpdateAsync(dto);
    }

    /// <summary>
    /// 根据主机名获取租户信息
    /// </summary>
    /// <param name="HostName">主机名</param>
    /// <returns>找不到时返回默认租户</returns>
    /// <returns></returns>
    public async Task<RESTfulResult<SysTenant>> GetTenantByHostNameAsync(string HostName)
    {
        return await tenantHttp.GetTenantByHostNameAsync(HostName);
    }

    /// <summary>
    /// 获取单个租户信息
    /// </summary>
    /// <param name="TenantId">租户Id</param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysTenant>> GetAsync(long TenantId)
    {
        return await tenantHttp.GetAsync(TenantId);
    }

    /// <summary>
    /// 获取当前租户信息
    /// </summary>
    /// <returns></returns>
    public async Task<RESTfulResult<SysTenant>> GetCurrent()
    {
        return await tenantHttp.GetCurrent();
    }

   

    /// <summary>
    /// 获取当前租户Id
    /// </summary>
    /// <returns></returns>
    public async Task<RESTfulResult<long>> GetCurrentTenantId()
    {
        return await tenantHttp.GetCurrentTenantId();
    }

    /// <summary>
    /// 填充一个默认租户
    /// </summary>
    /// <returns></returns>
    public async Task<RESTfulResult<SysTenant>> FillTenant(bool IsDefault, string DomainName)
    {
        return await tenantHttp.FillTenant(IsDefault,DomainName);
    }

    /// <summary>
    /// 切换租户站点
    /// </summary>
    /// <param name="TenantId">租户编号</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> ChangeTenantSite(long TenantId)
    {
        return await tenantHttp.ChangeTenantSite(TenantId);
    }


    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SqlSugarPagedList<SysTenantPageOutput>>> GetPageListAsync([FromQuery] QueryTenantPagedInput dto)
    {
        return await tenantHttp.GetPageListAsync(dto);
    }

     
}
