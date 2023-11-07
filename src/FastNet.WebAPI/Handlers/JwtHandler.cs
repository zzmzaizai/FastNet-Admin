using Furion.Authorization;


namespace FastNet.WebAPI;

/// <summary>
/// Jwt 处理程序
/// </summary>
public class JwtHandler : AppAuthorizeHandler
{
    /// <summary>
    /// 请求管道
    /// </summary>
    /// <param name="context"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public override Task<bool> PipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
    {
        string code = httpContext.Request.Path.Value!.Replace("/api/", "").Replace("/", ":");
        var sysMenuService = App.GetService<MenuService>(httpContext.RequestServices);
        //判断访问权限
        return sysMenuService.CheckPermission(code);
        
    }


    /// <summary>
    /// 自动刷新token
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task HandleAsync(AuthorizationHandlerContext context)
    {
        // 自动刷新 token
        if (JWTEncryption.AutoRefreshToken(context, context.GetCurrentHttpContext()))
        {
            await AuthorizeHandleAsync(context);
        }
        else
        {
            context.Fail();    // 授权失败
            DefaultHttpContext currentHttpContext = context.GetCurrentHttpContext();
            currentHttpContext?.SignoutToSwagger();
        }
    }

}
