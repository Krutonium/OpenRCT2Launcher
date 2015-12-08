using MahApps.Metro.Controls;

namespace LauncherWFP.UI.Windows
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : MetroWindow
    {

        public Data.Context.WelcomeDataContext Context { get; }

        public Welcome()
        {
            Context = new Data.Context.WelcomeDataContext();
            InitializeComponent();
        }
    }
}
