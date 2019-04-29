using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osuTK.Graphics;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using StreamToolUI.Main.Graphics.Colors;

namespace StreamToolUI.Main.Graphics.UI
{
    public  class StreamGameTextBox : TextBox
    {
        protected override float LeftRightPadding => 10;

        public StreamGameTextBox()
        {
            Height = 40;
            TextContainer.Height = 0.5f;
            CornerRadius = 5;

            Current.DisabledChanged += disabled => { Alpha = disabled ? 0.3f : 1; };
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            BackgroundUnfocused = Color4.Black.Opacity(0.5f);
            BackgroundFocused = Color4.Black.Opacity(0.8f);
            BackgroundCommit = BorderColour = StreamToolColors.Primary;
        }

        protected override void OnFocus(FocusEvent e)
        {
            this.TransformTo(nameof(BorderThickness), 3f, 300, Easing.OutExpo);
            base.OnFocus(e);
        }

        protected override void OnFocusLost(FocusLostEvent e)
        {
            this.TransformTo(nameof(BorderThickness), 0f, 300, Easing.OutExpo);
            base.OnFocusLost(e);
        }
    }
}
