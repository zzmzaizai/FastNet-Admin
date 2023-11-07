using Microsoft.Extensions.Logging;

namespace FastNet.WebAPI;

/// <summary>
/// 全局异常处理中间件
/// </summary>
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public GlobalExceptionMiddleware(RequestDelegate next
        , ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;

    }



    /// <summary>
    /// 中间件调用
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context)
    {
        // 调用下一个中间件
        await _next(context);
    }
}
