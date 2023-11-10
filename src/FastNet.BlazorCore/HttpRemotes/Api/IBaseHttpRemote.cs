using Furion.RemoteRequest;
namespace FastNet.BlazorCore;


/// <summary>
/// WEB API 远程请求接口封装
/// </summary>
public interface IBaseHttpRemote : IHttpDispatchProxy
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Get("/get")]
    Task<HttpResponseMessage> GetAsync();




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

        //设置授权
        //req.Headers.TryAddWithoutValidation("Authorization", "Bearer 你的token");

        //转发当前域名到API中
        req.Headers.TryAddWithoutValidation("x-domain", httpContextAccessor.HttpContext.Request.Host.ToString().ToLower());

        //转发当前IP到API中
        req.Headers.TryAddWithoutValidation("x-ip-v4", httpContextAccessor.HttpContext.GetRemoteIpAddressToIPv4());
        req.Headers.TryAddWithoutValidation("x-ip-v6", httpContextAccessor.HttpContext.GetRemoteIpAddressToIPv6());
    }

}
