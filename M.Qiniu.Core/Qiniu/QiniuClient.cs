using Microsoft.Extensions.Options;
using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.IO;
using System.Net.Http;

namespace M.Qiniu.Core
{
    public class QiniuClient : IQiniuClient
    {
        private readonly QiniuClientOption _option;

        private readonly Signature _sign;

        public QiniuClient(IOptionsMonitor<QiniuClientOption> option)
        {
            _option = option.CurrentValue;
            _sign = new Signature(new Mac(_option.AK, _option.SK));
        }

        public string CreateUploadToken()
        {
            var policy = new PutPolicy
            {
                Scope = _option.Bucket
            };
            return _sign.SignWithData(policy.ToJsonString());

        }

        public string UploadStream(string path, Stream file)
        {
            throw new NotImplementedException();
        }
    }
}