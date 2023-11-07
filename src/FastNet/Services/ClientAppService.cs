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
     
}
