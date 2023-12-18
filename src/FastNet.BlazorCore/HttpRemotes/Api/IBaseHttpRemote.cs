using Furion.RemoteRequest;
using System.Net.Http.Headers;
using System.Net.Http;
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
    /// 请求成功拦截
    /// </summary>
    /// <param name="client"></param>
    /// <param name="res"></param>
    [Interceptor(InterceptorTypes.Response)]
    static void OnResponsing2(HttpClient client, HttpResponseMessage res)
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


       

        //设置授权
        //req.Headers.TryAddWithoutValidation("Authorization", "Bearer 你的token");
        //req.Headers.TryAddWithoutValidation("X-Authorization", "Bearer 你的刷新token");

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
    static void OnException1(HttpClient client, HttpResponseMessage res, string errors)
    {
        
    }


}
