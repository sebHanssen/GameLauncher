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

namespace GameLauncher.ViewModel
{
    public partial class MainViewModel : ObservableObject
	{
        #region Private fields

        

        [ObservableProperty]
        private double volumeLevel;

        [ObservableProperty]
        private bool isMuted;

        #endregion

        public MainViewModel()
        {
            App.events.ChangeVolume += HandleVolumeChanged;
            App.events.ToggleMute += HandleMuteChanged;
            LoadSettingsFromModel(App.settings);
        }

        private void LoadSettingsFromModel(Settings s)
        {
            VolumeLevel = s.VolumeLevel;
            IsMuted = s.IsMuted;
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

    }
}
