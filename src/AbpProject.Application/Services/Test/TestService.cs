using AbpProject.Domain.Entities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpProject.Application.Services.Test;

public class TestService:ApplicationService,ITestService
{
    private readonly IRepository<TestModel, int> _repository;

    public TestService(IRepository<TestModel, int> repository)
    {
        _repository = repository;
    }

    public async Task<List<TestModel>> Get()
    {
        return await _repository.GetListAsync();
    }

    public async Task<TestModel> Create(TestModel model)
    {
        return await _repository.InsertAsync(model);
    }
}