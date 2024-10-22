﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Service;

/// <summary>
/// 授权角色服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 80)]
public class RoleService : BaseApiController
{

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public async Task<List<SysRole>> GetListAsync()
    {
        return await sysRoleRep.GetListAsync();
    }

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<SqlSugarPagedList<SysRolePageOutput>> GetPageListAsync([FromQuery] QueryRolePagedInput dto)
    {
        return await sysRoleRep.GetPageListAsync(dto);
    }



    /// <summary>
    /// 根据角色Id获取角色
    /// </summary>
    /// <param name="RoleId">角色编号</param>
    /// <returns></returns>
    public async Task<SysRole> GetAsync(long RoleId)
    {
        return await sysRoleRep.GetRoleAsync(RoleId);
    }

    /// <summary>
    /// 删除单个角色
    /// </summary>
    /// <param name="RoleId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(long RoleId)
    {
        return await sysUserRep.DeleteByIdAsync(RoleId);
    }

    /// <summary>
    /// 批量删除角色
    /// </summary>
    /// <param name="RoleIds"></param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(List<long> RoleIds)
    {
        return await sysUserRep.DeleteByIdsAsync(RoleIds);
    }

    /// <summary>
    /// 插入角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysRole> InsertAsync(InsertRoleInput dto)
    {
        return await sysRoleRep.InsertRoleAsync(dto);
    }

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysRole> UpdateAsync(UpdateRoleInput dto)
    {
        return await sysRoleRep.UpdateRoleAsync(dto);
    }


    /// <summary>
    /// 下载种子数据
    /// </summary>
    /// <returns></returns>
    [HttpGet, NonUnify]
    public async Task<IActionResult> DownloadSeedDataAsync()
    {
        var list = await sysRoleRep.GetListAsync();

        var json = new SeedDataRecords<SysRole>
        {
            Records = list
        }.ToJson();

        return new FileContentResult(Encoding.UTF8.GetBytes(json), "application/octet-stream")
        {
            FileDownloadName = "seed_sys_role.json" // 配置文件下载显示名
        };
    }
}
