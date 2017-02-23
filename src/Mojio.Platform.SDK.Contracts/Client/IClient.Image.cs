#region copyright
/******************************************************************************
* Moj.io Inc. CONFIDENTIAL
* 2017 Copyright Moj.io Inc.
* All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains, the property of 
* Moj.io Inc. and its suppliers, if any.  The intellectual and technical 
* concepts contained herein are proprietary to Moj.io Inc. and its suppliers
* and may be covered by Patents, pending patents, and are protected by trade
* secret or copyright law.
*
* Dissemination of this information or reproduction of this material is strictly
* forbidden unless prior written permission is obtained from Moj.io Inc.
*******************************************************************************/
#endregion

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