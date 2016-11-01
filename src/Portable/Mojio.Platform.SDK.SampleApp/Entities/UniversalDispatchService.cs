using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace Mojio.Platform.SDK.SampleApp.Entities
{
    public class UniversalDispatchService : IDispatchService
    {
        private readonly CoreDispatcher _dispatcher;
        private readonly ILog _log;

        public UniversalDispatchService(CoreDispatcher dispatcher, ILog log)
        {
            _dispatcher = dispatcher;
            _log = log;
        }

        public PropertyChangedEventHandler Handler { get; set; }

        public async Task RunAsync(string propertyName)
        {
            if (Handler != null)
            {
                _log.Info("OnPropertyChanged:{0}", propertyName);
                await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    try
                    {
                        Handler(this, new PropertyChangedEventArgs(propertyName));
                    }
                    catch (Exception e)
                    {
                        _log.Error(e, propertyName);
                    }
                });
            }
        }
    }
}