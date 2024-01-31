

namespace FastNet.BlazorCore;


/// <summary>
/// 租户服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpTenantService : IBaseHttpRemote
{

    /// <summary>
    /// 插入租户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("api/system/tenant")]
    Task<RESTfulResult<SysTenant>> InsertAsync([Body("application/json")] InsertTenantInput dto);

    /// <summary>
    /// 更新租户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Put("api/system/tenant")]
    Task<RESTfulResult<SysTenant>> UpdateAsync([Body("application/json")] UpdateTenantInput dto);

    /// <summary>
    /// 根据主机名获取租户信息
    /// </summary>
    /// <param name="HostName">主机名</param>
    /// <returns>找不到时返回默认租户</returns>
    /// <returns></returns>
    [Get("api/host/tenant/tenant-by-host-name/{hostname}")]
    Task<RESTfulResult<SysTenant>> GetTenantByHostNameAsync(string HostName);

    /// <summary>
    /// 获取单个租户信息
    /// </summary>
    /// <param name="TenantId">租户Id</param>
    /// <returns></returns>
    [Get("api/host/tenant/{tenantid}")]
    Task<RESTfulResult<SysTenant>> GetAsync(long TenantId);

    /// <summary>
    /// 获取当前租户信息
    /// </summary>
    /// <returns></returns>
    [Get("api/host/tenant/current")]
    Task<RESTfulResult<SysTenant>> GetCurrent();

    /// <summary>
    /// 获取当前租户Id
    /// </summary>
    /// <returns></returns>
    [Get("api/host/tenant/current-tenant-id")]
    Task<RESTfulResult<long>> GetCurrentTenantId();

    /// <summary>
    /// 填充一个默认租户
    /// </summary>
    /// <returns></returns>
    [Post("api/host/tenant/fill-tenant/{isdefault}/{domainname}")]
    Task<RESTfulResult<SysTenant>> FillTenant(bool IsDefault, string DomainName);

    /// <summary>
    /// 切换租户站点
    /// </summary>
    /// <param name="TenantId">租户编号</param>
    /// <returns></returns>
    [Post("api/host/tenant/change-tenant-site/{tenantid}")]
    Task<RESTfulResult<bool>> ChangeTenantSite(long TenantId);


    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Get("api/host/tenant/page-list")]
    Task<RESTfulResult<SqlSugarPagedList<SysTenantPageOutput>>> GetPageListAsync([FromQuery] QueryTenantPagedInput dto);



    /// <summary>
    /// 删除单个租户站点
    /// </summary>
    /// <param name="TenantId">租户站点Id</param>
    /// <returns></returns>
    [Delete("api/system/tenant/{tenantid}")]
    Task<RESTfulResult<bool>> DeleteAsync(long TenantId);


    /// <summary>
    /// 批量删除租户站点
    /// </summary>
    /// <param name="TenantIds">租户站点Id集合</param>
    /// <returns></returns>
    [Delete("api/system/tenant")]
    Task<RESTfulResult<bool>> DeleteAsync([Body("application/json")] List<long> TenantIds);

}
