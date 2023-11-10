
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Service;

/// <summary>
/// 全局配置服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 20)]
public class ConfigService : BaseApiController
{

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public async Task<List<SysConfig>> GetListAsync()
    {
        return await sysConfigRep.GetListAsync();
    }

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



    /// <summary>
    /// 下载种子数据
    /// </summary>
    /// <returns></returns>
    [HttpGet, NonUnify]
    public async Task<IActionResult> DownloadSeedDataAsync()
    {
        var list = await sysConfigRep.GetListAsync();

        var json = new SeedDataRecords<SysConfig>
        {
            Records = list
        }.ToJson();

        return new FileContentResult(Encoding.UTF8.GetBytes(json), "application/octet-stream")
        {
            FileDownloadName = "seed_sys_config.json" // 配置文件下载显示名
        };
    }

}
