


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
        return await sysTenantRep.GetItemByTenantId(httpContext.Items.Get("TenantId", 0L));
    }

    /// <summary>
    /// 获取所有租户
    /// </summary>
    /// <returns></returns>
    public async Task<List< SysTenant>> GetAllList()
    {
        return await sysTenantRep.GetAllList();
    }

    /// <summary>
    /// 获取当前租户Id
    /// </summary>
    /// <returns></returns>
    public long GetCurrentTenantId()
    {
        return httpContext.Items.Get("TenantId", 0L);
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
        var TenantItem =  await sysTenantRep.GetItemByTenantId(TenantId);
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
}
