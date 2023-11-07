namespace FastNet.Models;
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
    public string Name { get; set; }

    /// <summary>
    /// 菜单图标
    /// </summary>
    [SugarColumn(Length = 64, IsNullable = true)]
    public  string Icon { get; set; }

    /// <summary>
    /// 上级菜单Id
    ///</summary>
    [SugarColumn(ColumnDescription = "上级菜单Id", IsNullable = false)]
    public long ParentId { get; set; } = 0;

    /// <summary>
    /// 页面路由
    ///</summary>
    [SugarColumn(ColumnDescription = "页面路由", Length = 500, IsNullable = false)]
    public string Router { get; set; }

    /// <summary>
    /// 页面资源路径
    ///</summary>
    [SugarColumn(ColumnDescription = "页面资源路径", Length = 500, IsNullable = false)]
    public string Path { get; set; }

    /// <summary>
    /// 链接
    ///</summary>
    [SugarColumn(ColumnDescription = "链接",  IsNullable = true)]
    public string Link { get; set; }

    /// <summary>
    /// 是否打开新窗口
    ///</summary>
    [SugarColumn(ColumnDescription = "是否打开新窗口")]
    public bool OpenWindow { get; set; } = false;


    /// <summary>
    /// 排序
    ///</summary>
    [SugarColumn(ColumnDescription = "排序", IsNullable = false)]
    public int Order { get; set; } = 0;

    /// <summary>
    /// 是否可见
    /// </summary>
    [SugarColumn(ColumnDescription = "是否可见", IsNullable = false)]
    public bool IsVisible { get; set; }

    /// <summary>
    /// 菜单类型
    /// </summary>
    [SugarColumn(ColumnDescription = "菜单类型", IsNullable = false)]
    public DataMenuType Type { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态", IsNullable = false)]
    public DataStatus Status { get; set; }
}
