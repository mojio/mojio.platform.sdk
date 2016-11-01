using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts
{
    public interface IRegister
    {
        void Register(Type serviceType, Type implementationType, string serviceName = null);

        void Register<I, T>(string name = null) where T : I;

        void RegisterInstance<T>(T instance, string serviceName = null);
    }

    public interface IUnregister
    {
        void Unregister(Type serviceType, string name = null);

        void Unregister<T>(string name = null);
    }

    public interface IResolve
    {
        T Resolve<T>(string serviceName = null);

        object Resolve(Type type);

        IEnumerable<T> ResolveAllInstances<T>();
    }

    public interface IDIContainer : IResolve, IRegister, IUnregister
    {
    }
}