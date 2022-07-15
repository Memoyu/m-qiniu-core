using System;
using System.IO;

namespace M.Qiniu
{
    public class QiniuClient : IQiniuClient
    {
        private readonly QiniuClientOption _option;

        private readonly Signature _sign;

        public QiniuClient(QiniuClientOption option)
        {
            _option = option;
            _sign = new Signature(new Mac(_option.AK, _option.SK));
        }

        public string CreateUploadToken()
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
