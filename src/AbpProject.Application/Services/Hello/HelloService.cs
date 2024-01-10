using Volo.Abp.Application.Services;

namespace AbpProject.Application.Services.Hello;

public class HelloService:ApplicationService,IHelloService
{
    public async Task<string> Get()
    {
        return await Task.FromResult("hello");
    }
}