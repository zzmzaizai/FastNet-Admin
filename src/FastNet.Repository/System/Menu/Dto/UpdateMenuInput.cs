
namespace FastNet.Repository;

/// <summary>
/// 菜单更新DTO
/// </summary>
public class UpdateMenuInput
{
    /// <summary>
    /// 角色编号
    /// </summary>
    public long Id { get; set; }


    /// <summary>
    /// 名称
    ///</summary>
    public string Name { get; set; }

    /// <summary>
    /// 菜单图标
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// 上级菜单Id
    ///</summary>
    public long ParentId { get; set; } = 0;

    /// <summary>
    /// 页面路由
    ///</summary>
    public string Router { get; set; }

    /// <summary>
    /// 页面资源路径
    ///</summary>
    public string Path { get; set; }

    /// <summary>
    /// 链接
    ///</summary>
    public string Link { get; set; }

    /// <summary>
    /// 是否打开新窗口
    ///</summary>
    public bool OpenWindow { get; set; } = false;


    /// <summary>
    /// 排序
    ///</summary>
    public int Order { get; set; } = 0;

    /// <summary>
    /// 是否可见
    /// </summary>
    public bool IsVisible { get; set; }

    /// <summary>
    /// 菜单类型
    /// </summary>
    public DataMenuType Type { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public DataStatus Status { get; set; }
}
