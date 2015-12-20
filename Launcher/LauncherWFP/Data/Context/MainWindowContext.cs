using LauncherWPF.UI;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using PropertyChanged;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LauncherWPF.Data.Context
{

    /// <summary>
    ///     DataContext for <see cref="MainWindow"/>.
    /// </summary>
    [ImplementPropertyChanged]
    public sealed class MainWindowContext
    {
        private TaskScheduler _scheduler = null;
        private Management.OpenRctIniManager _iniManager = null;
        private Management.OpenRctBuildManager _buildManager = null;
        private Management.OpenRctNetApiWrapper _apiWrapper = new Management.OpenRctNetApiWrapper();


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
        ///     Gets the <see cref="Visibility"/> of the <see cref="MainWindow"/>.
        /// </summary>
        public Visibility WindowVisibility { get; private set; }

        /// <summary>
        ///     A master switch boolean that will enable or disable all the buttons on the form.
        /// </summary>
        private bool FormButtonsEnabled { get; set; }

        /// <summary>
        ///     Gets or sets, privately, whether or not <see cref="UpdateCommand"/> can be invoked.
        /// </summary>
        private bool UpdateButtonEnabled { get; set; }

        /// <summary>
        ///     Gets or sets, privately, the <see cref="Process"/> for OpenRCT2.
        /// </summary>
        private Process RctProcess { get; set; }



        /// <summary>
        ///     Creates a new instance of the <see cref="MainWindowContext"/>
        /// </summary>
        public MainWindowContext()
        {
            _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            UpdateButtonEnabled = true;
            FormButtonsEnabled = true;
            WindowVisibility = Visibility.Visible;
            LaunchCommand = new RelayCommand(LaunchCommandImpl, CanLaunchCommandExecute);
            UpdateCommand = new RelayCommand(UpdateCommandImpl, CanUpdateCommandExecute);
            ConfigCommand = new RelayCommand(ConfigCommandImpl, CanConfigCommandExecute);
            ExtrasCommand = new RelayCommand(ExtrasCommandImpl, CanExtrasCommandExecute);
            LoadedCommand = new RelayCommand(LoadedCommandImpl, CanLoadedCommandExecute);
        }



        #region Launch Command
        private void LaunchCommandImpl(object param)
        {

            // OK, so it's time to run the process.
            var activeBuildNumber = _buildManager.ActiveBuildId.Value;
            var activeBuild = _buildManager.Active.Value;
            var activeRct2File = Path.Combine(Properties.Settings.Default.OpenRctExtractDir, activeBuildNumber.ToString(), "openrct2.exe");

            // Great.
            var pStartInfo = new ProcessStartInfo(activeRct2File)
            {
                CreateNoWindow = false
            };
            RctProcess = Process.Start(pStartInfo);
            AttachToRct2Process();

        }
        private bool CanLaunchCommandExecute(object param)
        {
            return FormButtonsEnabled && _buildManager != null && _buildManager.Active.HasValue && RctProcess == null;
        }
        #endregion

        #region Update Command
        private async void UpdateCommandImpl(object param)
        {
            UpdateButtonEnabled = false;
            await UpdateCommandAsync();
            UpdateButtonEnabled = true;
            CommandManager.InvalidateRequerySuggested();
        }
        private async Task UpdateCommandAsync()
        {
            // So, here's what we've got to do.
            // We're gonna grab the MainWindow (which'll be the LauncherWPF.MainWindow instance).
            // After we grab that, we're going to setup some dialogs for use. These dialogs will
            // be key to communicating with the end user that's going on.

            // Once we get some dialogs up to display what's going on, we're going to sync with the current server
            // what build number is currently the latest one. After we do that, we'll do a little bit of logic to see
            // if it's time to update. We'll prompt the user if it's OK to update, then install the update if they are OK
            // with it. There might not be many comments throughout this code, hence the massive blob of text up here.
            // This is all async too.

            // This'll work, trust me. The reason why this works is that the MainWindow (declared in App.xaml) is MainWindow.xaml.
            // MainWindow.xaml is a subclass of MetroWindow. That's why this cast is 100% valid. For now. If we ever change from
            // MahApps to some other... UI framework, we'll suffer an untimely death of compile and runtime errors.
            var mainWindow = (MetroWindow)Application.Current.MainWindow;

            // Get the Progress Dialog up and running. This is the important one here. When we have this open,
            // we can actually show what's going on to the end user.
            var progressDialog = await mainWindow.ShowProgressAsync(Resources.Text.Strings.UI_MAIN_UPDATE_PB_TITLE1,
                Resources.Text.Strings.UI_MAIN_UPDATE_PB_MESSAGE1, false);
            progressDialog.SetIndeterminate();

            // Now then, let's fetch our list from OpenRCT.NET
            var apiResultsOption = await _apiWrapper.GetBuildInformationAsync(Properties.Settings.Default.IsOnDevelopBranch);
            if (!apiResultsOption.HasValue)
            {
                await progressDialog.CloseAsync();
                await mainWindow.ShowMessageAsync(Resources.Text.Strings.UI_WINDOWS_GENERAL_ERROR,
                    Resources.Text.Strings.UI_MAIN_UPDATE_PB_MESSAGE2, MessageDialogStyle.Affirmative);
                return;
            }

            var apiResults = apiResultsOption.Value;
            var latestBuild = apiResults.Builds[apiResults.CurrentBuild];
            progressDialog.SetMessage(string.Format(Resources.Text.Strings.UI_MAIN_UPDATE_PB_MESSAGE3,
                _buildManager.ActiveBuildId.HasValue ? _buildManager.ActiveBuildId.Value : 0,
                apiResults.CurrentBuild));

            // Now that we've gotten all the information from the server, let's see what we can do about it.
            if (!_buildManager.ActiveBuildId.HasValue || _buildManager.ActiveBuildId.Value < apiResults.CurrentBuild)
            {
                await progressDialog.CloseAsync();

                // If we currently do not have the "AutoUpdateToLatest" option enabled, we need
                // to explicitly ask if we're allowed to do this.
                if (!Properties.Settings.Default.AutoUpdateToLatest)
                {
                    // Let's leave the option to update to the end user.
                    var questionDialogResult = await mainWindow.ShowMessageAsync(Resources.Text.Strings.UI_MAIN_UPDATE_MB_TITLE1,
                        Resources.Text.Strings.UI_MAIN_UPDATE_MB_MESSAGE1,
                        MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, new MetroDialogSettings
                        {
                            AffirmativeButtonText = Resources.Text.Strings.UI_WINDOWS_GENERAL_YES,
                            NegativeButtonText = Resources.Text.Strings.UI_WINDOWS_GENERAL_NO,
                            FirstAuxiliaryButtonText = Resources.Text.Strings.UI_MAIN_UPDATE_MB_AUX1
                        });

                    switch (questionDialogResult)
                    {
                        case MessageDialogResult.FirstAuxiliary:
                            Properties.Settings.Default.AutoUpdateToLatest = true;
                            break;
                        case MessageDialogResult.Negative:
                            return;
                    }
                }

                progressDialog = await mainWindow.ShowProgressAsync(Resources.Text.Strings.UI_MAIN_UPDATE_PB_TITLE1, string.Format(Resources.Text.Strings.UI_MAIN_UPDATE_PB_MESSAGE4, latestBuild.ZipFile));
                await Task.Factory.StartNew(() =>
                {
                    _buildManager.Download(apiResults.CurrentBuild, latestBuild);
                    _buildManager.Save();
                });
            }
            await progressDialog.CloseAsync();
            await mainWindow.ShowMessageAsync(Resources.Text.Strings.UI_MAIN_UPDATE_MB_TITLE2, Resources.Text.Strings.UI_MAIN_UPDATE_MB_MESSAGE2);
        }
        private bool CanUpdateCommandExecute(object param)
        {
            return UpdateButtonEnabled && FormButtonsEnabled;
        }
        #endregion

        #region Configuration Command
        private void ConfigCommandImpl(object param)
        {

        }
        private bool CanConfigCommandExecute(object param)
        {
            return false && FormButtonsEnabled;
        }
        #endregion

        #region Extras Command
        private void ExtrasCommandImpl(object param)
        {

        }
        private bool CanExtrasCommandExecute(object param)
        {
            return false && FormButtonsEnabled;
        }
        #endregion

        #region LoadedCommand
        private void LoadedCommandImpl(object param)
        {
            Properties.Settings.Default.Upgrade();
            PerformFirstRunAndSetupCheck();
            WindowVisibility = Visibility.Visible;

            // Time to setup the build manager. With this setup and running, we can
            // begin to actually do some work!
            _buildManager = new Management.OpenRctBuildManager(
                Properties.Settings.Default.IsOnDevelopBranch ?
                    Properties.Settings.Default.DevelopName :
                    Properties.Settings.Default.ReleaseName);

            // Before update runs, let's see if openrct2 is running already.
            // this is a pretty nice quality-of-life feature to have.
            FindOpenRct2Process();
            InvokeAutoUpdateFeature();
        }
        private bool CanLoadedCommandExecute(object param)
        {
            return true; // this will always return true.
        }
        #endregion

        #region Miscellaneous Methods

        /// <summary>
        ///     Attempts to locate the RCT2 Process.
        /// </summary>
        /// <remarks>
        ///     If ONE process is found, <see cref="RctProcess"/> will be set to the <see cref="Process"/> that is discovered. <see cref="AttachToRct2Process"/> will then be invoked. If there are multiple processes that are discovered, the function returns.
        /// </remarks>
        private void FindOpenRct2Process()
        {
            var processes = Process.GetProcessesByName("openrct2");
            if (processes.Length == 0) return;
            if (processes.Length > 1) return;
            RctProcess = processes[0];
            AttachToRct2Process();
        }

        /// <summary>
        ///     Invokes a <see cref="System.Action"/> on the UI thread and blocks until the <see cref="System.Action"/> has completed.
        /// </summary>
        /// <param name="action">The <see cref="System.Action"/> to invoke.</param>
        private void InvokeOnUiThread(System.Action action)
        {
            Task.Factory.StartNew(action, System.Threading.CancellationToken.None, TaskCreationOptions.None, _scheduler).Wait();
        }

        /// <summary>
        ///     Attaches an event handler to the OpenRCT2 <see cref="Process.Exited"/> event.
        /// </summary>
        private void AttachToRct2Process()
        {
            RctProcess.EnableRaisingEvents = true;
            RctProcess.Exited += (o, e) =>
            {
                RctProcess.Dispose();
                RctProcess = null;
                InvokeOnUiThread(() => CommandManager.InvalidateRequerySuggested());
            };
        }

        /// <summary>
        ///     Invokes the auto-update functionality.
        /// </summary>
        private void InvokeAutoUpdateFeature()
        {
            if (Properties.Settings.Default.AutoUpdateToLatest && RctProcess == null) UpdateCommand.Execute(null);
        }

        /// <summary>
        ///     Checks to see if this is our first run. If so, does some dialog things.
        /// </summary>
        private void PerformFirstRunAndSetupCheck()
        {
            if (Properties.Settings.Default.IsFirstRun)
            {
                WindowVisibility = Visibility.Hidden;
                var result = new UI.Windows.Welcome().ShowDialog();
                if (!result.HasValue || !result.Value) Application.Current.Shutdown();

                // Create the INI file.
                Management.OpenRctIniManager.Create();
                _iniManager = new Management.OpenRctIniManager();
                _iniManager.GamePath = Properties.Settings.Default.RctInstallDir;
                _iniManager.Save();

            }
        }

        #endregion

    }

}