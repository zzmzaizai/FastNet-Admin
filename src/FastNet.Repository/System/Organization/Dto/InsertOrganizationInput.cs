
namespace FastNet.Repository;

/// <summary>
/// 组织架构插入DTO
/// </summary>
public class InsertOrganizationInput
{

    /// <summary>
    /// 名称
    ///</summary>
    public string Name { get; set; }

    /// <summary>
    /// 上级组织Id
    ///</summary>
    public long ParentId { get; set; } = 0;


    /// <summary>
    /// 负责人
    ///</summary>
    public string Leader { get; set; }

    /// <summary>
    /// 电话
    ///</summary>
    public string Tel { get; set; }


    /// <summary>
    /// 邮箱
    ///</summary>
    public string Email { get; set; }

    /// <summary>
    /// 备注
    ///</summary>
    public string Remark { get; set; }

    /// <summary>
    /// 排序
    ///</summary>
    public int Order { get; set; } = 0;

    /// <summary>
    /// 状态
    /// </summary>
    public DataStatus Status { get; set; }
}
