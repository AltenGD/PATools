using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using StreamToolUI.Main.Overlays.Settings.Sections.Directory;

namespace StreamToolUI.Main.Overlays.Settings.Sections
{
    public class DirectorySection : SettingsSection
    {
        public override string Header => "Directories";
        public override IconUsage Icon => FontAwesome.Regular.Folder;

        public DirectorySection()
        {
            Children = new Drawable[]
            {
                new DirDirectory()
            };
        }
    }
}
