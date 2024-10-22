﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;

namespace FastNet.WebAPI;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers()
                .AddInjectWithUnifyResult();

        services.AddFastNetMemoryCache();

        services.AddConsoleFormatter();
        services.AddJwt<JwtHandler>(enableGlobalAuthorize: false, jwtBearerConfigure: options =>
        {
            options.Events = new JwtBearerEvents()
            {
                OnMessageReceived = context =>
                {
                    if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                    {
                        //读取cookie中的token
                        string token = context.HttpContext.Request.Cookies["access-token"]?.Trim('"');
                        if (!string.IsNullOrWhiteSpace(token))
                        {
                            context.Token = token;
                        }
                    }

                    return Task.CompletedTask;
                }
            };
        });

        services.AddCorsAccessor();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCorsAccessor();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseInject(string.Empty);

        app.UseMiddlewares();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
