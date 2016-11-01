using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts
{
    public class ObservableDisposable<T> : IDisposable
    {
        private readonly IObserver<T> _observer;
        private readonly IList<IObserver<T>> _observers;

        public ObservableDisposable(IList<IObserver<T>> observers, IObserver<T> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer)) _observers.Remove(_observer);
        }
    }
}