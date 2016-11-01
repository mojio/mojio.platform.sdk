using System;
using System.Windows.Input;

namespace Mojio.Platform.SDK.SampleApp.Shared.Contracts
{
    public interface IRelayCommand<T> : ICommand
    {
        Action<T> ExecuteAction { get; set; }
        Predicate<T> CanExecutePredicate { get; set; }
    }
}