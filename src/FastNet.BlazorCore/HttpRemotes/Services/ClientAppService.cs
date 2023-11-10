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
    Task<SqlSugarPagedList<SysClientAppPageOutput>> GetPageListAsync([FromQuery] QueryClientAppPagedInput dto);
 
    /// <summary>
    /// 根据客户端APPId获取客户端APP
    /// </summary>
    /// <param name="ClientAppId">客户端APP编号</param>
    /// <returns></returns>
    Task<SysClientApp> GetAsync(long ClientAppId);

    /// <summary>
    /// 插入客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysClientApp> InsertAsync(InsertClientAppInput dto);

    /// <summary>
    /// 更新客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysClientApp> UpdateAsync(UpdateClientAppInput dto);

    /// <summary>
    /// 重置客户端APP的SecretKey
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysClientApp> ResetSecretAsync(ResetClientAppSecretInput dto);
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
    public async Task<SqlSugarPagedList<SysClientAppPageOutput>> GetPageListAsync([FromQuery] QueryClientAppPagedInput dto)
    {
        return await clientAppHttp.GetPageListAsync(dto);
    }



    /// <summary>
    /// 根据客户端APPId获取客户端APP
    /// </summary>
    /// <param name="ClientAppId">客户端APP编号</param>
    /// <returns></returns>
    public async Task<SysClientApp> GetAsync(long ClientAppId)
    {
        return await clientAppHttp.GetAsync(ClientAppId);
    }

    /// <summary>
    /// 插入客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysClientApp> InsertAsync(InsertClientAppInput dto)
    {
        return await clientAppHttp.InsertAsync(dto);
    }

    /// <summary>
    /// 更新客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysClientApp> UpdateAsync(UpdateClientAppInput dto)
    {
        return await clientAppHttp.UpdateAsync(dto);
    }

    /// <summary>
    /// 重置客户端APP的SecretKey
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysClientApp> ResetSecretAsync(ResetClientAppSecretInput dto)
    {
        return await clientAppHttp.ResetSecretAsync(dto);
    }
 
}
