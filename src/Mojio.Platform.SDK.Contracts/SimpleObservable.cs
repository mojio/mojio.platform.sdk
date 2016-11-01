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