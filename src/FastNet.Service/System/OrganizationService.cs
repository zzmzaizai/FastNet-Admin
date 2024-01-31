using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Service;

/// <summary>
/// 组织部门服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System",Order = 70)]
public class OrganizationService : BaseApiController
{
    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public async Task<List<SysOrganization>> GetListAsync()
    {
        return await sysOrganizationRep.GetListAsync();
    }

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<SqlSugarPagedList<SysOrganizationPageOutput>> GetPageListAsync([FromQuery] QueryOrganizationPagedInput dto)
    {
        return await sysOrganizationRep.GetPageListAsync(dto);
    }

    /// <summary>
    /// 根据组织架构Id获取组织架构
    /// </summary>
    /// <param name="OrganizationId">组织架构编号</param>
    /// <returns></returns>
    public async Task<SysOrganization> GetAsync(long OrganizationId)
    {
        return await sysOrganizationRep.GetOrganizationAsync(OrganizationId);
    }

    /// <summary>
    /// 删除单个组织架构
    /// </summary>
    /// <param name="OrganizationId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(long OrganizationId)
    {
        return await sysUserRep.DeleteByIdAsync(OrganizationId);
    }

    /// <summary>
    /// 批量删除组织架构
    /// </summary>
    /// <param name="OrganizationIds"></param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(List<long> OrganizationIds)
    {
        return await sysUserRep.DeleteByIdsAsync(OrganizationIds);
    }

    /// <summary>
    /// 插入组织架构
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysOrganization> InsertAsync(InsertOrganizationInput dto)
    {
        return await sysOrganizationRep.InsertOrganizationAsync(dto);
    }

    /// <summary>
    /// 更新组织架构
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysOrganization> UpdateAsync(UpdateOrganizationInput dto)
    {
        return await sysOrganizationRep.UpdateOrganizationAsync(dto);
    }



    /// <summary>
    /// 下载种子数据
    /// </summary>
    /// <returns></returns>
    [HttpGet, NonUnify]
    public async Task<IActionResult> DownloadSeedDataAsync()
    {
        var list = await sysOrganizationRep.GetListAsync();

        var json = new SeedDataRecords<SysOrganization>
        {
            Records = list
        }.ToJson();

        return new FileContentResult(Encoding.UTF8.GetBytes(json), "application/octet-stream")
        {
            FileDownloadName = "seed_sys_organization.json" // 配置文件下载显示名
        };
    }
}
