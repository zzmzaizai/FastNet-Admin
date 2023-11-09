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



    /// <summary>
    /// 根据客户端APPId获取客户端APP
    /// </summary>
    /// <param name="ClientAppId">客户端APP编号</param>
    /// <returns></returns>
    public async Task<SysClientApp> GetAsync(long ClientAppId)
    {
        return await sysClientAppRep.GetClientAppAsync(ClientAppId);
    }

    /// <summary>
    /// 插入客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysClientApp> InsertAsync(InsertClientAppInput dto)
    {
        return await sysClientAppRep.InsertClientAppAsync(dto);
    }

    /// <summary>
    /// 更新客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysClientApp> UpdateAsync(UpdateClientAppInput dto)
    {
        return await sysClientAppRep.UpdateClientAppAsync(dto);
    }

    /// <summary>
    /// 重置客户端APP的SecretKey
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPatch]
    public async Task<SysClientApp> ResetSecretAsync(ResetClientAppSecretInput dto)
    {
        return await sysClientAppRep.ResetClientAppSecretAsync(dto);
    }

    /// <summary>
    /// 下载种子数据
    /// </summary>
    /// <returns></returns>
    [HttpGet, NonUnify]
    public async Task<IActionResult> DownloadSeedDataAsync()
    {
        var list = await sysClientAppRep.GetListAsync();

        var json = new SeedDataRecords<SysClientApp>
        {
            Records = list
        }.ToJson();

        return new FileContentResult(Encoding.UTF8.GetBytes(json), "application/octet-stream")
        {
            FileDownloadName = "seed_sys_client_app.json" // 配置文件下载显示名
        };
    }
}
