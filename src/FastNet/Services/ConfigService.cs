
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Services;

/// <summary>
/// 全局配置服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 20)]
public class ConfigService : BaseApiController
{

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<SqlSugarPagedList<SysConfigPageOutput>> GetPageListAsync([FromQuery] QueryConfigPagedInput dto)
    {
        return await sysConfigRep.GetPageListAsync(dto);
    }

}
