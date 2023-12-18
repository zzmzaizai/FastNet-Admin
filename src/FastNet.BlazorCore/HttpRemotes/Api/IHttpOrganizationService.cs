
using System.Text;

namespace FastNet.BlazorCore;


/// <summary>
/// 组织部门服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpOrganizationService : IBaseHttpRemote
{

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    [Get("api/system/organization/list")]
    Task<List<SysOrganization>> GetListAsync();

    /// <summary>
    /// 根据组织架构Id获取组织架构
    /// </summary>
    /// <param name="OrganizationId">组织架构编号</param>
    /// <returns></returns>
    [Get("api/system/organization/{organizationid}")]
    Task<SysOrganization> GetAsync(long OrganizationId);

    /// <summary>
    /// 插入组织架构
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("api/system/organization")]
    Task<SysOrganization> InsertAsync([Body("application/json")] InsertOrganizationInput dto);

    /// <summary>
    /// 更新组织架构
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Put("api/system/organization")]
    Task<SysOrganization> UpdateAsync([Body("application/json")] UpdateOrganizationInput dto);




}
