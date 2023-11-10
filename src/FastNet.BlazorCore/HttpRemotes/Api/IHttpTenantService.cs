﻿
namespace FastNet.BlazorCore;


/// <summary>
/// 租户服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpTenantService : IBaseHttpRemote
{
    /// <summary>
    /// 测试
    /// </summary>
    /// <returns></returns>
    [Get("/get")]
    Task<HttpResponseMessage> GetTestAsync();


     

}