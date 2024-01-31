
using FastNet.BlazorCore.Services;
namespace FastNet.BlazorCore;


/// <summary>
/// WEB API 远程请求接口封装
/// </summary>
[RetryPolicy(3, 1000)]
public interface IBaseHttpRemote : IHttpDispatchProxy
{



    /// <summary>
    /// 请求成功拦截
    /// </summary>
    /// <param name="client"></param>
    /// <param name="res"></param>
    [Interceptor(InterceptorTypes.Response)]
    static void OnResponsing(HttpClient client, HttpResponseMessage res)
    {

    }


    /// <summary>
    /// 请求时的拦截
    /// 1.授权
    /// 2.转发域名
    /// 3.转发IP
    /// </summary>
    /// <param name="client"></param>
    /// <param name="req"></param>
    [Interceptor(InterceptorTypes.Request)]
    static void OnRequest(HttpClient client, HttpRequestMessage req)
    {
        var httpContextAccessor = App.GetService<IHttpContextAccessor>();


        //当前登录用户授权到API
        if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            var JwtAuth = App.GetService<JwtAuthenticationStateProvider>();
            var UserAuth = JwtAuth.GetCurrentUserAsync().Result;

            if (UserAuth != null && UserAuth.UserId > 0)
            {
                //设置授权
                req.Headers.TryAddWithoutValidation("Authorization", $"Bearer {UserAuth.AccessToken}");
                req.Headers.TryAddWithoutValidation("X-Authorization", $"Bearer {UserAuth.RefreshToken}");
            }
        }

        //转发当前域名到API中
        req.Headers.TryAddWithoutValidation("x-domain", httpContextAccessor.HttpContext.Request.Host.ToString().ToLower());

        //转发当前IP到API中
        req.Headers.TryAddWithoutValidation("x-ip-v4", httpContextAccessor.HttpContext.GetRemoteIpAddressToIPv4());
        req.Headers.TryAddWithoutValidation("x-ip-v6", httpContextAccessor.HttpContext.GetRemoteIpAddressToIPv6());
    }



    /// <summary>
    /// 全局请求异常拦截
    /// </summary>
    /// <param name="client"></param>
    /// <param name="res"></param>
    /// <param name="errors"></param>
    [Interceptor(InterceptorTypes.Exception)]
    static void OnException(HttpClient client, HttpResponseMessage res, string errors)
    {

    }


}
