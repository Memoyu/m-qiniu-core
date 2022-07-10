using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net.Http;

namespace M.Qiniu.Core
{
    public class QiniuClient : IQiniuClient
    {
        private readonly IHttpClientFactory _factory;

        private readonly QiniuClientOption _option;

        private readonly Signature _sign;

        public QiniuClient(IHttpClientFactory factory, IOptionsMonitor<QiniuClientOption> option)
        {
            _factory = factory;
            _option = option.CurrentValue;
            _sign = new Signature(new Mac(_option.AK, _option.SK));
        }

        public string GetUploadToken()
        {
            var policy = new PutPolicy
            {
                Scope = _option.Bucket
            };
            return _sign.SignByPolicy(policy);

        }

        public string Upload(string path, Stream file)
        {
            throw new NotImplementedException();
        }
    }
}