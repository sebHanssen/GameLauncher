using System.IO;
using Newtonsoft.Json;

namespace GameLauncher.Model
{
    public class Settings
    {
        public double VolumeLevel { get; set; }
        public bool IsMuted { get; set; }

        public Settings()
        {
            if (File.Exists(@"data.json"))
            {
                JsonConvert.PopulateObject(File.ReadAllText(@"data.json"), this);
            }
            else
            {
                SetDefaults();
            }
        }

        private void SetDefaults()
        {
            VolumeLevel = 0.1;
            IsMuted = false;
        }
    }
    
}
