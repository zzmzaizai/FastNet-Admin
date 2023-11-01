﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Web.Core.Controllers;

/// <summary>
/// 组织部门服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System",Order = 70)]
public class OrganizationController : IDynamicApiController
{

    public OrganizationController()
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