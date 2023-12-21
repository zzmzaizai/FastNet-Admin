
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;
using FastNet.BlazorCore.Services;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Blazored.LocalStorage;

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
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddAntDesign();
        services.AddBlazoredLocalStorage();

        // Authorization
        services.AddAuthorizationCore();
        services.AddScoped<JwtAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<JwtAuthenticationStateProvider>());


        services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri(sp.GetService<NavigationManager>()!.BaseUri)
        });
        services.AddRemoteRequest(options =>
        {
            // 配置 System Web Api 基本信息
            options.AddHttpClient("system", c =>
            {
                c.BaseAddress = new Uri("http://webapi.dnntest.com/");
                c.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            });
        });




        services.Configure<ProSettings>(App.Configuration.GetSection("ProSettings"));



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

    

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}