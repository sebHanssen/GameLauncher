using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Navigation;
using Newtonsoft.Json;
using System.Windows.Media.Animation;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Printing;
using CommunityToolkit.Mvvm.Input;
using GameLauncher.Model;
using GameLauncher.Events;
using GameLauncher.View;
using System.Windows;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace GameLauncher.ViewModel
{
    public partial class MainViewModel : ObservableObject
	{
        #region Private fields       

        [ObservableProperty]
        private double volumeLevel;

        [ObservableProperty]
        private bool isMuted;

        [ObservableProperty]
        private bool isAutoUpdate;

        [ObservableProperty]
        private string? selectedVersion;


        #endregion

        public MainViewModel()
        {
            App.events.ChangeVolume += HandleVolumeChanged;
            App.events.ToggleMute += HandleMuteChanged;
            App.events.ToggleUpdate += HandleUpdateChanged;
            App.events.ChangeVersion += HandleVersionChanged;
            
            LoadSettingsFromModel(App.settings);
            
        }

        private void LoadSettingsFromModel(Settings s)
        {
            VolumeLevel = s.VolumeLevel;
            IsMuted = s.IsMuted;
            IsAutoUpdate = s.IsAutoUpdate;
            SelectedVersion = s.SelectedVersion;

            if (IsAutoUpdate)
            {
                string[] VersionList;
                var versionFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Versions");
                VersionList = Directory.GetFiles(versionFolderPath, "*", SearchOption.AllDirectories).Select(x => Path.GetFileNameWithoutExtension(x)).ToArray();
                SelectedVersion = FindLatestVersion(VersionList);
            }
        }

        partial void OnSelectedVersionChanged(string? value)
        {
            App.events.OnChangeVersion(value);
        }

        private void HandleVolumeChanged(object sender, ChangeVolumeEventArgs e)
        {
            if(e.Volume >= 0.0 || e.Volume <= 1.0) 
            {
                VolumeLevel = e.Volume;
            }
        }

        private void HandleMuteChanged(object sender, ToggleMuteEventArgs e)
        {
            IsMuted = e.IsMuted;
        }

        private void HandleUpdateChanged(object sender, ToggleUpdateEventArgs e)
        {
            IsAutoUpdate = e.IsAutoUpdate;
        }

        private void HandleVersionChanged(object sender, ChangeVersionEventArgs e)
        {
            SelectedVersion = e.SelectedVersion;
            App.settings.SelectedVersion = SelectedVersion;
            File.WriteAllText(@"data.json", JsonConvert.SerializeObject(App.settings, Formatting.Indented));
        }

        private string FindLatestVersion(string[] versionList)
        {
            
            int val = 0;
            int versionNumber = 0;
            string latestVersion = "";

            foreach (string v in versionList)
            {
                versionNumber = int.Parse(new string(v.Where(x => char.IsDigit(x)).ToArray()));
                if(versionNumber > val)
                {
                    val = versionNumber;
                    latestVersion = v;
                }

            }
            return latestVersion;
        }

    }
}
