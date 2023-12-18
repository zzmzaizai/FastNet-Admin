namespace FastNet.BlazorCore.HttpRemotes;


/// <summary>
/// 全局配置服务接口
/// </summary>
public interface IConfigService : ITransient
{
    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    Task<RESTfulResult<List<SysConfig>>> GetListAsync();

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SqlSugarPagedList<SysConfigPageOutput>>> GetPageListAsync([FromQuery] QueryConfigPagedInput dto);
}


/// <summary>
/// 全局配置服务
/// </summary>
public class ConfigService : IConfigService
{
    /// <summary>
    /// 请求映射接口
    /// </summary>
    protected IHttpConfigService configHttp { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_configHttp"></param>
    public ConfigService(IHttpConfigService _configHttp)
    {
        configHttp = _configHttp;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public async Task<RESTfulResult<List<SysConfig>>> GetListAsync()
    {
        return await configHttp.GetListAsync();
    }

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SqlSugarPagedList<SysConfigPageOutput>>> GetPageListAsync([FromQuery] QueryConfigPagedInput dto)
    {
        return await configHttp.GetPageListAsync(dto);
    }





}
