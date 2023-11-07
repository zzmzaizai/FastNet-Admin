using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FastNet.WebAPI;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddConsoleFormatter();
        services.AddJwt<JwtHandler>(enableGlobalAuthorize: true, jwtBearerConfigure: options =>
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

        services.AddControllers()
                .AddInjectWithUnifyResult();
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
