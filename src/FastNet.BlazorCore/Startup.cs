﻿
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
    /// 
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddConsoleFormatter();
        services.AddRazorPages().AddInjectBase();
        services.AddServerSideBlazor();

        services.AddInjectMini();

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
        //services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IProfileService, ProfileService>();
    }

    /// <summary>
    /// 
    /// </summary>
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