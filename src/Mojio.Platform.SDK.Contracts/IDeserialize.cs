using System;
using System.IO;

namespace Mojio.Platform.SDK.Contracts
{
    public interface IDeserialize
    {
        string ContentType { get; }

        T Deserialize<T>(Stream stream);

        T Deserialize<T>(byte[] input);

        object Deserialize(byte[] input);

        T Deserialize<T>(string input);

        object Deserialize(string input, Type serviceType);

        object Deserialize(string input);
    }
}