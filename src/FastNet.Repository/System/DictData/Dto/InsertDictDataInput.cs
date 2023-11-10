
namespace FastNet.Repository;

/// <summary>
/// 字典数据插入DTO
/// </summary>
public class InsertDictDataInput
{
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
