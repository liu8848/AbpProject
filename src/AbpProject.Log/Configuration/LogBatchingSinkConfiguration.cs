using AbpProject.Common.Helpers;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace AbpProject.Log.Configuration;

public static class LogBatchingSinkConfiguration
{
    public static LoggerConfiguration WriteToLogBatching(this LoggerConfiguration loggerConfiguration)
    {
        return loggerConfiguration;
    }
}