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
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts
{
    public interface IRegister
    {
        void Register(Type serviceType, Type implementationType, string serviceName = null);

        void Register<I, T>(string name = null) where T : I;

        void RegisterInstance<T>(T instance, string serviceName = null);

        void RegisterSingleton<I, T>(string name = null) where T : I;
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