using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Services;

/// <summary>
/// 授权服务
/// </summary>
[Route("api/system/[controller]")]
[ApiDescriptionSettings(groups: "System", Order = 100)]
public class AuthService : BaseApiController
{


    /// <summary>
    /// 系统用户登录
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task SignIn(LoginInput dto)
    {

        //string signInErrorCacheKey = $"login.error.{dto.Account}";
        //CacheValue<int> value = await _easyCachingProvider.GetAsync<int>(signInErrorCacheKey);
        //var setting = await _customConfigService.Get<SysSecuritySetting>();
        ////5分钟内连续验证密码失败超过4次将限制用户尝试
        //if (value.HasValue && value.Value > (setting?.Times ?? 4))
        //{
        //    throw Oops.Bah("由于您多次登录失败，系统已限制账户登录");
        //}
        SysUser user = await sysUserRep.GetUserAsync(dto.UserName);
        if (user == null)
        {
            throw Oops.Bah("用户名或密码错误");
        }

        var context = httpContextAccessor.HttpContext;
        if (user.Status == DataUserStatus.Disable)
        {
            throw Oops.Bah("您的账号被锁定");
        }

        if (user.Password != MD5Encryption.Encrypt($"{user.Secret}{dto.Password}"))
        {
            //await _easyCachingProvider.SetAsync(signInErrorCacheKey, value.Value + 1, TimeSpan.FromMinutes(5));
            throw Oops.Bah("用户名或密码错误");
        }
        long uniqueId = DatabaseUtils.GetDataId();
        string token = JWTEncryption.Encrypt(new Dictionary<string, object>()
        {
            [ClaimConst.UserId] = user.Id,
            [ClaimConst.Account] = user.UserName,
            [ClaimConst.UuidKey] = uniqueId,
            [ClaimConst.IsSuperAdmin] = user.IsSuperAdmin
        });
        // 获取刷新 token
        var refreshToken = JWTEncryption.GenerateRefreshToken(token);
        // 设置响应报文头
        context.SigninToSwagger(token);
        context!.Response.Headers["access-token"] = token;
        context.Response.Headers["x-access-token"] = refreshToken;
    }




}
