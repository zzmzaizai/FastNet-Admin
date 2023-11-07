namespace FastNet.Infrastructure;

/// <summary>
/// 菜单类型
/// </summary>
public enum DataMenuType
{
    /// <summary>
    /// 目录
    /// </summary>
    [Description("目录")]
    Catalog,
    /// <summary>
    /// 菜单
    /// </summary>
    [Description("菜单")]
    Menu,
    /// <summary>
    /// 按钮
    /// </summary>
    [Description("按钮")]
    Button,
    /// <summary>
    /// 链接
    /// </summary>
    [Description("链接")]
    Link

}
