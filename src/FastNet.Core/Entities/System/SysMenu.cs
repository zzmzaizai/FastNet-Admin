namespace FastNet.Core;
/// <summary>
/// 菜单表实体
/// </summary>
[SugarTable("sys_menu", TableDescription = "菜单表")]
[Tenant("FastNet")]
public class SysMenu : DataEntityBase
{

    /// <summary>
    /// 名称
    ///</summary>
    [SugarColumn(ColumnDescription = "名称", Length = 200, IsNullable = false)]
    public virtual string Name { get; set; }

    /// <summary>
    /// 上级菜单Id
    ///</summary>
    [SugarColumn(ColumnDescription = "上级菜单Id", IsNullable = false)]
    public long ParentId { get; set; } = 0;


    /// <summary>
    /// 页面路由
    ///</summary>
    [SugarColumn(ColumnDescription = "页面路由", Length = 500, IsNullable = false)]
    public virtual string Router { get; set; }


    /// <summary>
    /// 页面资源路径
    ///</summary>
    [SugarColumn(ColumnDescription = "页面资源路径", Length = 500, IsNullable = false)]
    public virtual string Path { get; set; }



    /// <summary>
    /// 拥有动作集合 - 多个动作枚举之间逗号分割
    ///</summary>
    [SugarColumn(ColumnDescription = "拥有动作集合",  IsNullable = true)]
    public virtual string Actions { get; set; }



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
