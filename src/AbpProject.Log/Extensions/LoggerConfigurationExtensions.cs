using Serilog;

namespace AbpProject.Log.Extensions;

public static class LoggerConfigurationExtensions
{
    public static LoggerConfiguration WriteToConsole(this LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration = loggerConfiguration.WriteTo.Console(
            outputTemplate:
            "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
        );

        return loggerConfiguration;
    }
}