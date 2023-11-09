namespace FastNet.Models;
/// <summary>
/// 租户表实体
/// </summary>
[SugarTable("sys_tenant", TableDescription = "租户表")]
[Tenant("FastNet")]
public class SysTenant : BaseEntity
{
    /// <summary>
    /// 租户名、公司名
    ///</summary>
    [SugarColumn(ColumnDescription = "租户名、公司名", Length = 200, IsNullable = false)]
    public string Name { get; set; }


    /// <summary>
    /// 绑定域名 - 多个域名逗号间隔
    ///</summary>
    [SugarColumn(ColumnDescription = "绑定域名", Length = 500, IsNullable = true)]
    public string Domains { get; set; }


    /// <summary>
    /// 开始时间
    /// </summary>
    [SugarColumn(ColumnDescription = "开始时间", IsNullable = true)]
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [SugarColumn(ColumnDescription = "结束时间", IsNullable = true)]
    public DateTime? EndDate { get; set; }

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
    /// 联系人
    ///</summary>
    [SugarColumn(ColumnDescription = "联系人", Length = 100, IsNullable = true)]
    public string Contact { get; set; }


    /// <summary>
    /// 备注
    ///</summary>
    [SugarColumn(ColumnDescription = "备注", Length = 500, IsNullable = true)]
    public string Remark { get; set; }


    /// <summary>
    /// 默认站点
    /// </summary>
    [SugarColumn(ColumnDescription = "默认站点", IsNullable = false,DefaultValue = "0")]
    public bool IsDefault { get; set; }


    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态", IsNullable = false)]
    public DataStatus Status { get; set; }



}
