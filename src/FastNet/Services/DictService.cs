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



    /// <summary>
    /// 根据字典类型Id获取字典类型
    /// </summary>
    /// <param name="DictTypeId">字典类型编号</param>
    /// <returns></returns>
    public async Task<SysDictType> GetDictTypeAsync(long DictTypeId)
    {
        return await sysDictTypeRep.GetDictTypeAsync(DictTypeId);
    }

    /// <summary>
    /// 插入字典类型
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysDictType> InsertDictTypeAsync(InsertDictTypeInput dto)
    {
        return await sysDictTypeRep.InsertDictTypeAsync(dto);
    }

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysDictType> UpdateDictTypeAsync(UpdateDictTypeInput dto)
    {
        return await sysDictTypeRep.UpdateDictTypeAsync(dto);
    }



    /// <summary>
    /// 根据字典数据Id获取字典数据
    /// </summary>
    /// <param name="DictDataId">字典数据编号</param>
    /// <returns></returns>
    public async Task<SysDictData> GetDictDataAsync(long DictDataId)
    {
        return await sysDictDataRep.GetDictDataAsync(DictDataId);
    }

    /// <summary>
    /// 插入字典数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysDictData> InsertDictDataAsync(InsertDictDataInput dto)
    {
        return await sysDictDataRep.InsertDictDataAsync(dto);
    }

    /// <summary>
    /// 更新字典数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysDictData> UpdateDictDataAsync(UpdateDictDataInput dto)
    {
        return await sysDictDataRep.UpdateDictDataAsync(dto);
    }


}
