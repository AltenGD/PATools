using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using StreamToolUI.Main.Overlays.Settings.Sections.Graphics;

namespace StreamToolUI.Main.Overlays.Settings.Sections
{
    public class GraphicsSection : SettingsSection
    {
        public override string Header => "Graphics";
        public override IconUsage Icon => FontAwesome.Solid.Laptop;

        public GraphicsSection()
        {
            Children = new Drawable[]
            {
                new GraphFramework(),
                new GraphUI(),
            };
        }
    }
}
