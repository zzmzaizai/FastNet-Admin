using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Services;

/// <summary>
/// API资源服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 50)]
public class ApiResourceService : BaseApiController
{

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<SqlSugarPagedList<SysApiResourcePageOutput>> GetPageListAsync([FromQuery] QueryApiResourcePagedInput dto)
    {
        return await sysApiResourceRep.GetPageListAsync(dto);
    }

}
