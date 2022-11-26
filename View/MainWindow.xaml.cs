using GameLauncher.Events;
using GameLauncher.View;
using GameLauncher.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            DataContext = new MainViewModel();
            InitializeComponent();

            App.events.ChangeVersion += HandleVersionChanged;

            var resourceFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", App.settings.SelectedVersion + ".mp4");
            Uri sourceUri = new(resourceFolderPath);
            VideoPlayer.Source = sourceUri;
            VideoPlayer.Position = TimeSpan.FromMilliseconds(1);

            string[] VersionList;
            var versionFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Versions");
            VersionList = Directory.GetFiles(versionFolderPath, "*", SearchOption.AllDirectories).Select(x => System.IO.Path.GetFileNameWithoutExtension(x)).ToArray();
            VersionBox.ItemsSource = VersionList;
        }

            private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Position = TimeSpan.FromMilliseconds(1);
        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            settingsWindow.Show();
        }

        private void PlayClick(object sender, RoutedEventArgs e)
        {
            var currentVersion = VersionBox.SelectedItem as string;
            currentVersion = currentVersion + ".txt";
            var versionFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Versions", currentVersion);
            Process.Start("notepad.exe", versionFolderPath);
        }

        private void HandleVersionChanged(object sender, ChangeVersionEventArgs e)
        {
            var currentVersion = e.SelectedVersion;
            currentVersion = currentVersion + ".mp4";
            var resourceFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", currentVersion);
            Uri sourceUri = new(resourceFolderPath);
            VideoPlayer.Source = sourceUri;
            VideoPlayer.Position = TimeSpan.FromMilliseconds(1);
        }

     }
}
