
namespace FastNet.Repositories;

/// <summary>
/// 客户端APP更新DTO
/// </summary>
public class UpdateClientAppInput
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
    /// 客户端编码
    ///</summary>
    public string ClientCode { get; set; }

    /// <summary>
    /// 私钥
    ///</summary>
    public string SecretKey { get; set; }

    /// <summary>
    /// 电话
    ///</summary>
    public string Tel { get; set; }

    /// <summary>
    /// 邮箱
    ///</summary>
    public string Email { get; set; }

    /// <summary>
    /// 联系人
    ///</summary>
    public string Contact { get; set; }

    /// <summary>
    /// 备注
    ///</summary>
    public string Remark { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public DataStatus Status { get; set; }
}
