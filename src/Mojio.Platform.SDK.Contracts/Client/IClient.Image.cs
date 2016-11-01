using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Client
{
    public enum ImageEntities
    {
        Apps,
        Users,
        Vehicles
    }

    public interface IClientImage
    {

        Task<IPlatformResponse<IMessageResponse>> SaveImage(ImageEntities entityType, Guid id, byte[] image, string fileName, string contentType, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
        Task<IPlatformResponse<IMessageResponse>> DeleteImage(ImageEntities entityType, Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
        Task<IPlatformResponse<IImage>> GetImage(ImageEntities entityType, Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null);
        
        Task<byte[]> DownloadImage(IImage image, ImageType type = ImageType.Thumbnail);

        
    }
}