using Microsoft.AspNetCore.Builder;


namespace FastNet.Web.Core
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
            return builder.UseMiddleware<RequestTenantMiddleware>();
        }

    }
}
