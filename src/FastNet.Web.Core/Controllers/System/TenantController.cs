


namespace FastNet.Web.Core.Controllers;

/// <summary>
/// 租户服务
/// </summary>
[Route("api/host/[controller]")]
[ApiDescriptionSettings(groups: "Host", Order = 1)]
public class TenantController : BaseApiController
{


    /// <summary>
    /// 获取当前租户信息
    /// </summary>
    /// <returns></returns>
    public async Task<SysTenant> GetCurrentTenant()
    {
        return await sysTenantRep.GetItemByTenantId(httpContextAccessor.HttpContext.Items.Get("TenantId", 0L));
    }

    /// <summary>
    /// 获取当前租户Id
    /// </summary>
    /// <returns></returns>
    public long GetCurrentTenantId()
    {
        return httpContextAccessor.HttpContext.Items.Get("TenantId", 0L);
    }

    /// <summary>
    /// 填充一个默认租户
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<SysTenant> FillDefaultTenant()
    {
        return await sysTenantRep.FillDefaultTenant();
    }

    /// <summary>
    /// 切换租户站点
    /// </summary>
    /// <param name="TenantId">租户编号</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> ChangeTenantSite(long TenantId)
    {
        var TenantItem =  await sysTenantRep.GetItemByTenantId(TenantId);
        if(TenantItem != null && TenantItem.Id > 0)
        {
            httpContextAccessor.HttpContext.Items.Set("TenantId", TenantId);
            httpContextAccessor.HttpContext.Response.Cookies.Append("TenantId", $"{TenantId}".ToDESCEncrypt("abc123defas@#asd1AAAQs!"));
            return true;
        }else
        {
            return false;
        }
    }
}
