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
using Mojio.Platform.SDK.DryIoc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Mojio.Platform.SDK.Entities.DI
{
    public class DIContainer : IDIContainer
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);
        private static IDIContainer _current;
        private static readonly Container _dryContainer = new Container(Configure);

        public DIContainer()
        {
            _dryContainer.RegisterInstance(this as IDIContainer);
            _dryContainer.RegisterInstance(this as IResolve);
            _dryContainer.RegisterInstance(this as IRegister);
            _dryContainer.RegisterInstance(CancellationTokenSource);
            _dryContainer.RegisterInstance(CancellationToken);
        }

        private static CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
        private static CancellationToken CancellationToken { get; } = CancellationTokenSource.Token;

        public static IDIContainer Current
        {
            get
            {
                if (_current != null) return _current;
                semaphore.Wait();
                _current = new DIContainer();

                var coreServices = new CoreServicesRegistrationContainer();
                coreServices.Register(_current);

                semaphore.Release();

                return _current;
            }
        }

        [DebuggerStepThrough]
        public T Resolve<T>(string serviceName = null)
        {
            if (string.IsNullOrEmpty(serviceName))
            {
                return _dryContainer.Resolve<T>();
            }
            return _dryContainer.Resolve<T>(serviceName);
        }

        [DebuggerStepThrough]
        public IEnumerable<T> ResolveAllInstances<T>()
        {
            var serviceTypeEnumerable = typeof(IEnumerable<>).MakeGenericType(typeof(T));

            var obj = _dryContainer.Resolve(serviceTypeEnumerable, IfUnresolved.ReturnDefault);
            return (IEnumerable<T>)obj;
        }

        [DebuggerStepThrough]
        public void Register(Type serviceType, Type implementationType, string serviceName = null)
        {
            if (string.IsNullOrEmpty(serviceName))
            {
                _dryContainer.Register(serviceType, implementationType, Reuse.Transient, Made.Of(FactoryMethod.ConstructorWithResolvableArguments), ifAlreadyRegistered: IfAlreadyRegistered.Replace);
            }
            else
            {
                _dryContainer.Register(serviceType, implementationType, Reuse.Transient, Made.Of(FactoryMethod.ConstructorWithResolvableArguments), serviceKey: serviceName, ifAlreadyRegistered: IfAlreadyRegistered.Replace);
            }
        }

        [DebuggerStepThrough]
        public void RegisterInstance<T>(T instance, string serviceName = null)
        {
            if (!string.IsNullOrEmpty(serviceName))
            {
                _dryContainer.RegisterInstance(instance, serviceKey: serviceName, ifAlreadyRegistered: IfAlreadyRegistered.Replace);
            }
            else
            {
                _dryContainer.RegisterInstance(instance, ifAlreadyRegistered: IfAlreadyRegistered.Replace);
            }
        }

        [DebuggerStepThrough]
        public void Register<I, T>(string name = null) where T : I
        {
            if (string.IsNullOrEmpty(name))
            {
                _dryContainer.Register<I, T>(Reuse.Transient, Made.Of(FactoryMethod.ConstructorWithResolvableArguments), ifAlreadyRegistered: IfAlreadyRegistered.Replace);
            }
            else
            {
                _dryContainer.Register<I, T>(Reuse.Transient, Made.Of(FactoryMethod.ConstructorWithResolvableArguments), serviceKey: name, ifAlreadyRegistered: IfAlreadyRegistered.Replace);
            }
        }

        [DebuggerStepThrough]
        public void RegisterSingleton<I, T>(string name = null) where T : I
        {
            if (string.IsNullOrEmpty(name))
            {
                _dryContainer.Register<I, T>(Reuse.Singleton, Made.Of(FactoryMethod.ConstructorWithResolvableArguments), ifAlreadyRegistered: IfAlreadyRegistered.Replace);
            }
            else
            {
                _dryContainer.Register<I, T>(Reuse.Singleton, Made.Of(FactoryMethod.ConstructorWithResolvableArguments), serviceKey: name, ifAlreadyRegistered: IfAlreadyRegistered.Replace);
            }
        }

        [DebuggerStepThrough]
        public object Resolve(Type type)
        {
            return _dryContainer.Resolve(type, IfUnresolved.ReturnDefault);
        }

        private static Rules Configure(Rules rules)
        {
            rules = rules.With(FactoryMethod.ConstructorWithResolvableArguments);

            // Don't throw exception while registering IDisposable
            rules = rules.WithoutThrowOnRegisteringDisposableTransient();

            return rules;
        }

        public void Unregister(Type serviceType, string name = null)
        {
            _dryContainer.Unregister(serviceType, name);
        }

        public void Unregister<T>(string name = null)
        {
            _dryContainer.Unregister<T>(name);
        }
    }
}