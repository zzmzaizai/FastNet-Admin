
namespace FastNet.BlazorCore;


/// <summary>
/// API资源服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpApiResourceService : IBaseHttpRemote
{
    /// <summary>
    /// 测试
    /// </summary>
    /// <returns></returns>
    [Get("/get")]
    Task<HttpResponseMessage> GetTestAsync();


     

}
