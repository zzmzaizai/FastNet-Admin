
namespace FastNet.Repositories;

/// <summary>
/// 字典类型更新DTO
/// </summary>
public class UpdateDictTypeInput
{
    /// <summary>
    /// 字典类型编号
    /// </summary>
    public long Id { get; set; }

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
