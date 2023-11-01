using FastNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Web.Core.Controllers;

/// <summary>
/// 全局配置服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 20)]
public class ConfigController : IDynamicApiController
{
    private readonly ISysUserRepository _userRep;
    public ConfigController(ISysUserRepository userRep)
    {
        _userRep = userRep;
    }

    /// <summary>
    /// 获取信息(测试用)
    /// </summary>
    /// <returns></returns>
    public string GetInfo()
    {
        return $"现在时间是{DateTime.Now}";
    }


}
