namespace FastNet.Core;
/// <summary>
/// 系统配置表实体
/// </summary>
[SugarTable("sys_config", TableDescription = "系统配置表")]
public class SysConfig : SimpleEntityBase
{

    /// <summary>
    /// 配置名称
    ///</summary>
    [SugarColumn(ColumnDescription = "配置名称", Length = 200, IsNullable = true)]
    public virtual string Lable { get; set; }



    /// <summary>
    /// 配置Key
    ///</summary>
    [SugarColumn(ColumnDescription = "配置Key", Length = 50, IsNullable = false)]
    public virtual string Key { get; set; }


    /// <summary>
    /// 配置值
    ///</summary>
    [SugarColumn(ColumnDescription = "配置值", IsNullable = true)]
    public virtual string Value { get; set; }
}
