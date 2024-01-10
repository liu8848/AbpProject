using AbpProject.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCore.EntityFrameworkCore;

public class AbpProjectDbContextFactory:IDesignTimeDbContextFactory<AbpProjectDbContext>
{
    public AbpProjectDbContext CreateDbContext(string[] args)
    {
        var configuration = AppSettings.Configuration;
        var connectionString = configuration.GetConnectionString("Default");

        // var builder = new DbContextOptionsBuilder<AbpProjectDbContext>()
        //     .UseMySql("Server=localhost;Port=3306;Database=AbpProject;Uid=root;Pwd=sudalu929;", 
        //         MySqlServerVersion.LatestSupportedServerVersion);
        
        var builder = new DbContextOptionsBuilder<AbpProjectDbContext>()
            .UseMySql(connectionString, 
                MySqlServerVersion.LatestSupportedServerVersion);
        return new AbpProjectDbContext(builder.Options);
    }
}