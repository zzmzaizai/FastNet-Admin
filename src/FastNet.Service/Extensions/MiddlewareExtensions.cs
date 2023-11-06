using Microsoft.AspNetCore.Builder;


namespace FastNet.Service
{
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// 注册所需要的中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder builder)
        {
            // 异常处理中间件
            builder.UseMiddleware<GlobalExceptionMiddleware>();
            // 租户逻辑处理中间件
            builder.UseMiddleware<RequestTenantMiddleware>();
            return builder;
        }

    }
}
