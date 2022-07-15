using System;
using Xunit;

namespace M.Qiniu.Test
{
    public class QiniuClientTest
    {
        [Fact]
        public void CreateUploadTokenTest()
        {
            var client = new QiniuClient(new QiniuClientOption
            {
                AK = "MYPwfsUNNEsTXUGwO6LlOCGutAd2t7ljTg0maJL4V2",
                SK = "YFDLnpSPyyQeNy_rVOANLj5ND9_3pFGs-XNPANdl23",
                Bucket = "mbill",
                Host = "https://oss.memoyu.com/",
                UseHttps = true
            });

            var token = client.CreateUploadToken();
        }
    }
}
