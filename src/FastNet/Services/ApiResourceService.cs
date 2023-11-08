using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Services;

/// <summary>
/// API资源服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 50)]
public class ApiResourceService : BaseApiController
{

    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<SqlSugarPagedList<SysApiResourcePageOutput>> GetPageListAsync([FromQuery] QueryApiResourcePagedInput dto)
    {
        return await sysApiResourceRep.GetPageListAsync(dto);
    }



    /// <summary>
    /// 根据API资源Id获取API资源
    /// </summary>
    /// <param name="ApiResourceId">API资源编号</param>
    /// <returns></returns>
    public async Task<SysApiResource> GetAsync(long ApiResourceId)
    {
        return await sysApiResourceRep.GetApiResourceAsync(ApiResourceId);
    }

    /// <summary>
    /// 插入API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysApiResource> InsertAsync(InsertApiResourceInput dto)
    {
        return await sysApiResourceRep.InsertApiResourceAsync(dto);
    }

    /// <summary>
    /// 更新API资源
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysApiResource> UpdateAsync(UpdateApiResourceInput dto)
    {
        return await sysApiResourceRep.UpdateApiResourceAsync(dto);
    }

}
