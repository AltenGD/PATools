using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using StreamToolUI.Main.Overlays.Settings.Sections.UIElements;

namespace StreamToolUI.Main.Overlays.Settings.Sections
{
    public class UISection : SettingsSection
    {
        public override string Header => "UI Elements";
        public override IconUsage Icon => FontAwesome.Regular.WindowMaximize;

        public UISection()
        {
            Children = new Drawable[]
            {
                new UICheckboxes(),
                new UIButton(),
                new UISlider(),
                new UITextBox()
            };
        }
    }
}
