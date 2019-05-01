using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using StreamToolUI.Main.Overlays.Settings.Sections.General;

namespace StreamToolUI.Main.Overlays.Settings.Sections
{
    public class GeneralSection : SettingsSection
    {
        public override string Header => "General";
        public override IconUsage Icon => FontAwesome.Regular.Hourglass;

        public GeneralSection()
        {
            Children = new Drawable[]
            {
                new GenBeatmap()
            };
        }
    }
}
