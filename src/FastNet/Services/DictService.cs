using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Services;

/// <summary>
/// 数据字典服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 30)]
public class DictService : BaseApiController
{
    /// <summary>
    /// 字典数据分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<SqlSugarPagedList<SysDictDataPageOutput>> GetDictDataPageListAsync([FromQuery] QueryDictDataPagedInput dto)
    {
        return await sysDictDataRep.GetPageListAsync(dto);
    }


    /// <summary>
    /// 字典类型分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<SqlSugarPagedList<SysDictTypePageOutput>> GetDictTypePageListAsync([FromQuery] QueryDictTypePagedInput dto)
    {
        return await sysDictTypeRep.GetPageListAsync(dto);
    }

}
