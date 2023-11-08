﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Services;

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
    /// 根据组织架构Id获取组织架构
    /// </summary>
    /// <param name="OrganizationId">组织架构编号</param>
    /// <returns></returns>
    public async Task<SysOrganization> GetAsync(long OrganizationId)
    {
        return await sysOrganizationRep.GetOrganizationAsync(OrganizationId);
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
}
