using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Newtonsoft.Json.Serialization;
using IContractResolver = Newtonsoft.Json.Serialization.IContractResolver;

namespace Mojio.Platform.SDK.Entities
{
    public class ContractResolver : DefaultContractResolver, IContractResolver
    {
        private readonly IDIContainer _container;

        public ContractResolver(IDIContainer container)
        {
            _container = container;
        }

        public override JsonContract ResolveContract(Type type)
        {
            if (type.GetTypeInfo().IsInterface)
            {
                try
                {
                    var t = _container.Resolve(type);
                    if (t == null) throw new NotImplementedException(type.FullName);
                    var i = t.GetType();
                    return base.ResolveContract(i);
                }
                catch (Exception)
                {
                    //somethig went wrong, lets let the bsae resolver give it a try...
                }
            }
            return base.ResolveContract(type);
        }
    }
}
