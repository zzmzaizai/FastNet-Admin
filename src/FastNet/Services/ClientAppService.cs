using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Services;

/// <summary>
/// 客户端应用服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 40)]
public class ClientAppService : BaseApiController
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<SqlSugarPagedList<SysClientAppPageOutput>> GetPageListAsync([FromQuery] QueryClientAppPagedInput dto)
    {
        return await sysClientAppRep.GetPageListAsync(dto);
    }
}
