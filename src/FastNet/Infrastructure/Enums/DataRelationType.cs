namespace FastNet.Infrastructure;

/// <summary>
/// 数据关系类型
/// </summary>
public enum DataRelationType
{
    /// <summary>
    /// 用户对角色
    /// </summary>
    UserRole = 0,
    /// <summary>
    /// 用户对组织
    /// </summary>
    UserOrg = 1,
    /// <summary>
    /// 角色对组织
    /// </summary>
    RoleOrg = 2,
    /// <summary>
    /// 角色对菜单
    /// </summary>
    RoleMenu = 3,
    /// <summary>
    /// 客户端对API资源
    /// </summary>
    ClientApi = 4



}
