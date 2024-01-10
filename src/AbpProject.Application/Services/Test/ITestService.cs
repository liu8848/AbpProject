using AbpProject.Domain.Entities;
using Volo.Abp.Application.Services;

namespace AbpProject.Application.Services.Test;

public interface ITestService:IApplicationService
{
    Task<List<TestModel>> Get();
    Task<TestModel> Create(TestModel model);
}