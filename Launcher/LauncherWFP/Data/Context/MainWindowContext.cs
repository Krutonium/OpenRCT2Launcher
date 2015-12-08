﻿using LauncherWFP.UI;
using PropertyChanged;
using System.Windows.Input;

namespace LauncherWFP.Data.Context
{

    /// <summary>
    ///     DataContext for <see cref="MainWindow"/>.
    /// </summary>
    [ImplementPropertyChanged]
    public sealed class MainWindowContext
    {


        /// <summary>
        ///     Invoked when the Launch button is pressed.
        /// </summary>
        public ICommand LaunchCommand { get; }

        /// <summary>
        ///     Invoked when the update button is pressed.
        /// </summary>
        public ICommand UpdateCommand { get; }

        /// <summary>
        ///     Invoked when the configuration button is pressed.
        /// </summary>
        public ICommand ConfigCommand { get; }

        /// <summary>
        ///     Invoked when the extras button is pressed.
        /// </summary>
        public ICommand ExtrasCommand { get; }

        /// <summary>
        ///     Invoked when the <see cref="MainWindow"/> is loaded.
        /// </summary>
        public ICommand LoadedCommand { get; }



        /// <summary>
        ///     Creates a new instance of the <see cref="MainWindowContext"/>
        /// </summary>
        public MainWindowContext()
        {
            LaunchCommand = new RelayCommand(LaunchCommandImpl, CanLaunchCommandExecute);
            UpdateCommand = new RelayCommand(UpdateCommandImpl, CanUpdateCommandExecute);
            ConfigCommand = new RelayCommand(ConfigCommandImpl, CanConfigCommandExecute);
            ExtrasCommand = new RelayCommand(ExtrasCommandImpl, CanExtrasCommandExecute);
            LoadedCommand = new RelayCommand(LoadedCommandImpl, CanLoadedCommandExecute);
        }

        #region Launch Command
        private void LaunchCommandImpl(object param)
        {

        }
        private bool CanLaunchCommandExecute(object param)
        {
            return false;
        }
        #endregion

        #region Update Command
        private void UpdateCommandImpl(object param)
        {

        }
        private bool CanUpdateCommandExecute(object param)
        {
            return false;
        }
        #endregion

        #region Configuration Command
        private void ConfigCommandImpl(object param)
        {

        }
        private bool CanConfigCommandExecute(object param)
        {
            return false;
        }
        #endregion

        #region Extras Command
        private void ExtrasCommandImpl(object param)
        {

        }
        private bool CanExtrasCommandExecute(object param)
        {
            return false;
        }
        #endregion

        #region LoadedCommand
        private void LoadedCommandImpl(object param)
        {
            if(Properties.Settings.Default.IsFirstRun) new UI.Windows.Welcome().ShowDialog();
        }
        private bool CanLoadedCommandExecute(object param)
        {
            return true; // this will always return true.
        }
        #endregion

    }
}
