using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.BlazorCore.HttpRemotes;


/// <summary>
/// API资源服务接口
/// </summary>
public interface IApiResourceService : ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    Task<SqlSugarPagedList<SysApiResourcePageOutput>> GetPageListAsync([FromQuery] QueryApiResourcePagedInput dto);

    /// <summary>
    /// 根据API资源Id获取API资源
    /// </summary>
    /// <param name="ApiResourceId">API资源编号</param>
    /// <returns></returns>
    Task<SysApiResource> GetAsync(long ApiResourceId);

    /// <summary>
    /// 插入API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysApiResource> InsertAsync(InsertApiResourceInput dto);

    /// <summary>
    /// 更新API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysApiResource> UpdateAsync(UpdateApiResourceInput dto);
}


/// <summary>
/// API资源服务
/// </summary>
public class ApiResourceService : IApiResourceService
{
    /// <summary>
    /// 请求映射接口
    /// </summary>
    protected IHttpApiResourceService apiResourceHttp { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_apiResourceHttp"></param>
    public ApiResourceService(IHttpApiResourceService _apiResourceHttp)
    {
        apiResourceHttp = _apiResourceHttp;
    }

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SqlSugarPagedList<SysApiResourcePageOutput>> GetPageListAsync([FromQuery] QueryApiResourcePagedInput dto)
    {
        return await apiResourceHttp.GetPageListAsync(dto);
    }



    /// <summary>
    /// 根据API资源Id获取API资源
    /// </summary>
    /// <param name="ApiResourceId">API资源编号</param>
    /// <returns></returns>
    public async Task<SysApiResource> GetAsync(long ApiResourceId)
    {
        return await apiResourceHttp.GetAsync(ApiResourceId);
    }

    /// <summary>
    /// 插入API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysApiResource> InsertAsync(InsertApiResourceInput dto)
    {
        return await apiResourceHttp.InsertAsync(dto);
    }

    /// <summary>
    /// 更新API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysApiResource> UpdateAsync(UpdateApiResourceInput dto)
    {
        return await apiResourceHttp.UpdateAsync(dto);
    }



 

}
