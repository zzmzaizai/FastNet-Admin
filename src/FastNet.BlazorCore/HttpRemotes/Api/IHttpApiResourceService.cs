
using SqlSugar;
using System.Text;

namespace FastNet.BlazorCore;


/// <summary>
/// API资源服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpApiResourceService : IBaseHttpRemote
{
 
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Get("api/system/api-resource/page-list")]
    Task<RESTfulResult<SqlSugarPagedList<SysApiResourcePageOutput>>> GetPageListAsync([FromQuery] QueryApiResourcePagedInput dto);



    /// <summary>
    /// 根据API资源Id获取API资源
    /// </summary>
    /// <param name="ApiResourceId">API资源编号</param>
    /// <returns></returns>
    [Get("api/system/api-resource/{apiresourceid}")]
    Task<RESTfulResult<SysApiResource>> GetAsync(long ApiResourceId);

    /// <summary>
    /// 插入API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("api/system/api-resource")]
    Task<RESTfulResult<SysApiResource>> InsertAsync([Body("application/json")] InsertApiResourceInput dto);

    /// <summary>
    /// 更新API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Put("api/system/api-resource")]
    Task<RESTfulResult<SysApiResource>> UpdateAsync([Body("application/json")] UpdateApiResourceInput dto);




}
