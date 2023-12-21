using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FastNet.BlazorCore.Services;

/// <summary>
/// 授权状态提供程序
/// </summary>
public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IAuthService _Auth;
    private readonly MessageService _Message;
    private readonly IHttpContextAccessor _HttpContextAccessor;
    private readonly Blazored.LocalStorage.ILocalStorageService _SessionStorage;
    private ClaimsPrincipal _CurrentUser = default!;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    /// <param name="auth"></param>
    /// <param name="messageService"></param>
    public JwtAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor, Blazored.LocalStorage.ILocalStorageService _sessionStorage, IAuthService auth, MessageService messageService)
    {
        _Auth = auth;
        _Message = messageService;
        _HttpContextAccessor = httpContextAccessor;
        _SessionStorage = _sessionStorage;
    }


    /// <summary>
    /// 获取授权状态
    /// </summary>
    /// <returns></returns>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        try
        {
            if (_CurrentUser != null)
            {
                return await Task.FromResult(new AuthenticationState(_CurrentUser));
            }

            _CurrentUser = await GetCurrentAuthStateAsync();
            if (_CurrentUser != null && _CurrentUser.Claims.Count() >0)
            {
                identity = new ClaimsIdentity(_CurrentUser.Claims, nameof(JwtAuthenticationStateProvider));
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Request failed:" + ex.ToString());
        }
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    /// <summary>
    /// 获取当前用户状态
    /// </summary>
    /// <returns></returns>
    public async Task<ClaimsPrincipal> GetCurrentAuthStateAsync()
    {
        var identity = _CurrentUser?.Identity ?? new ClaimsIdentity();
        if (!(identity != null && identity.IsAuthenticated))
        {
            var LoginUser = await _SessionStorage.GetItemAsync<SigninToken>(nameof(SigninToken));
            if (LoginUser != null && LoginUser.UserId > 0)
            {
                identity = CreateIdentity(LoginUser);
            }
        }
        _CurrentUser = new ClaimsPrincipal(identity);
        return _CurrentUser;
    }

    /// <summary>
    /// 获取当前用户加签记录
    /// </summary>
    /// <returns></returns>
    public async Task<SigninToken> GetCurrentUserAsync()
    {
        var Claims = await GetCurrentAuthStateAsync();
        var UserSignin = Claims.Identity.IsAuthenticated ? new SigninToken
        {
            UserId = Claims.FindFirstValue(ClaimConst.UserId).Adapt<long>(),
            NickName = Claims.FindFirstValue(ClaimConst.NickName),
            UserName = Claims.FindFirstValue(ClaimConst.Account),
            AccessToken = Claims.FindFirstValue(ClaimConst.AccessToken),
            RefreshToken = Claims.FindFirstValue(ClaimConst.RefreshToken),
            IsSuperAdmin = Claims.FindFirstValue(ClaimConst.IsSuperAdmin) == "true",

        } : null;
        return UserSignin;
    }



    /// <summary>
    /// 登出
    /// </summary>
    /// <returns></returns>
    public async Task<RESTfulResult<bool>> Logout()
    {
        var result = await _Auth.SignOut();
        if (result.Succeeded)
        {
            _CurrentUser = null;
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
            await _SessionStorage.RemoveItemAsync(nameof(SigninToken));
        }
        return result;
    }

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="loginParameters"></param>
    /// <returns></returns>
    public async Task<RESTfulResult<SigninToken>> Login(LoginInput loginParameters)
    {
        var LoginData = await _Auth.SignIn(loginParameters);
        if (LoginData.Succeeded)
        {
            var LoginUser = LoginData.Data;

            var identity = CreateIdentity(LoginUser);

            _CurrentUser = new ClaimsPrincipal(identity);

            var authenticationState = Task.FromResult(new AuthenticationState(_CurrentUser));
            NotifyAuthenticationStateChanged(authenticationState);
            await _SessionStorage.SetItemAsync(nameof(SigninToken), LoginUser);
        }
        return LoginData;
    }



    /// <summary>
    /// 创建用户身份
    /// </summary>
    /// <param name="LoginUser"></param>
    /// <returns></returns>
    private ClaimsIdentity CreateIdentity(SigninToken LoginUser)
    {
        return new ClaimsIdentity(new[]
            {
                      new Claim(ClaimTypes.Sid, LoginUser.UserId.ToString()),
                      new Claim(ClaimTypes.Name, LoginUser.UserName),
                      new Claim(ClaimConst.UserId, LoginUser.UserId.ToString()),
                      new Claim(ClaimConst.Account, LoginUser.UserName),
                      new Claim(ClaimConst.NickName, LoginUser.NickName),
                      new Claim(ClaimConst.UuidKey,DatabaseUtils.GetDataId().ToString()),
                      new Claim(ClaimConst.IsSuperAdmin, LoginUser.IsSuperAdmin ? "true":"false"),
                      new Claim(ClaimConst.AccessToken, LoginUser.AccessToken),
                      new Claim(ClaimConst.RefreshToken, LoginUser.RefreshToken),

                }, nameof(JwtAuthenticationStateProvider));
    }

    /// <summary>
    /// 刷新状态
    /// </summary>
    public async Task RefreshAsync()
    {
        var SigninUser = await GetCurrentUserAsync();
        if (SigninUser != null && SigninUser.UserId > 0)
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }


}
