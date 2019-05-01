using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using StreamToolUI.Main.Overlays.Settings.Sections.Test;

namespace StreamToolUI.Main.Overlays.Settings.Sections
{
    public class TestSection : SettingsSection
    {
        public override string Header => "Word";
        public override IconUsage Icon => FontAwesome.Solid.Cog;

        public TestSection()
        {
            Children = new Drawable[]
            {
                new TestSettings()
            };
        }
    }
}
