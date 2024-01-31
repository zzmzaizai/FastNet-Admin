
using SqlSugar;
using System.Text;

namespace FastNet.BlazorCore;


/// <summary>
/// 配置服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpConfigService : IBaseHttpRemote
{
 
    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    [Get("api/system/config/list")]
    Task<RESTfulResult<List<SysConfig>>> GetListAsync();

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Get("api/system/config/page-list")]
    Task<RESTfulResult<SqlSugarPagedList<SysConfigPageOutput>>> GetPageListAsync([FromQuery] QueryConfigPagedInput dto);

}
