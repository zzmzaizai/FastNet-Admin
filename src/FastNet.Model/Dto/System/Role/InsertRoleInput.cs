
namespace FastNet.Model.Dto;

/// <summary>
/// 角色插入DTO
/// </summary>
public class InsertRoleInput
{
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
