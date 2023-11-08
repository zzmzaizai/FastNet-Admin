using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Services;

/// <summary>
/// 授权角色服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 80)]
public class RoleService : BaseApiController
{

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
}
