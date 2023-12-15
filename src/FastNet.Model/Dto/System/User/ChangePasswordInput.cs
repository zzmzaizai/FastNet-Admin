namespace FastNet.Model.Dto;

/// <summary>
/// 密码修改DTO
/// </summary>
public class ChangePasswordInput
{
    /// <summary>
    /// 用户编号
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// 旧密码
    /// </summary>
    public string OldPassword { get; set; }
    /// <summary>
    /// 新密码
    /// </summary>
    public string NewPassword { get; set; }
    /// <summary>
    /// 确认密码
    /// </summary>
    public string SecondaryPassword { get; set; }

}
 