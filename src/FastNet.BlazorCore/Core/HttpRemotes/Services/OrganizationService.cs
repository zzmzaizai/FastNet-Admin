namespace FastNet.BlazorCore.HttpRemotes;


/// <summary>
/// 组织部门服务接口
/// </summary>
public interface IOrganizationService : ITransient
{

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    Task<RESTfulResult<List<SysOrganization>>> GetListAsync();

    /// <summary>
    /// 根据组织架构Id获取组织架构
    /// </summary>
    /// <param name="OrganizationId">组织架构编号</param>
    /// <returns></returns>
    Task<RESTfulResult<SysOrganization>> GetAsync(long OrganizationId);

    /// <summary>
    /// 插入组织架构
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysOrganization>> InsertAsync(InsertOrganizationInput dto);

    /// <summary>
    /// 更新组织架构
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysOrganization>> UpdateAsync(UpdateOrganizationInput dto);

    /// <summary>
    /// 删除单个组织架构
    /// </summary>
    /// <param name="OrganizationId">组织架构Id</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteAsync(long OrganizationId);


    /// <summary>
    /// 批量删除组织架构
    /// </summary>
    /// <param name="OrganizationIds">组织架构Id集合</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteAsync(List<long> OrganizationIds);
}


/// <summary>
/// 组织部门服务
/// </summary>
public class OrganizationService : IOrganizationService
{
    /// <summary>
    /// 请求映射接口
    /// </summary>
    protected IHttpOrganizationService organizationHttp { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_organizationHttp"></param>
    public OrganizationService(IHttpOrganizationService _organizationHttp)
    {
        organizationHttp = _organizationHttp;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public async Task<RESTfulResult<List<SysOrganization>>> GetListAsync()
    {
        return await organizationHttp.GetListAsync();
    }

    /// <summary>
    /// 根据组织架构Id获取组织架构
    /// </summary>
    /// <param name="OrganizationId">组织架构编号</param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysOrganization>> GetAsync(long OrganizationId)
    {
        return await organizationHttp.GetAsync(OrganizationId);
    }

    /// <summary>
    /// 插入组织架构
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysOrganization>> InsertAsync(InsertOrganizationInput dto)
    {
        return await organizationHttp.InsertAsync(dto);
    }

    /// <summary>
    /// 更新组织架构
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysOrganization>> UpdateAsync(UpdateOrganizationInput dto)
    {
        return await organizationHttp.UpdateAsync(dto);
    }

    /// <summary>
    /// 删除单个组织架构
    /// </summary>
    /// <param name="OrganizationId">组织架构Id</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteAsync(long OrganizationId)
    {
        return await organizationHttp.DeleteAsync(OrganizationId);
    }

    /// <summary>
    /// 批量删除组织架构
    /// </summary>
    /// <param name="OrganizationIds">组织架构Id集合</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteAsync(List<long> OrganizationIds)
    {
        return await organizationHttp.DeleteAsync(OrganizationIds);
    }
}
