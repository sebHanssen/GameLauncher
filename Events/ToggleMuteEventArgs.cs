using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Events
{
    public class ToggleMuteEventArgs
    {
        public bool IsMuted { get; set; }
    }
}
