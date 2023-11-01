using FastNet.Infrastructure.Extensions;
using Furion.DataEncryption.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Web.Core.Controllers;

/// <summary>
/// 租户服务
/// </summary>
[Route("api/host/[controller]")]
[ApiDescriptionSettings(groups: "Host", Order = 1)]
public class TenantController : IDynamicApiController
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ISysTenantRepository _tenantRepository;
    public TenantController(IHttpContextAccessor httpContextAccessor
        , ISysTenantRepository tenantRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _tenantRepository = tenantRepository;
    }

    /// <summary>
    /// 获取当前租户信息
    /// </summary>
    /// <returns></returns>
    public async Task<SysTenant> GetCurrentTenant()
    {
        return await _tenantRepository.GetItemByTenantId(_httpContextAccessor.HttpContext.Items.Get("TenantId", 0L));
    }

    /// <summary>
    /// 获取当前租户Id
    /// </summary>
    /// <returns></returns>
    public long GetCurrentTenantId()
    {
        return _httpContextAccessor.HttpContext.Items.Get("TenantId", 0L);
    }

    /// <summary>
    /// 填充一个默认租户
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<SysTenant> FillDefaultTenant()
    {
        return await _tenantRepository.FillDefaultTenant();
    }

    /// <summary>
    /// 切换租户站点
    /// </summary>
    /// <param name="TenantId">租户编号</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> ChangeTenantSite(long TenantId)
    {
        var TenantItem =  await _tenantRepository.GetItemByTenantId(TenantId);
        if(TenantItem != null && TenantItem.Id > 0)
        {
            _httpContextAccessor.HttpContext.Items.Set("TenantId", TenantId);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("TenantId", $"{TenantId}".ToDESCEncrypt("abc123defas@#asd1AAAQs!"));
            return true;
        }else
        {
            return false;
        }
    }
}
