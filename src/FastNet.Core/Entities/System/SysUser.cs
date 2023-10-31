namespace FastNet.Core;


/// <summary>
/// 用户信息表实体
///</summary>
[SugarTable("sys_user", TableDescription = "用户表")]
public class SysUser : BaseEntity
{

    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态", IsNullable = false)]
    public DataUserStatus Status { get; set; }
}
