using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Events
{
    public class GameLauncherEvents
    {
        public delegate void ChangeVolumeEventHandler(object sender, ChangeVolumeEventArgs e);

        public event ChangeVolumeEventHandler? ChangeVolume;

        public virtual void OnVolumeChanged(double volume)
        {
            ChangeVolume?.Invoke(this, new ChangeVolumeEventArgs { Volume = volume });
        }

        public delegate void ToggleMuteEventHandler(object sender, ToggleMuteEventArgs e);

        public event ToggleMuteEventHandler? ToggleMute;

        public virtual void OnToggleMute(bool isMuted)
        {
            ToggleMute?.Invoke(this, new ToggleMuteEventArgs { IsMuted = isMuted });
        }

        public delegate void OnSettingsCloseEventHandler(object sender, EventArgs e);

        public event OnSettingsCloseEventHandler? SettingsClosed;

        public virtual void OnSettingsClose()
        {
            SettingsClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}
