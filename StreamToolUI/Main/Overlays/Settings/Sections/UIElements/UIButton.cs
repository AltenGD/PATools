using osu.Framework.Allocation;

namespace StreamToolUI.Main.Overlays.Settings.Sections.UIElements
{
    public class UIButton : SettingsSubsection
    {
        protected override string Header => "Button";

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new SettingsButton
            {
                Text = "Text"
            });
        }
    }
}
