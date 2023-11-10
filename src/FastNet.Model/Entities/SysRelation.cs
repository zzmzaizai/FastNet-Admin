namespace FastNet.Model.Entities;

/// <summary>
/// 系统关系表实体
/// </summary>
[SugarTable("sys_relation", TableDescription = "系统关系表")]
[Tenant("FastNet")]
public class SysRelation : SimpleEntityBase
{
    /// <summary>
    /// 源数据Id
    ///</summary>
    [SugarColumn(ColumnDescription = "源数据Id", IsNullable = false)]
    public long SourceId { get; set; }

    /// <summary>
    /// 目标数据Id
    ///</summary>
    [SugarColumn(ColumnDescription = "目标数据Id", IsNullable = false)]
    public long TargetId { get; set; }

    /// <summary>
    /// 关系类型
    /// </summary>
    [SugarColumn(ColumnDescription = "关系类型", IsNullable = false)]
    public DataRelationType RelationType { get; set; }


    /// <summary>
    /// 额外数据
    ///</summary>
    [SugarColumn(ColumnDescription = "额外数据", IsNullable = true)]
    public string ExtraData { get; set; }

}

