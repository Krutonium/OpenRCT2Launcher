﻿using MahApps.Metro.Controls;
using PropertyChanged;

namespace LauncherWFP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ImplementPropertyChanged]
    public partial class MainWindow : MetroWindow
    {

        /// <summary>
        ///     Gets the <see cref="Data.MainWindowContext"/> that this <see cref="MainWindow"/> is bound to.
        /// </summary>
        public Data.Context.MainWindowContext Context { get; }

        /// <summary>
        ///     Creates a new instance of the <see cref="MainWindow"/>.
        /// </summary>
        public MainWindow()
        {
            Context = new Data.Context.MainWindowContext();
            InitializeComponent();
        }
    }
}