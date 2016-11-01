using System;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;

namespace Mojio.Platform.SDK.SampleApp.Shared.Entities
{
    public class RelayCommand<T> : IRelayCommand<T>
    {
        #region Fields

        public Action<T> ExecuteAction { get; set; }
        public Predicate<T> CanExecutePredicate { get; set; }

        #endregion Fields

        #region ICommand Members

        /// <summary>
        ///     Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        ///     true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return CanExecutePredicate == null ? true : CanExecutePredicate((T)parameter);
        }

        /// <summary>
        ///     Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public void Execute(object parameter)
        {
            ExecuteAction((T)parameter);
        }

        public event EventHandler CanExecuteChanged;

        #endregion ICommand Members
    }
}