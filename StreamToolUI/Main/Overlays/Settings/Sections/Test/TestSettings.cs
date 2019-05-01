using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Platform;

namespace StreamToolUI.Main.Overlays.Settings.Sections.Test
{
    public class TestSettings : SettingsSubsection
    {
        protected override string Header => "Test";

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new SettingsCheckbox
            {
                LabelText = "Test Text",
            });
        }
    }
}
