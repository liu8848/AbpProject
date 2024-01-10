using AbpProject.Common.Log;
using Serilog;

namespace AbpProject.Web.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.ConfigureLog();
        
        builder.Host
            .UseAutofac();
        
        builder.AddApplicationAsync<AbpProjectWebApiModule>();

        var app = builder.Build();
        
        app.InitializeApplication();
        

        app.UseHttpsRedirection();
        

        app.Run();
    }
}