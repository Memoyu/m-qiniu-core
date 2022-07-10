using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace M.Qiniu.Core
{
    public class Signature
    {
        private readonly Mac _mac;

        public Signature(Mac mac)
        {
            _mac = mac;
        }

        /// <summary>
        /// 签名-字符串数据
        /// </summary>
        /// <param name="str">待签名的数据</param>
        /// <returns></returns>
        public string SignByUrl(string url)
        {
            byte[] data = Encoding.UTF8.GetBytes(url);
            return SignByUrl(data);
        }

        /// <summary>
        /// 签名-字节数据
        /// </summary>
        /// <param name="data">待签名的数据</param>
        /// <returns></returns>
        public string SignByUrl(byte[] bytes)
        {
            return string.Format("{0}:{1}", _mac.AccessKey, EncodedSign(bytes));
        }

        /// <summary>
        /// 附带数据的签名
        /// </summary>
        /// <param name="str">待签名的数据</param>
        /// <returns>签名结果</returns>
        public string SignByPolicy(PutPolicy policy)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(policy.ToJson());
            return SignByPolicy(bytes);
        }

        /// <summary>
        /// 附带数据的签名
        /// </summary>
        /// <param name="str">待签名的数据</param>
        /// <returns>签名结果</returns>
        public string SignByPolicy(byte[] bytes)
        {
            string policyBase64 = Base64.UrlSafeBase64Encode(bytes);
            return string.Format("{0}:{1}:{2}", _mac.AccessKey, EncodedSign(policyBase64), policyBase64);
        }

        #region Private

        private string EncodedSign(string policyBase64)
        {
            byte[] data = Encoding.UTF8.GetBytes(policyBase64);
            return EncodedSign(data);
        }

        private string EncodedSign(byte[] bytes)
        {
            using (HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(_mac.SecretKey)))
            {
                byte[] digest = hmac.ComputeHash(bytes);
                return Base64.UrlSafeBase64Encode(digest);
            };
        }

        #endregion
    }
}
