using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Web.Core.Controllers;

/// <summary>
/// 账号服务
/// </summary>
public class AccountController : IDynamicApiController
{

    public AccountController()
    {
        
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
