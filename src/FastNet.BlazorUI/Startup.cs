﻿
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FastNet.BlazorUI;

/// <summary>
/// AppStartup启动类
/// </summary>
public class Startup : AppStartup
{
    /// <summary>
    /// ConfigureServices中不能解析服务，比如App.GetService()，尤其是不能在ConfigureServices中获取诸如缓存等数据进行初始化，应该在Configure中进行
    /// 服务都还没初始化完成，会导致内存中存在多份 IOC 容器！！
    /// 正确应该在 Configure 中，这个时候服务（IServiceCollection 已经完成 BuildServiceProvider() 操作了
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            // 处理未处理的异常
            Exception exception = (Exception)args.ExceptionObject;
            
        };

        TaskScheduler.UnobservedTaskException += (sender, args) =>
        {
            // 处理未观察的任务异常
            Exception exception = args.Exception;

        };

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
     
    }
}