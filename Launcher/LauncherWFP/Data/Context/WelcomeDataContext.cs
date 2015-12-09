using LauncherWFP.UI;
using Microsoft.WindowsAPICodePack.Dialogs;
using PropertyChanged;
using System.Windows.Input;

namespace LauncherWFP.Data.Context
{

    [ImplementPropertyChanged]
    public sealed class WelcomeDataContext
    {

        public ICommand OKCommand { get; }

        public ICommand BrowseDownloadPathCommand { get; }

        public ICommand BrowseExtractPathCommand { get; }

        public ICommand BrowseRctPathCommand { get; }

        public string BaseDownloadPath { get; set; }

        public string BaseInstallPath { get; set; }

        public string Rct2InstallPath { get; set; }

        public bool AutoUpdateOpenRct2 { get; set; }

        public WelcomeDataContext()
        {
            BaseDownloadPath = System.Environment.ExpandEnvironmentVariables("%appdata%\\ORCT2\\Downloads");
            BaseInstallPath = System.Environment.ExpandEnvironmentVariables("%appdata%\\ORCT2\\Builds");
            Rct2InstallPath = Management.RctLocator.DiscoverRct2InstallationDirectory() ?? string.Empty;
            AutoUpdateOpenRct2 = true;
            BrowseDownloadPathCommand = new RelayCommand(BrowseDownloadPathCommandImpl, null);
            BrowseExtractPathCommand = new RelayCommand(BrowseExtractPathCommandImpl, null);
            BrowseRctPathCommand = new RelayCommand(BrowseRctPathCommandImpl, null);
            OKCommand = new RelayCommand(OkCommandImpl, CanOkCommandRunImpl);
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
            Properties.Settings.Default.IsFirstRun = false;
            Properties.Settings.Default.Save();
            window.DialogResult = true;
            window.Close();
        }
        private bool CanOkCommandRunImpl(object param)
        {
            return !string.IsNullOrWhiteSpace(BaseDownloadPath) &&
                !string.IsNullOrWhiteSpace(BaseInstallPath) &&
                !string.IsNullOrWhiteSpace(Rct2InstallPath);
        }

        #endregion


    }

}