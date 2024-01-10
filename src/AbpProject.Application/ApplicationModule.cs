using AbpProject.Domain;
using EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpProject.Application;

[DependsOn(
    typeof(DomainModule),
    typeof(EntityFrameworkCoreModule)
    )]
public class ApplicationModule:AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
    }
}