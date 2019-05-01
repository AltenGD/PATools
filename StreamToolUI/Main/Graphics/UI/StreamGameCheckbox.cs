using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Sample;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;
using StreamToolUI.Main.Graphics.Sprites;

namespace StreamToolUI.Main.Graphics.UI
{
    public class StreamGameCheckbox : Checkbox
    {
        private Bindable<bool> bindable;

        public Bindable<bool> Bindable
        {
            set
            {
                bindable = value;
                Current.BindTo(bindable);
            }
        }

        public Color4 CheckedColor { get; set; } = Color4.Cyan;
        public Color4 UncheckedColor { get; set; } = Color4.White;
        public int FadeDuration { get; set; }

        public string LabelText
        {
            get => labelSpriteText?.Text;
            set
            {
                if (labelSpriteText != null)
                {
                    labelSpriteText.Font = StreamGameFont.GetFont(size: 25);
                    labelSpriteText.Text = value;
                }
            }
        }

        public MarginPadding LabelPadding
        {
            get => labelSpriteText?.Padding ?? new MarginPadding();
            set
            {
                if (labelSpriteText != null)
                    labelSpriteText.Padding = value;
            }
        }

        protected readonly Nub Nub;

        private readonly SpriteText labelSpriteText;

        public StreamGameCheckbox()
        {
            AutoSizeAxes = Axes.Y;
            RelativeSizeAxes = Axes.X;

            Children = new Drawable[]
            {
                labelSpriteText = new SpriteText(),
                Nub = new Nub
                {
                    Anchor = Anchor.CentreRight,
                    Origin = Anchor.CentreRight,
                    Margin = new MarginPadding { Right = 5 },
                }
            };

            Current.DisabledChanged += disabled =>
            {
                Alpha = disabled ? 0.3f : 1;
            };

            Nub.Current.BindTo(Current);
        }
    }
}
