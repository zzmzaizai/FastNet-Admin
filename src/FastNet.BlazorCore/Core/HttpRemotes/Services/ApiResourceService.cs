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
    Task<RESTfulResult<SqlSugarPagedList<SysApiResourcePageOutput>>> GetPageListAsync([FromQuery] QueryApiResourcePagedInput dto);

    /// <summary>
    /// 根据API资源Id获取API资源
    /// </summary>
    /// <param name="ApiResourceId">API资源编号</param>
    /// <returns></returns>
    Task<RESTfulResult<SysApiResource>> GetAsync(long ApiResourceId);

    /// <summary>
    /// 插入API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysApiResource>> InsertAsync(InsertApiResourceInput dto);

    /// <summary>
    /// 更新API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysApiResource>> UpdateAsync(UpdateApiResourceInput dto);

    /// <summary>
    /// 删除单个API资源
    /// </summary>
    /// <param name="ApiResourceId">API资源Id</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteAsync(long ApiResourceId);

    /// <summary>
    /// 批量删除API资源
    /// </summary>
    /// <param name="ApiResourceIds">API资源Id集合</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteAsync(List<long> ApiResourceIds);
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
    public async Task<RESTfulResult<SqlSugarPagedList<SysApiResourcePageOutput>>> GetPageListAsync([FromQuery] QueryApiResourcePagedInput dto)
    {
        return await apiResourceHttp.GetPageListAsync(dto);
    }



    /// <summary>
    /// 根据API资源Id获取API资源
    /// </summary>
    /// <param name="ApiResourceId">API资源编号</param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysApiResource>> GetAsync(long ApiResourceId)
    {
        return await apiResourceHttp.GetAsync(ApiResourceId);
    }

    /// <summary>
    /// 插入API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysApiResource>> InsertAsync(InsertApiResourceInput dto)
    {
        return await apiResourceHttp.InsertAsync(dto);
    }

    /// <summary>
    /// 更新API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysApiResource>> UpdateAsync(UpdateApiResourceInput dto)
    {
        return await apiResourceHttp.UpdateAsync(dto);
    }


    /// <summary>
    /// 删除单个API资源
    /// </summary>
    /// <param name="ApiResourceId">API资源Id</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteAsync(long ApiResourceId)
    {
        return await apiResourceHttp.DeleteAsync(ApiResourceId);
    }

    /// <summary>
    /// 批量删除API资源
    /// </summary>
    /// <param name="ApiResourceIds">API资源Id集合</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteAsync(List<long> ApiResourceIds)
    {
        return await apiResourceHttp.DeleteAsync(ApiResourceIds);
    }

}
