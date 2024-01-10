using Volo.Abp.Application.Services;

namespace AbpProject.Application.Services.Hello;

public interface IHelloService:IApplicationService
{
    Task<string> Get();
}