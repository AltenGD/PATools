using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using StreamToolUI.Main.Overlays.Settings.Sections.Audio;

namespace StreamToolUI.Main.Overlays.Settings.Sections
{
    public class AudioSection : SettingsSection
    {
        public override string Header => "Audio";
        public override IconUsage Icon => FontAwesome.Solid.VolumeUp;

        public AudioSection()
        {
            Children = new Drawable[]
            {
                new AudVolume(),
            };
        }
    }
}
