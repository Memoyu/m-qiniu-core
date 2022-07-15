using M.Qiniu.Core;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependInjectionExtensions
    {
        public static IServiceCollection AddQiniuClient(this IServiceCollection services, IConfiguration configuration, string sectionName = "FileStorage:Qiniu")
        {
            if (services == null) throw new ArgumentNullException($"{nameof(services)} is not null");
            services.Configure<QiniuClientOption>(configuration.GetSection(sectionName));
            return services.AddSingleton<IQiniuClient, QiniuClient>();
        }

        public static IServiceCollection AddQiniuClient(this IServiceCollection services, Action<QiniuClientOption> option)
        {
            if (services == null) throw new ArgumentNullException($"{nameof(services)} is not null");
            services.Configure(option);
            return services.AddSingleton<IQiniuClient, QiniuClient>();
        }
    }
}

