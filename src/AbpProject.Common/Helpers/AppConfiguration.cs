using Microsoft.Extensions.Configuration;

namespace AbpProject.Common.Helpers;

public static class AppConfiguration
{
    public static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AbpProject.Web.Api"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}