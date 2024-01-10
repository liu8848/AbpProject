using AbpProject.Log.Configuration;
using AbpProject.Log.Extensions;
using Serilog;
using Volo.Abp.Modularity;

namespace AbpProject.Log;

public class AbpProjectLogModule:AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddSerilog(option =>
        {
            option.WriteToLogBatching();
            option.WriteToConsole();
        });
    }
}