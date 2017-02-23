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

using System;

namespace Mojio.Platform.SDK.Contracts.Push
{

    public enum IdentifierType
    {
        Default,
        Id,
        Guid
    }

    public interface ITransport
    {
        string Key { get; set; }

        TransportTypes TransportType { get; }

        string Type { get; }

    }

    public interface IAndroidTransport : ITransport
    {
        string DeviceRegistrationId { get; set; }
    }

    public interface IAppleTransport : ITransport
    {
        string DeviceToken { get; set; }
        string AlertBody { get; set; }
        string AlertSound { get; set; }
        string AlertCategory { get; set; }
        int Badge { get; set; }
        Guid AppId { get; set; }
    }

    public interface IHttpPostTransport : ITransport
    {
        string Address { get; set; }

        string UserName { get; set; }
        string Password { get; set; }
    }

    public interface IMongoDBTransport : ITransport
    {
        string ConnectionString { get; set; }

        string CollectionName { get; set; }
        IdentifierType Identifier { get; set; }

    }

    public interface IEventHubTransport : ITransport
    {
        string ConnectionString { get; set; }

        string Path { get; set; }

    }

    public interface IServiceBusQueueTransport : ITransport
    {
        string ConnectionString { get; set; }

        string Path { get; set; }

    }

    public interface IMqttTransport : ITransport
    {

        string HostName { get; set; }
        int? Port { get; set; }

        string ClientId { get; set; }

        string Topic { get; set; }

        string UserName { get; set; }

        string Password { get; set; }

    }

    public interface ISignalRTransport : ITransport
    {
        string ClientId { get; set; }
        string HubName { get; set; }
        string Callback { get; set; }

    }

}
