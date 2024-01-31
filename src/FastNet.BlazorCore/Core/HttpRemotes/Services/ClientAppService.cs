namespace FastNet.BlazorCore.HttpRemotes;


/// <summary>
/// 客户端应用服务接口
/// </summary>
public interface IClientAppService : ITransient
{

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SqlSugarPagedList<SysClientAppPageOutput>>> GetPageListAsync([FromQuery] QueryClientAppPagedInput dto);

    /// <summary>
    /// 根据客户端APPId获取客户端APP
    /// </summary>
    /// <param name="ClientAppId">客户端APP编号</param>
    /// <returns></returns>
    Task<RESTfulResult<SysClientApp>> GetAsync(long ClientAppId);

    /// <summary>
    /// 插入客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysClientApp>> InsertAsync(InsertClientAppInput dto);

    /// <summary>
    /// 更新客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysClientApp>> UpdateAsync(UpdateClientAppInput dto);

    /// <summary>
    /// 重置客户端APP的SecretKey
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysClientApp>> ResetSecretAsync(ResetClientAppSecretInput dto);

    /// <summary>
    /// 删除单个客户端APP
    /// </summary>
    /// <param name="ClientAppId">客户端APP Id</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteAsync(long ClientAppId);


    /// <summary>
    /// 批量删除客户端APP
    /// </summary>
    /// <param name="ClientAppIds">客户端APP Id集合</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteAsync(List<long> ClientAppIds);
}


/// <summary>
/// 客户端应用服务
/// </summary>
public class ClientAppService : IClientAppService
{
    /// <summary>
    /// 请求映射接口
    /// </summary>
    protected IHttpClientAppService clientAppHttp { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_clientAppHttp"></param>
    public ClientAppService(IHttpClientAppService _clientAppHttp)
    {
        clientAppHttp = _clientAppHttp;
    }

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SqlSugarPagedList<SysClientAppPageOutput>>> GetPageListAsync([FromQuery] QueryClientAppPagedInput dto)
    {
        return await clientAppHttp.GetPageListAsync(dto);
    }



    /// <summary>
    /// 根据客户端APPId获取客户端APP
    /// </summary>
    /// <param name="ClientAppId">客户端APP编号</param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysClientApp>> GetAsync(long ClientAppId)
    {
        return await clientAppHttp.GetAsync(ClientAppId);
    }

    /// <summary>
    /// 插入客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysClientApp>> InsertAsync(InsertClientAppInput dto)
    {
        return await clientAppHttp.InsertAsync(dto);
    }

    /// <summary>
    /// 更新客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysClientApp>> UpdateAsync(UpdateClientAppInput dto)
    {
        return await clientAppHttp.UpdateAsync(dto);
    }

    /// <summary>
    /// 重置客户端APP的SecretKey
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysClientApp>> ResetSecretAsync(ResetClientAppSecretInput dto)
    {
        return await clientAppHttp.ResetSecretAsync(dto);
    }


    /// <summary>
    /// 删除单个客户端APP
    /// </summary>
    /// <param name="ClientAppId">客户端APP Id</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteAsync(long ClientAppId)
    {
        return await clientAppHttp.DeleteAsync(ClientAppId);
    }

    /// <summary>
    /// 批量删除客户端APP
    /// </summary>
    /// <param name="ClientAppIds">客户端APP Id集合</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteAsync([Body("application/json")] List<long> ClientAppIds)
    {
        return await clientAppHttp.DeleteAsync(ClientAppIds);
    }
}
