using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Platform;
using StreamToolUI.Main.Configuration;
using static StreamToolUI.Main.Configuration.StreamGameConfigManager;

namespace StreamToolUI.Main.Overlays.Settings.Sections.Graphics
{
    public class GraphFramework : SettingsSubsection
    {
        protected override string Header => "Framework";

        [BackgroundDependencyLoader]
        private void load(StreamGameConfigManager config)
        {
            Add(new SettingsCheckbox
            {
                LabelText = "Show FPS Display",
                Bindable = config.GetBindable<bool>(StreamGameSettings.ShowFpsDisplay)
            });
        }
    }
}
