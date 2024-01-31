namespace FastNet.BlazorCore.HttpRemotes;


/// <summary>
/// 数据字典服务接口
/// </summary>
public interface IDictService : ITransient
{

    /// <summary>
    /// 字典数据分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SqlSugarPagedList<SysDictDataPageOutput>>> GetDictDataPageListAsync(QueryDictDataPagedInput dto);


    /// <summary>
    /// 字典类型分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SqlSugarPagedList<SysDictTypePageOutput>>> GetDictTypePageListAsync(QueryDictTypePagedInput dto);



    /// <summary>
    /// 根据字典类型Id获取字典类型
    /// </summary>
    /// <param name="DictTypeId">字典类型编号</param>
    /// <returns></returns>
    Task<RESTfulResult<SysDictType>> GetDictTypeAsync(long DictTypeId);

    /// <summary>
    /// 删除单个字典类型
    /// </summary>
    /// <param name="DictTypeId">字典类型Id</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteDictTypeAsync(long DictTypeId);


    /// <summary>
    /// 批量删除字典类型
    /// </summary>
    /// <param name="DictTypeIds">字典类型Id集合</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteDictTypeAsync(List<long> DictTypeIds);

    /// <summary>
    /// 插入字典类型
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysDictType>> InsertDictTypeAsync(InsertDictTypeInput dto);

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysDictType>> UpdateDictTypeAsync(UpdateDictTypeInput dto);

    /// <summary>
    /// 根据字典数据Id获取字典数据
    /// </summary>
    /// <param name="DictDataId">字典数据编号</param>
    /// <returns></returns>
    Task<RESTfulResult<SysDictData>> GetDictDataAsync(long DictDataId);

    /// <summary>
    /// 删除单个字典数据
    /// </summary>
    /// <param name="DictDataId">字典数据Id</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteDictDataAsync(long DictDataId);


    /// <summary>
    /// 批量删除字典数据
    /// </summary>
    /// <param name="DictDataIds">字典数据Id集合</param>
    /// <returns></returns>
    Task<RESTfulResult<bool>> DeleteDictDataAsync(List<long> DictDataIds);

    /// <summary>
    /// 插入字典数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysDictData>> InsertDictDataAsync(InsertDictDataInput dto);

    /// <summary>
    /// 更新字典数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RESTfulResult<SysDictData>> UpdateDictDataAsync(UpdateDictDataInput dto);
}


/// <summary>
/// 数据字典服务
/// </summary>
public class DictService : IDictService
{
    /// <summary>
    /// 请求映射接口
    /// </summary>
    protected IHttpDictService dictHttp { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_dictHttp"></param>
    public DictService(IHttpDictService _dictHttp)
    {
        dictHttp = _dictHttp;
    }

    /// <summary>
    /// 字典数据分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SqlSugarPagedList<SysDictDataPageOutput>>> GetDictDataPageListAsync(QueryDictDataPagedInput dto)
    {
        return await dictHttp.GetDictDataPageListAsync(dto);
    }


    /// <summary>
    /// 字典类型分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SqlSugarPagedList<SysDictTypePageOutput>>> GetDictTypePageListAsync(QueryDictTypePagedInput dto)
    {
        return await dictHttp.GetDictTypePageListAsync(dto);
    }



    /// <summary>
    /// 根据字典类型Id获取字典类型
    /// </summary>
    /// <param name="DictTypeId">字典类型编号</param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysDictType>> GetDictTypeAsync(long DictTypeId)
    {
        return await dictHttp.GetDictTypeAsync(DictTypeId);
    }

    /// <summary>
    /// 删除单个字典类型
    /// </summary>
    /// <param name="DictTypeId">字典类型Id</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteDictTypeAsync(long DictTypeId)
    {
        return await dictHttp.DeleteDictTypeAsync(DictTypeId);
    }


    /// <summary>
    /// 批量删除字典类型
    /// </summary>
    /// <param name="DictTypeIds">字典类型Id集合</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteDictTypeAsync(List<long> DictTypeIds)
    {
        return await dictHttp.DeleteDictTypeAsync(DictTypeIds);
    }

    /// <summary>
    /// 插入字典类型
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysDictType>> InsertDictTypeAsync(InsertDictTypeInput dto)
    {
        return await dictHttp.InsertDictTypeAsync(dto);
    }

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysDictType>> UpdateDictTypeAsync(UpdateDictTypeInput dto)
    {
        return await dictHttp.UpdateDictTypeAsync(dto);
    }



    /// <summary>
    /// 根据字典数据Id获取字典数据
    /// </summary>
    /// <param name="DictDataId">字典数据编号</param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysDictData>> GetDictDataAsync(long DictDataId)
    {
        return await dictHttp.GetDictDataAsync(DictDataId);
    }

    /// <summary>
    /// 删除单个字典数据
    /// </summary>
    /// <param name="DictDataId">字典数据Id</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteDictDataAsync(long DictDataId)
    {
        return await dictHttp.DeleteDictDataAsync(DictDataId);
    }


    /// <summary>
    /// 批量删除字典数据
    /// </summary>
    /// <param name="DictDataIds">字典数据Id集合</param>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> DeleteDictDataAsync(List<long> DictDataIds)
    {
        return await dictHttp.DeleteDictDataAsync(DictDataIds);
    }

    /// <summary>
    /// 插入字典数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysDictData>> InsertDictDataAsync(InsertDictDataInput dto)
    {
        return await dictHttp.InsertDictDataAsync(dto);
    }

    /// <summary>
    /// 更新字典数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SysDictData>> UpdateDictDataAsync(UpdateDictDataInput dto)
    {
        return await dictHttp.UpdateDictDataAsync(dto);
    }

     
}
