
using SqlSugar;
using System.Text;

namespace FastNet.BlazorCore;


/// <summary>
/// 字典服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpDictService : IBaseHttpRemote
{

    /// <summary>
    /// 字典数据分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Get("api/system/dict/dict-data-page-list")]
    Task<RESTfulResult<SqlSugarPagedList<SysDictDataPageOutput>>> GetDictDataPageListAsync([FromQuery] QueryDictDataPagedInput dto);


    /// <summary>
    /// 字典类型分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Get("api/system/dict/dict-type-page-list")]
    Task<RESTfulResult<SqlSugarPagedList<SysDictTypePageOutput>>> GetDictTypePageListAsync([FromQuery] QueryDictTypePagedInput dto);



    /// <summary>
    /// 根据字典类型Id获取字典类型
    /// </summary>
    /// <param name="DictTypeId">字典类型编号</param>
    /// <returns></returns>
    [Get("api/system/dict/dict-type/{dicttypeid}")]
    Task<RESTfulResult<SysDictType>> GetDictTypeAsync(long DictTypeId);

    /// <summary>
    /// 删除单个字典类型
    /// </summary>
    /// <param name="DictTypeId">字典类型Id</param>
    /// <returns></returns>
    [Delete("api/system/dict/dict-type/{dicttypeid}")]
    Task<RESTfulResult<bool>> DeleteDictTypeAsync(long DictTypeId);


    /// <summary>
    /// 批量删除字典类型
    /// </summary>
    /// <param name="DictTypeIds">字典类型Id集合</param>
    /// <returns></returns>
    [Delete("api/system/dict/dict-type")]
    Task<RESTfulResult<bool>> DeleteDictTypeAsync([Body("application/json")] List<long> DictTypeIds);

    /// <summary>
    /// 插入字典类型
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("api/system/dict/dict-type")]
    Task<RESTfulResult<SysDictType>> InsertDictTypeAsync([Body("application/json")] InsertDictTypeInput dto);

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Put("api/system/dict/dict-type")]
    Task<RESTfulResult<SysDictType>> UpdateDictTypeAsync([Body("application/json")] UpdateDictTypeInput dto);



    /// <summary>
    /// 根据字典数据Id获取字典数据
    /// </summary>
    /// <param name="DictDataId">字典数据编号</param>
    /// <returns></returns>
    [Get("api/system/dict/dict-data/{dictdataid}")]
    Task<RESTfulResult<SysDictData>> GetDictDataAsync(long DictDataId);

    /// <summary>
    /// 删除单个字典数据
    /// </summary>
    /// <param name="DictDataId">字典数据Id</param>
    /// <returns></returns>
    [Delete("api/system/dict/dict-data/{dictdataid}")]
    Task<RESTfulResult<bool>> DeleteDictDataAsync(long DictDataId);


    /// <summary>
    /// 批量删除字典数据
    /// </summary>
    /// <param name="DictDataIds">字典数据Id集合</param>
    /// <returns></returns>
    [Delete("api/system/dict/dict-data")]
    Task<RESTfulResult<bool>> DeleteDictDataAsync([Body("application/json")] List<long> DictDataIds);

    /// <summary>
    /// 插入字典数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("api/system/dict/dict-data")]
    Task<RESTfulResult<SysDictData>> InsertDictDataAsync([Body("application/json")] InsertDictDataInput dto);

    /// <summary>
    /// 更新字典数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Put("api/system/dict/dict-data")]
    Task<RESTfulResult<SysDictData>> UpdateDictDataAsync([Body("application/json")] UpdateDictDataInput dto);

 

}
