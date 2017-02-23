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
    public class SimpleObservable<T> : IObservable<T>
    {
        private readonly IList<IObserver<T>> observers = new List<IObserver<T>>();

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (observer == null) return null;
            var disposer = new ObservableDisposable<T>(observers, observer);
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return disposer;
        }

        public void Next(T item)
        {
            if (item != null)
            {
                foreach (var observer in observers)
                {
                    if (observer != null) observer.OnNext(item);
                }
            }
        }
    }
}