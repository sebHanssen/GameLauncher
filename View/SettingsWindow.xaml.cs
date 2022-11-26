using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GameLauncher.ViewModel;
using Newtonsoft.Json.Linq;

namespace GameLauncher.View
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            DataContext = new SettingsViewModel();
            InitializeComponent();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            App.events.OnSettingsClose();
        }

    }
}
