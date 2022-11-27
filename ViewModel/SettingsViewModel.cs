using CommunityToolkit.Mvvm.ComponentModel;
using GameLauncher.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.ViewModel
{
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private int volume;

        [ObservableProperty]
        private bool mute;

        [ObservableProperty]
        private bool autoUpdate;

        [ObservableProperty]
        private string? volumetext;

        partial void OnVolumeChanged(int value)
        {
            if(value < 0)
            {
                Volume = 0;
            }
            if (value > 100)
            {
                Volume = 100;
            }

            double doublevolume = (double)Volume / 100;
            App.events.OnVolumeChanged(doublevolume);
            Volumetext = Volume.ToString() + "%";
            App.events.SettingsClosed += HandleSettingsClosed;
        }

        partial void OnMuteChanged(bool value)
        {
            App.events.OnToggleMute(value);
        }

        partial void OnAutoUpdateChanged(bool value)
        {
            App.events.OnToggleUpdate(value);
        }

        private void HandleSettingsClosed(object sender, EventArgs e)
        {
            App.settings.VolumeLevel = ((double)Volume)/100.0;
            App.settings.IsMuted = Mute;
            App.settings.IsAutoUpdate= AutoUpdate;
            System.IO.File.WriteAllText(@"data.json", JsonConvert.SerializeObject(App.settings, Formatting.Indented));
        }


        public SettingsViewModel()
        {
            if(App.settings != null) 
            {
                Volume = (int)(App.settings.VolumeLevel*100);
                Mute = App.settings.IsMuted;
                AutoUpdate = App.settings.IsAutoUpdate;
                Volumetext = Volume.ToString() + "%";
            }
        }
    }
}
