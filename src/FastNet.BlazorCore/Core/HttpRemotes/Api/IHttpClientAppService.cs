

using SqlSugar;
using System.Text;

namespace FastNet.BlazorCore;


/// <summary>
/// 客户端APP服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpClientAppService : IBaseHttpRemote
{

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Get("api/system/client/page-list")]
    Task<RESTfulResult<SqlSugarPagedList<SysClientAppPageOutput>>> GetPageListAsync([FromQuery] QueryClientAppPagedInput dto);



    /// <summary>
    /// 根据客户端APPId获取客户端APP
    /// </summary>
    /// <param name="ClientAppId">客户端APP编号</param>
    /// <returns></returns>
    [Get("api/system/client/{clientappid}")]
    Task<RESTfulResult<SysClientApp>> GetAsync(long ClientAppId);

    /// <summary>
    /// 插入客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("api/system/client")]
    Task<RESTfulResult<SysClientApp>> InsertAsync([Body("application/json")] InsertClientAppInput dto);

    /// <summary>
    /// 更新客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Put("api/system/client")]
    Task<RESTfulResult<SysClientApp>> UpdateAsync([Body("application/json")] UpdateClientAppInput dto);

    /// <summary>
    /// 重置客户端APP的SecretKey
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Patch("api/system/client/reset-secret")]
    Task<RESTfulResult<SysClientApp>> ResetSecretAsync([Body("application/json")] ResetClientAppSecretInput dto);



    /// <summary>
    /// 删除单个客户端APP
    /// </summary>
    /// <param name="ClientAppId">客户端APP Id</param>
    /// <returns></returns>
    [Delete("api/system/client/{clientappid}")]
    Task<RESTfulResult<bool>> DeleteAsync(long ClientAppId);


    /// <summary>
    /// 批量删除客户端APP
    /// </summary>
    /// <param name="ClientAppIds">客户端APP Id集合</param>
    /// <returns></returns>
    [Delete("api/system/client")]
    Task<RESTfulResult<bool>> DeleteAsync([FromQuery] List<long> ClientAppIds);
}
