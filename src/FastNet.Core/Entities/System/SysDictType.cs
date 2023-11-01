namespace FastNet.Core;
/// <summary>
/// 字典类型表实体
/// </summary>
[SugarTable("sys_dicttype", TableDescription = "字典类型表")]
[Tenant("FastNet")]
public class SysDictType : SimpleEntityBase
{


    /// <summary>
    /// 字典类型名称
    ///</summary>
    [SugarColumn(ColumnDescription = "字典类型名称", Length = 50, IsNullable = false)]
    public virtual string DictTypeName { get; set; }



    /// <summary>
    /// 字典类型
    ///</summary>
    [SugarColumn(ColumnDescription = "字典类型", Length = 50, IsNullable = false)]
    public virtual string DictType { get; set; }



    /// <summary>
    /// 排序
    ///</summary>
    [SugarColumn(ColumnDescription = "排序", IsNullable = false)]
    public int Order { get; set; } = 0;
}
