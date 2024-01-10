using AbpProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EntityFrameworkCore.EntityFrameworkCore;

// [ConnectionStringName("Default")]
public class AbpProjectDbContext:AbpDbContext<AbpProjectDbContext>
{
    
    public DbSet<TestModel> TestModels { get; set; }
    
    public AbpProjectDbContext(DbContextOptions<AbpProjectDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestModel>();
    }
}