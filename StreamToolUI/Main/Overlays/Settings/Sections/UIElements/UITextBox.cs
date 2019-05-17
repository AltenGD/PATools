using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;

namespace StreamToolUI.Main.Overlays.Settings.Sections.UIElements
{
    public class UITextBox : SettingsSubsection
    {
        protected override string Header => "Text Box";

        [BackgroundDependencyLoader]
        private void load()
        {
            Children = new Drawable[]
            {
                new SettingsTextBox { LabelText = "Checkbox w/o text", Bindable = new Bindable<string>() },
                new SettingsTextBox { LabelText = "Checkbox w/text", Bindable = new Bindable<string>("Test String") },
            };
        }
    }
}
