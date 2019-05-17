using osu.Framework.Allocation;
using osu.Framework.Graphics;
using StreamToolUI.Main.Configuration;
using static StreamToolUI.Main.Configuration.StreamGameConfigManager;

namespace StreamToolUI.Main.Overlays.Settings.Sections.Directory
{
    public class DirDirectory : SettingsSubsection
    {
        protected override string Header => "Directories";

        [BackgroundDependencyLoader]
        private void load(StreamGameConfigManager config)
        {
            Children = new Drawable[]
            {
                new SettingsTextBox { LabelText = "Default Image", Bindable = config.GetBindable<string>(StreamGameSettings.DefaultImage) },
                new SettingsTextBox { LabelText = "Stream Directory", Bindable = config.GetBindable<string>(StreamGameSettings.StreamDirectory) },
            };
        }
    }
}
