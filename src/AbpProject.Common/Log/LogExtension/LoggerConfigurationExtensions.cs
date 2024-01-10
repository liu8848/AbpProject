using Serilog;
using Serilog.Context;
using Serilog.Events;

namespace AbpProject.Common.Log.LogExtension;

public static class LoggerConfigurationExtensions
{
    public static LoggerConfiguration WriteToConsole(this LoggerConfiguration loggerConfiguration)
    {
        //输出普通日志
        // loggerConfiguration = loggerConfiguration.WriteTo.Logger(lg =>
        //     lg.FilterRemoveSqlLog().WriteTo.Console());
        
        return loggerConfiguration;
    }

    // public static LoggerConfiguration FilterRemoveSqlLog(this LoggerConfiguration lc)
    // {
    //     lc = lc.Filter.ByIncludingOnly(WithProperty<string>(LogContextStatic.LogSource, s => !LogContextStatic.AopSql.Equals(s)));
    //     return lc;
    // }

    public static Func<LogEvent, bool> WithProperty<T>(string propertyName, Func<T, bool> predicate)
    {
        return e =>
        {
            if (!e.Properties.TryGetValue(propertyName, out var propertyValue)) return true;

            return propertyValue is ScalarValue { Value: T value } && predicate(value);
        };
    }
}