using osu.Framework.Graphics;
using StreamToolUI.Main.Graphics.UI;

namespace StreamToolUI.Main.Overlays.Settings
{
    public class SettingsTextBox : SettingsItem<string>
    {
        protected override Drawable CreateControl() => new StreamGameTextBox
        {
            Margin = new MarginPadding { Top = 5 },
            RelativeSizeAxes = Axes.X,
        };
    }
}
