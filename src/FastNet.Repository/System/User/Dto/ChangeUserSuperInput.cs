
namespace FastNet.Repository;

/// <summary>
/// 切换超级用户DTO
/// </summary>
public class ChangeUserSuperInput
{
    /// <summary>
    /// 用户编号
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// 是否超级管理员
    /// </summary>
    public bool IsSuperAdmin { get; set; }

}
