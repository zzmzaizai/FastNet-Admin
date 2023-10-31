﻿namespace FastNet.Core;
/// <summary>
/// 角色表实体
/// </summary>
[SugarTable("sys_role", TableDescription = "角色表")]
public class SysRole : DataEntityBase
{

    /// <summary>
    /// 名称
    ///</summary>
    [SugarColumn(ColumnDescription = "名称", Length = 200, IsNullable = false)]
    public virtual string Name { get; set; }


    /// <summary>
    /// 备注
    ///</summary>
    [SugarColumn(ColumnDescription = "备注", Length = 500, IsNullable = true)]
    public virtual string Remark { get; set; }


    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态", IsNullable = false)]
    public DataStatus Status { get; set; }
}