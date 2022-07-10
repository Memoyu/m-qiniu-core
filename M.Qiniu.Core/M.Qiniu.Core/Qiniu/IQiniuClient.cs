using System.IO;

namespace M.Qiniu.Core
{
    public interface IQiniuClient
    {
        /// <summary>
        /// 获取上传Token
        /// </summary>
        /// <returns></returns>
        string GetUploadToken();

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="path">文件上传路径 例如：xxxx/xxxxx/image.png</param>
        /// <param name="file">文件流</param>
        /// <returns></returns>
        string Upload(string path, Stream file);
    }
}