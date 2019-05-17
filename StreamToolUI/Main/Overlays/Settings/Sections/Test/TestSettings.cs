using osu.Framework.Allocation;

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
