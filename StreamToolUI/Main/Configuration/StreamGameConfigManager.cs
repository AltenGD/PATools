using osu.Framework.Configuration;
using osu.Framework.Configuration.Tracking;
using osu.Framework.Extensions;
using osu.Framework.Platform;
using static StreamToolUI.Main.Configuration.StreamGameConfigManager;

namespace StreamToolUI.Main.Configuration
{
    public class StreamGameConfigManager : IniConfigManager<StreamGameSettings>
    {
        protected override void InitialiseDefaults()
        {
            base.InitialiseDefaults();

            //UI
            Set(StreamGameSettings.ChangeBackground, true);

            //Directories
            Set(StreamGameSettings.DefaultImage, @"C:\Program Files (x86)\Steam\steamapps\common\Project Arrhythmia\beatmaps\editor\default.jpg");
            Set(StreamGameSettings.StreamDirectory, @"D:\PAStream\Beatmap");

            //Graphics
            Set(StreamGameSettings.ShowFpsDisplay, false);
            Set(StreamGameSettings.MenuParallax, true);

            //Other
            Set(StreamGameSettings.Slider1, 10.0, 0, 10);
            Set(StreamGameSettings.Slider2, 1.0, 0, 10);
            Set(StreamGameSettings.Slider3, 0.5, 0, 10);
        }

        public StreamGameConfigManager(Storage storage)
            : base(storage) { }

        public enum StreamGameSettings
        {
            ChangeBackground,
            ShowFpsDisplay,
            MenuParallax,
            StreamDirectory,
            DefaultImage,

            //Other
            Slider1,
            Slider2,
            Slider3
        }
    }
}
