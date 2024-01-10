using AbpProject.Common.Log.LogExtension;
using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Core;

namespace AbpProject.Common.Log;

public static class LogConfigureProvider
{
    public static void ConfigureLog(this WebApplicationBuilder builder)
    {
        Serilog.Log.Logger = new LoggerConfiguration()
            .WriteToConsole()
            .CreateLogger();
        
        builder.Host.UseSerilog();
    }
}