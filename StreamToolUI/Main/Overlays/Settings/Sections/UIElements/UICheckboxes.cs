using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Platform;

namespace StreamToolUI.Main.Overlays.Settings.Sections.UIElements
{
    public class UICheckboxes : SettingsSubsection
    {
        protected override string Header => "Checkbox";

        [BackgroundDependencyLoader]
        private void load()
        {
            AddRange(new Drawable[]
            {
                new SettingsCheckbox
                {
                    LabelText = "Checked",
                    Bindable = new BindableBool(true)
                },
                new SettingsCheckbox
                {
                    LabelText = "Unchecked",
                    Bindable = new BindableBool(false)
                }
            });
        }
    }
}
