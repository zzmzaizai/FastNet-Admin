
namespace FastNet.Repositories;

/// <summary>
/// 用户查询分页DTO
/// </summary>
public class QueryUserPagedInput : BasePagedInput
{
     


    /// <summary>
    /// 是否超级管理员
    /// </summary>
    public bool? IsSuperAdmin { get; set; }


    /// <summary>
    /// 状态
    /// </summary>
    public DataUserStatus? Status { get; set; }
}

