
namespace FastNet.Repositories;

/// <summary>
/// 字典数据更新DTO
/// </summary>
public class UpdateDictDataInput
{
    /// <summary>
    /// 字典数据编号
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 字典名称
    ///</summary>
    public string DictName { get; set; }

    /// <summary>
    /// 字典类型
    ///</summary>
    public string DictType { get; set; }


    /// <summary>
    /// 字典值
    ///</summary>
    public string DictValue { get; set; }

    /// <summary>
    /// 排序
    ///</summary>
    public int Order { get; set; } = 0;
    /// <summary>
    /// 状态
    /// </summary>
    public DataStatus Status { get; set; }
}
