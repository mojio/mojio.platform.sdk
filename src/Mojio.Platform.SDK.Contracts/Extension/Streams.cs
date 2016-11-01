using System.IO;

namespace Mojio.Platform.SDK.Contracts.Extension
{
    public static class Streams
    {
        public static byte[] ReadToEnd(this Stream input)
        {
            using (var ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}