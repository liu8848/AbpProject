using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace AbpProject.Common.Helpers;

public class AppSettings
{
    public static IConfiguration Configuration { get; set; }
    private static string contentPath { get; set; }

    public AppSettings(string contentPath)
    {
        string Path = "appsettings.json";

        Configuration = new ConfigurationBuilder()
            .SetBasePath(contentPath)
            .Add(new JsonConfigurationSource
            {
                Path = Path, Optional = false, ReloadOnChange = true
            })
            .Build();
    }

    public AppSettings(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    /// <summary>
    /// 封装要操作的字符
    /// </summary>
    /// <param name="sections">节点配置</param>
    /// <returns></returns>
    public static string app(params string[] sections)
    {
        try
        {
            if (sections.Any())
            {
                return Configuration[string.Join(":", sections)];
            }
        }
        catch (Exception)
        {
        }

        return "";
    }

    /// <summary>
    /// 递归获取配置信息数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sections"></param>
    /// <returns></returns>
    public static List<T> app<T>(params string[] sections)
    {
        List<T> list = new List<T>();
        // 引用 Microsoft.Extensions.Configuration.Binder 包
        Configuration.Bind(string.Join(":", sections), list);
        return list;
    }


    /// <summary>
    /// 根据路径  configuration["App:Name"];
    /// </summary>
    /// <param name="sectionsPath"></param>
    /// <returns></returns>
    public static string GetValue(string sectionsPath)
    {
        try
        {
            return Configuration[sectionsPath];
        }
        catch (Exception)
        {
        }

        return "";
    }
}