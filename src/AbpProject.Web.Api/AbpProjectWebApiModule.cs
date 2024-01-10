using AbpProject.Application;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.UI.Navigation.Urls;

namespace AbpProject.Web.Api;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule),
    typeof(ApplicationModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAspNetCoreSerilogModule)
    )]
public class AbpProjectWebApiModule:AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var webHostEnvironment = context.Services.GetHostingEnvironment();
        
        ConfigureConventionalController();
        ConfigureSwaggerServices(context,configuration);
        
        Configure<AntiforgeryOptions>(option =>
        {
            option.Cookie.SameSite = SameSiteMode.None;
            option.Cookie.HttpOnly = true;
            option.Cookie.IsEssential = true;
            option.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            option.Cookie.Expiration=TimeSpan.FromDays(3650);
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // app.UseStaticFiles();
        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "BYDPlatform API");
        });
        app.UseConfiguredEndpoints();
    }

    /// <summary>
    /// 配置URL
    /// </summary>
    /// <param name="configuration"></param>
    private void ConfigureUrls(IConfiguration configuration)
    {
        Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            options.RedirectAllowedUrls.AddRange(configuration["App:RedirectAllowedUrls"]?.Split(',') ?? Array.Empty<string>());

            options.Applications["Angular"].RootUrl = configuration["App:ClientUrl"];
        });
    }
    
    /// <summary>
    /// 配置传统控制器
    /// </summary>
    private void ConfigureConventionalController()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options
                .ConventionalControllers
                .Create(typeof(ApplicationModule).Assembly);
        });
    }
    
    /// <summary>
    /// Swagger配置
    /// </summary>
    /// <param name="context"></param>
    /// <param name="configuration"></param>
    private static void ConfigureSwaggerServices(ServiceConfigurationContext context,
        IConfiguration configuration)
    {
        context.Services.AddAbpSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1",new OpenApiInfo{Title="BYDPlatform API",Version="v1"});
                options.DocInclusionPredicate((docName,description)=>true);
                options.CustomSchemaIds(type=>type.FullName);
            }
        );
    }
}