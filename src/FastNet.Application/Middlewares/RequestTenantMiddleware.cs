using Furion.DataEncryption.Extensions;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Application
{
    /// <summary>
    /// 租户请求中间件
    /// </summary>
    public class RequestTenantMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTenantMiddleware> _logger;
        private readonly ISysTenantRepository _tenantRepository;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public RequestTenantMiddleware(RequestDelegate next
            , ISysTenantRepository tenantRepository
            , ILogger<RequestTenantMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _tenantRepository = tenantRepository;
        }

        /// <summary>
        /// 中间件调用
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var Completed = false;

            //判断Cookie中有无定义的TenantId
            if (context.Request.Cookies.ContainsKey("TenantId"))
            {
                //解密Cookies中的TenantId
                var TenantId = context.Request.Cookies["TenantId"].ToAESDecrypt("abc123def").ParseToLong();
                if(TenantId > 0)
                {
                    //将TenantId装在到上下文对象中
                    context.Items.Set("TenantId", TenantId);
                    Completed = true;
                }
            }

            //Cookie 未取到进入数据库中取
            if (!Completed)
            {
                //** 后期可以在这里把域名和租户缓存起来


                //获取当前域名
                var HostDomian = context.Request.Host.ToString();
                //查找当前域名是否存在某个站点中，否则返回主租户信息
                var TenantItem =  _tenantRepository.GetItemByHost(HostDomian);
                if(TenantItem != null && TenantItem.Id > 0)
                {
                    //将租户编号存放到上下文和Cookies中
                    context.Items.Set("TenantId", TenantItem.Id);
                    context.Response.Cookies.Append("TenantId", $"{TenantItem.Id}".ToAESEncrypt("abc123def"));
                    Completed = true;
                }
            }
 
            // 调用下一个中间件
            await _next(context);
        }

    }
}
