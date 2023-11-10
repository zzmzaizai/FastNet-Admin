


namespace FastNet.Service;

/// <summary>
/// 租户服务
/// </summary>
[Route("api/host/[controller]")]
[ApiDescriptionSettings(groups: "Host", Order = 1)]
public class TenantService : BaseApiController
{

    /// <summary>
    /// 插入租户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysTenant> InsertAsync(InsertTenantInput dto)
    {
        return await sysTenantRep.InsertTenantAsync(dto);
    }

    /// <summary>
    /// 更新租户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysTenant> UpdateAsync(UpdateTenantInput dto)
    {
        return await sysTenantRep.UpdateTenantAsync(dto);
    }

    /// <summary>
    /// 根据主机名获取租户信息
    /// </summary>
    /// <param name="HostName">主机名</param>
    /// <returns>找不到时返回默认租户</returns>
    /// <returns></returns>
    public async Task<SysTenant> GetTenantByHostNameAsync(string HostName)
    {
        return await sysTenantRep.GetTenantAsync(HostName);
    }

    /// <summary>
    /// 获取单个租户信息
    /// </summary>
    /// <param name="TenantId">租户Id</param>
    /// <returns></returns>
    public async Task<SysTenant> GetAsync(long TenantId)
    {
        return await sysTenantRep.GetTenantAsync(TenantId);
    }

    /// <summary>
    /// 获取当前租户信息
    /// </summary>
    /// <returns></returns>
    public async Task<SysTenant> GetCurrent()
    {
        return await sysTenantRep.GetTenantAsync(httpContext.Items.Get("TenantId", 0L));
    }



    /// <summary>
    /// 获取当前租户Id
    /// </summary>
    /// <returns></returns>
    public async Task<long> GetCurrentTenantId()
    {
        return await Task.FromResult(httpContext.Items.Get("TenantId", 0L));
    }

    /// <summary>
    /// 填充一个默认租户
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<SysTenant> FillTenant(bool IsDefault, string DomainName)
    {
        return await sysTenantRep.FillTenant(IsDefault, DomainName);
    }

    /// <summary>
    /// 切换租户站点
    /// </summary>
    /// <param name="TenantId">租户编号</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> ChangeTenantSite(long TenantId)
    {
        var TenantItem =  await sysTenantRep.GetTenantAsync(TenantId);
        if(TenantItem != null && TenantItem.Id > 0)
        {
            httpContext.Items.Set("TenantId", TenantId);
            httpContext.Response.Cookies.Append("TenantId", $"{TenantId}".ToDESCEncrypt("abc123defas@#asd1AAAQs!"));
            httpContext.Response.Cookies.Append("TenantDomain", httpContext.Request.Host.ToString().ToLower());
            return true;
        }else
        {
            return false;
        }
    }


    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<SqlSugarPagedList<SysTenantPageOutput>> GetPageListAsync([FromQuery] QueryTenantPagedInput dto)
    {
        return await sysTenantRep.GetPageListAsync(dto);
    }


    /// <summary>
    /// 下载种子数据
    /// </summary>
    /// <returns></returns>
    [HttpGet, NonUnify]
    public async Task<IActionResult> DownloadSeedDataAsync()
    {
        var list = await sysTenantRep.GetListAsync();

        var json = new SeedDataRecords<SysTenant>
        {
            Records = list
        }.ToJson();

        return new FileContentResult(Encoding.UTF8.GetBytes(json), "application/octet-stream")
        {
            FileDownloadName = "seed_sys_tenant.json" // 配置文件下载显示名
        };
    }
}
