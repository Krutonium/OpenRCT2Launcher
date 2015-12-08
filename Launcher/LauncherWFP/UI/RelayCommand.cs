using System;
using System.Windows.Input;

namespace LauncherWFP.UI
{

    /// <summary>
    ///     A simple implementation of <see cref="ICommand"/> to invoke an <see cref="Action{T}"/> that is optionally controlled by a <see cref="Predicate{T}"/>.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region ICommand Events

        /// <summary>
        ///     Invoked when the condition for execution have changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion ICommand Events

        #region Fields

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        #endregion Fields

        #region Constructors

        /// <summary>
        ///     Creates a new instance of the <see cref="RelayCommand" /> with the given <paramref name="command">Action</paramref>
        ///     to execute.
        /// </summary>
        /// <param name="command">The <see cref="Action{T}" /> command to invoke</param>
        /// <exception cref="ArgumentNullException"><paramref name="command" /> is <see langword="null" />.</exception>
        public RelayCommand(Action<object> command) : this(command, null) { }

        /// <summary>
        ///     Creates a new instance of the <see cref="RelayCommand" /> with the given <paramref name="command" /> to execute as
        ///     well as the <paramref name="predicate" /> that verifies whether or not the <paramref name="command" /> can be
        ///     invoked.
        /// </summary>
        /// <param name="command">The <see cref="Action{T}" /> command to invoke</param>
        /// <param name="predicate">
        ///     A <see cref="Predicate{T}" /> that determines whether or not the <paramref name="command" />
        ///     may be executed.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="command" /> is <see langword="null" />.</exception>
        public RelayCommand(Action<object> command, Predicate<object> predicate)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            _execute = command;
            _canExecute = predicate;
        }

        #endregion Constructors

        #region ICommand Members

        /// <summary>
        ///     Checks whether or not the given <see cref="RelayCommand" /> can execute.
        /// </summary>
        /// <param name="parameter">
        ///     An <see cref="object" /> to fuel the <see cref="RelayCommand" />'s <see cref="Predicate{T}" />
        /// </param>
        /// <returns><see cref="bool" />; true if <see cref="Execute" /> can be invoked.</returns>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        ///     Executes the <see cref="RelayCommand" />
        /// </summary>
        /// <param name="parameter">
        ///     An <see cref="object" /> to fuel the <see cref="RelayCommand" />'s <see cref="Action{T}" />
        /// </param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        ///     Re-evaluate whether or not <see cref="RelayCommand"/> can be invoked.
        /// </summary>
        public void Refresh()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        #endregion ICommand Members
    }

}
