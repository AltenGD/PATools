using osu.Framework.Graphics;
using StreamToolUI.Main.Graphics.UI;

namespace StreamToolUI.Main.Overlays.Settings
{

    public class SettingsCheckbox : SettingsItem<bool>
    {
        private StreamGameCheckbox checkbox;

        protected override Drawable CreateControl() => checkbox = new StreamGameCheckbox();

        public override string LabelText
        {
            get => checkbox.LabelText;
            set => checkbox.LabelText = value;
        }
    }
}
