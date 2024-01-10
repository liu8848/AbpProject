using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace AbpProject.Domain
{

    [DependsOn(typeof(AbpDddDomainModule))]
    public class DomainModule : AbpModule
    {

    }
}