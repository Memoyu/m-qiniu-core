using M.Qiniu.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Memoyu.Qiniu.Test
{
    public class QiniuClientInjectionTest
    {

        [Fact]
        public void InjectionBySectionNameTest()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true);
            IServiceCollection services = new ServiceCollection();
            IConfiguration configuration = builder.Build();
            services.AddQiniuClient(configuration, "FileStorage:Qiniu");

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var client = serviceProvider.GetService<IQiniuClient>();
            Assert.NotNull(client);
            var token = client.CreateUploadToken();
        }
    }
}