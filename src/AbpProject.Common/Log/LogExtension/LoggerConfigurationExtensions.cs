using AbpProject.Common.Helpers.LogHelpers;
using Serilog;
using Serilog.Context;
using Serilog.Events;
using Serilog.Filters;

namespace AbpProject.Common.Log.LogExtension;

public static class LoggerConfigurationExtensions
{
    public static LoggerConfiguration WriteToConsole(this LoggerConfiguration loggerConfiguration)
    {
        //输出普通日志
        loggerConfiguration.WriteTo.Logger(lg =>
             lg.FilterRemoveSqlLog().WriteTo.Console(
                 outputTemplate:LogContextStatic.FileMessageTemplate));
        //输出SQL
        // loggerConfiguration.WriteTo.Logger(lg =>
        // {
        //     lg.FilterSqlLog()
        //         .Filter.ByIncludingOnly(Matching
        //             .WithProperty<bool>(LogContextStatic.SqlOutToConsole, s => s))
        //         .WriteTo.Console();
        // });
        return loggerConfiguration;
    }

    public static LoggerConfiguration FilterRemoveSqlLog(this LoggerConfiguration lc)
    {
        // lc = lc.Filter
        //     .ByIncludingOnly(WithProperty<string>(LogContextStatic.LogSource, s => !LogContextStatic.AopSql.Equals(s)));

        lc = lc.Filter.ByExcluding(Matching.FromSource("Microsoft.EntityFrameworkCore.Database.Command"));
        return lc;
    }

    public static Func<LogEvent, bool> WithProperty<T>(string propertyName, Func<T, bool> predicate)
    {
        return e =>
        {
            if (!e.Properties.TryGetValue(propertyName, out var propertyValue)) return true;

            return propertyValue is ScalarValue { Value: T value } && predicate(value);
        };
    }

    public static LoggerConfiguration FilterSqlLog(this LoggerConfiguration lc)
    {
        lc = lc.Filter
            .ByIncludingOnly(Matching
                .WithProperty<string>(LogContextStatic.LogSource,
                    s => LogContextStatic.AopSql.Equals(s)));
        return lc;
    }
}