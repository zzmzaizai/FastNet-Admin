namespace FastNet.Model.Entities;
/// <summary>
/// 组织部门表实体
/// </summary>
[SugarTable("sys_organization", TableDescription = "组织部门表")]
[Tenant("FastNet")]
public class SysOrganization : DataEntityBase
{


    /// <summary>
    /// 名称
    ///</summary>
    [SugarColumn(ColumnDescription = "名称", Length = 200, IsNullable = false)]
    public string Name { get; set; }

    /// <summary>
    /// 上级组织Id
    ///</summary>
    [SugarColumn(ColumnDescription = "上级组织Id", IsNullable = false)]
    public long ParentId { get; set; } = 0;

 
    /// <summary>
    /// 负责人
    ///</summary>
    [SugarColumn(ColumnDescription = "负责人", Length = 100, IsNullable = true)]
    public string Leader { get; set; }

    /// <summary>
    /// 电话
    ///</summary>
    [SugarColumn(ColumnDescription = "电话", Length = 100, IsNullable = true)]
    public string Tel { get; set; }


    /// <summary>
    /// 邮箱
    ///</summary>
    [SugarColumn(ColumnDescription = "邮箱", Length = 100, IsNullable = true)]
    public string Email { get; set; }

    /// <summary>
    /// 备注
    ///</summary>
    [SugarColumn(ColumnDescription = "备注", Length = 500, IsNullable = true)]
    public string Remark { get; set; }

    /// <summary>
    /// 排序
    ///</summary>
    [SugarColumn(ColumnDescription = "排序", IsNullable = false)]
    public int Order { get; set; } = 0;

    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态", IsNullable = false)]
    public DataStatus Status { get; set; }

}
