using System.IO;
using System.Text;

namespace AzureNaPratica.Serverless.Util
{
    public static class StreamString
    {
        public static Stream ConvertStringToStream(this string value)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(value);
            return new MemoryStream(byteArray);
        }
    }
}
