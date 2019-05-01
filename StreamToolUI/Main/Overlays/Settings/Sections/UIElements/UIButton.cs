using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Platform;

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
