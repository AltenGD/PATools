using osu.Framework.Allocation;
using osu.Framework.Graphics;
using StreamToolUI.Main.Configuration;
using static StreamToolUI.Main.Configuration.StreamGameConfigManager;

namespace StreamToolUI.Main.Overlays.Settings.Sections.Graphics
{
    public class GraphUI : SettingsSubsection
    {
        protected override string Header => "User Interface";

        [BackgroundDependencyLoader]
        private void load(StreamGameConfigManager config)
        {
            AddRange(new Drawable[]
            {
                new SettingsCheckbox
                {
                    LabelText = "Change background on Set",
                    Bindable = config.GetBindable<bool>(StreamGameSettings.ChangeBackground)
                },
                new SettingsCheckbox
                {
                    LabelText = "Parallax",
                    Bindable = config.GetBindable<bool>(StreamGameSettings.MenuParallax)
                },
            });
        }
    }
}
