using GameLauncher.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameLauncher
{
    public partial class MainWindow : Window
    {
        SettingsWindow settingsWindow = new SettingsWindow();
        public MainWindow()
        {
            InitializeComponent();
            VideoPlayer.Position = TimeSpan.FromMilliseconds(5000);
        }

            private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Position = TimeSpan.FromMilliseconds(1);
        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            settingsWindow.Show();
        }
    }
}
