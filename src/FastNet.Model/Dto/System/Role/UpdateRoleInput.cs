
namespace FastNet.Model.Dto;

/// <summary>
/// 角色更新DTO
/// </summary>
public class UpdateRoleInput
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
    /// 备注
    ///</summary>
    public string Remark { get; set; }


    /// <summary>
    /// 状态
    /// </summary>
    public DataStatus Status { get; set; }
}
