namespace FastNet.Core;

/// <summary>
/// 字典数据表实体
/// </summary>
[SugarTable("sys_dictdata", TableDescription = "字典数据表")]
[Tenant("FastNet")]
public class SysDictData : SimpleEntityBase
{

    /// <summary>
    /// 字典名称
    ///</summary>
    [SugarColumn(ColumnDescription = "字典名称", Length = 50, IsNullable = false)]
    public virtual string DictName { get; set; }



    /// <summary>
    /// 字典类型
    ///</summary>
    [SugarColumn(ColumnDescription = "字典类型", Length = 50, IsNullable = false)]
    public virtual string DictType { get; set; }


    /// <summary>
    /// 字典值
    ///</summary>
    [SugarColumn(ColumnDescription = "字典值", IsNullable = true)]
    public virtual string DictValue { get; set; }

    /// <summary>
    /// 排序
    ///</summary>
    [SugarColumn(ColumnDescription = "排序", IsNullable = false)]
    public int Order { get; set; } = 0;
    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态", IsNullable = false)]
    public virtual DataStatus Status { get; set; }
}
