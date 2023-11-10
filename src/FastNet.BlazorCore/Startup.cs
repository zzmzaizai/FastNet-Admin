
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;
using FastNet.BlazorCore.Services;

namespace FastNet.BlazorCore;

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

        services.AddConsoleFormatter();
        services.AddRazorPages().AddInjectBase();
        services.AddServerSideBlazor();

        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddAntDesign();
        services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri(sp.GetService<NavigationManager>()!.BaseUri)
        });
        services.AddRemoteRequest(options =>
        {
            // 配置 Base Web Api 基本信息
            options.AddHttpClient("system", c =>
            {
                c.BaseAddress = new Uri("https://localhost:5001");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        });

        services.Configure<ProSettings>(App.Configuration.GetSection("ProSettings"));
        services.AddScoped<IChartService, ChartService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IProfileService, ProfileService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseInjectBase();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}