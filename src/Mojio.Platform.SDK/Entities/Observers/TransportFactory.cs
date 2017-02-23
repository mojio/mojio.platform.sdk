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

using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class TransportFactory : ITransportFactory
    {
        private readonly IDeserialize _serializer;
        private readonly IDIContainer _container;

        public TransportFactory(IDeserialize serializer, IDIContainer container)
        {
            _serializer = serializer;
            _container = container;
        }

        public ITransport GetTransport(TransportTypes type)
        {
            return _container.Resolve<ITransport>(type.ToString());
        }

        public ITransport GetTransport(string json)
        {
            var baseTransport = _serializer.Deserialize<ITransport>(json);
            var type = _container.Resolve<ITransport>(baseTransport.TransportType.ToString());

            return _serializer.Deserialize(json, type.GetType()) as ITransport;
        }
    }
}
