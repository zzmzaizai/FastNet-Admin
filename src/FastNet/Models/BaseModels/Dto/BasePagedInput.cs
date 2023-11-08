namespace FastNet.Models;

/// <summary>
/// 翻页基础输入项
/// </summary>
public class BasePagedInput
{
    /// <summary>
    /// 当前页码
    /// </summary>
    [DataValidation(ValidationTypes.Numeric)]
    public virtual int Index { get; set; } = 1;

    /// <summary>
    /// 每页条数
    /// </summary>
    [Range(1, 100, ErrorMessage = "页码容量超过最大限制")]
    [DataValidation(ValidationTypes.Numeric)]
    public virtual int Size { get; set; } = 10;

    /// <summary>
    /// 排序集合
    /// </summary>
    public List<OrderByModel> OrderConditions { get; set; }

    /// <summary>
    /// 搜索集合（此集合中的会用作OR相连，并like）
    /// </summary>
    public Dictionary<string, string> SearchFilterConditions { get; set; } 

}
