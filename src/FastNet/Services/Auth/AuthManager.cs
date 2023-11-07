
namespace FastNet.Services;

/// <summary>
/// 用户授权信息
/// </summary>
public class AuthManager : ITransient
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// 用户Id
    /// </summary>
    public long UserId => _httpContextAccessor.HttpContext!.User.FindFirst(ClaimConst.UserId)?.Value.Adapt<long>() ?? 0;

    /// <summary>
    /// 是否是超级管理员
    /// </summary>
    public bool IsSuperAdmin => _httpContextAccessor.HttpContext!.User.FindFirst(ClaimConst.IsSuperAdmin)?.Value.Adapt<bool>() ?? false;
    /// <summary>
    /// 登录名
    /// </summary>
    public string Account => _httpContextAccessor.HttpContext!.User.FindFirst(ClaimConst.Account)!.Value;

    /// <summary>
    /// 登录唯一Id
    /// </summary>
    public long UniqueId => _httpContextAccessor.HttpContext!.User.FindFirst(ClaimConst.UuidKey)!.Value.Adapt<long>();


}
