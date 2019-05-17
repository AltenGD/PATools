using osu.Framework.Graphics;
using StreamToolUI.Main.Overlays.Settings;
using StreamToolUI.Main.Overlays.Settings.Sections;
using System.Collections.Generic;

namespace StreamToolUI.Main.Overlays
{
    public class MainSettings : SettingsOverlay
    {
        protected override IEnumerable<SettingsSection> CreateSections() => new SettingsSection[]
        {
            new GeneralSection(),
            new GraphicsSection(),
            new DirectorySection(),
            new AudioSection()
        };

        protected override Drawable CreateHeader() => new SettingsHeader("Settings", "Change the way this tool behaves");
    }
}
