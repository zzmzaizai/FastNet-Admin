namespace FastNet.Model.Entities;



/// <summary>
/// 客户端应用表实体
/// </summary>
[SugarTable("sys_clientapp", TableDescription = "客户端应用表")]
[Tenant("FastNet")]
public class SysClientApp : DataEntityBase
{
    /// <summary>
    /// 名称
    ///</summary>
    [SugarColumn(ColumnDescription = "名称", Length = 100, IsNullable = false)]
    public string Name { get; set; }
 
    /// <summary>
    /// 客户端编码
    ///</summary>
    [SugarColumn(ColumnDescription = "客户端编码", Length = 50, IsNullable = false)]
    public string ClientCode { get; set; }
 
    /// <summary>
    /// 私钥
    ///</summary>
    [SugarColumn(ColumnDescription = "私钥", Length = 100, IsNullable = false)]
    public string SecretKey { get; set; }
 
    /// <summary>
    /// 电话
    ///</summary>
    [SugarColumn(ColumnDescription = "电话", Length = 30, IsNullable = true)]
    public string Tel { get; set; }
 
    /// <summary>
    /// 邮箱
    ///</summary>
    [SugarColumn(ColumnDescription = "邮箱", Length = 50, IsNullable = true)]
    public string Email { get; set; }
 
    /// <summary>
    /// 联系人
    ///</summary>
    [SugarColumn(ColumnDescription = "联系人", Length = 50, IsNullable = true)]
    public string Contact { get; set; }
 
    /// <summary>
    /// 备注
    ///</summary>
    [SugarColumn(ColumnDescription = "备注", Length = 500, IsNullable = true)]
    public string Remark { get; set; }
 
    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态", IsNullable = false)]
    public DataStatus Status { get; set; }

}

