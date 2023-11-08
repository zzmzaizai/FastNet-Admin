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
}
