
namespace FastNet.Repository;

/// <summary>
/// 字典类型插入DTO
/// </summary>
public class InsertDictTypeInput
{
    /// <summary>
    /// 字典类型名称
    ///</summary>
    public string DictTypeName { get; set; }



    /// <summary>
    /// 字典类型
    ///</summary>
    public string DictType { get; set; }



    /// <summary>
    /// 排序
    ///</summary>
    public int Order { get; set; } = 0;
}
