using LauncherWPF.UI;
using Microsoft.WindowsAPICodePack.Dialogs;
using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LauncherWPF.Data.Context
{

    [ImplementPropertyChanged]
    public sealed class WelcomeDataContext
    {

        private bool DisableRctBrowseButton { get; set; }

        public ICommand LoadedCommand { get; }

        public ICommand OKCommand { get; }

        public ICommand BrowseDownloadPathCommand { get; }

        public ICommand BrowseExtractPathCommand { get; }

        public ICommand BrowseRctPathCommand { get; }

        public string BaseDownloadPath { get; set; }

        public string BaseInstallPath { get; set; }

        public string Rct2InstallPath { get; set; }

        public bool AutoUpdateOpenRct2 { get; set; }

        public bool UseDevBranch { get; set; }

        public WelcomeDataContext()
        {
            DisableRctBrowseButton = true;
            BaseDownloadPath = System.Environment.ExpandEnvironmentVariables("%appdata%\\ORCT2\\Downloads");
            BaseInstallPath = System.Environment.ExpandEnvironmentVariables("%appdata%\\ORCT2\\Builds");
            AutoUpdateOpenRct2 = true;
            UseDevBranch = false;
            BrowseDownloadPathCommand = new RelayCommand(BrowseDownloadPathCommandImpl, null);
            BrowseExtractPathCommand = new RelayCommand(BrowseExtractPathCommandImpl, null);
            BrowseRctPathCommand = new RelayCommand(BrowseRctPathCommandImpl, (o) => !DisableRctBrowseButton);
            OKCommand = new RelayCommand(OkCommandImpl, CanOkCommandRunImpl);

            // Async to not block. Mean things done here to ensure we don't block in case detecting the install is slow.
            LoadedCommand = new RelayCommand(async (o) =>
            {
                Rct2InstallPath = "Detecting...";
                Rct2InstallPath = (await Task.Factory.StartNew(() =>
                {
                    var rctPath = Management.RctLocator.DiscoverRct2InstallationDirectory() ?? string.Empty;
                    DisableRctBrowseButton = false;
                    return rctPath;
                }));
                CommandManager.InvalidateRequerySuggested();
            });
        }


        #region Download Path Command Implementation
        private void BrowseDownloadPathCommandImpl(object param)
        {
            using (var cofd = new CommonOpenFileDialog { IsFolderPicker = true })
            {
                switch(cofd.ShowDialog())
                {
                    case CommonFileDialogResult.Ok:
                        BaseDownloadPath = cofd.FileName;
                        break;
                }

            }
        }
        #endregion

        #region Extract Path Command Implementation
        private void BrowseExtractPathCommandImpl(object param)
        {
            using (var cofd = new CommonOpenFileDialog { IsFolderPicker = true })
            {
                switch (cofd.ShowDialog())
                {
                    case CommonFileDialogResult.Ok:
                        BaseInstallPath = cofd.FileName;
                        break;
                }

            }
        }
        #endregion

        #region RCT2 Path Command Implementation
        private void BrowseRctPathCommandImpl(object param)
        {
            using (var cofd = new CommonOpenFileDialog { IsFolderPicker = true })
            {
                switch (cofd.ShowDialog())
                {
                    case CommonFileDialogResult.Ok:
                        Rct2InstallPath = cofd.FileName;
                        break;
                }

            }
        }
        #endregion

        #region OK Command Implementation
        private void OkCommandImpl(object param)
        {
            var window = (param as UI.Windows.Welcome);
            Properties.Settings.Default.OpenRctDownloadDir = BaseDownloadPath;
            Properties.Settings.Default.OpenRctExtractDir = BaseInstallPath;
            Properties.Settings.Default.RctInstallDir = Rct2InstallPath;
            Properties.Settings.Default.AutoUpdateToLatest = AutoUpdateOpenRct2;
            Properties.Settings.Default.IsOnDevelopBranch = UseDevBranch;
            Properties.Settings.Default.IsFirstRun = false;
            Properties.Settings.Default.Save();
            window.DialogResult = true;
            window.Close();
        }
        private bool CanOkCommandRunImpl(object param)
        {
            return !string.IsNullOrWhiteSpace(BaseDownloadPath) &&
                !string.IsNullOrWhiteSpace(BaseInstallPath) &&
                !string.IsNullOrWhiteSpace(Rct2InstallPath) && !DisableRctBrowseButton;
        }

        #endregion

    }

}