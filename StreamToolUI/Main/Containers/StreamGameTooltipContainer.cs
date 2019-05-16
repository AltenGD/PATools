using osuTK;
using osuTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using StreamToolUI.Main.Graphics.Colors;
using osu.Framework.Graphics.Sprites;
using StreamToolUI.Main.Graphics.Sprites;
using static StreamToolUI.Main.Graphics.Sprites.StreamGameFont;

namespace StreamToolUI.Main.Containers
{
    public class StreamGameTooltipContainer : TooltipContainer
    {
        protected override ITooltip CreateTooltip() => new StreamGameTooltip();

        protected override double AppearDelay => (1 - CurrentTooltip.Alpha) * base.AppearDelay;

        private class StreamGameTooltip : Tooltip
        {
            private readonly Box background;
            private readonly SpriteText text;
            private bool instantMovement = true;

            public override string TooltipText
            {
                set
                {
                    if (value == text.Text) return;

                    text.Text = value;

                    if (IsPresent)
                    {
                        AutoSizeDuration = 250;
                        background.FlashColour(StreamToolColors.FromHex("2f2f2f"), 1000, Easing.OutQuint);
                    }
                    else
                        AutoSizeDuration = 0;
                }
            }

            public StreamGameTooltip()
            {
                AutoSizeEasing = Easing.OutQuint;

                CornerRadius = 5;
                Masking = true;
                EdgeEffect = new EdgeEffectParameters
                {
                    Type = EdgeEffectType.Shadow,
                    Colour = Color4.Black.Opacity(40),
                    Radius = 5,
                };
                Children = new Drawable[]
                {
                    background = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Alpha = 0.9f,
                        Colour = StreamToolColors.FromHex("1f1f1f")
                    },
                    text = new SpriteText
                    {
                        Padding = new MarginPadding(5),
                        Font = GetFont(size:25)
                    }
                };
            }

            protected override void PopIn()
            {
                instantMovement |= !IsPresent;
                this.FadeIn(500, Easing.OutQuint);
            }

            protected override void PopOut() => this.Delay(150).FadeOut(500, Easing.OutQuint);

            public override void Move(Vector2 pos)
            {
                if (instantMovement)
                {
                    Position = pos;
                    instantMovement = false;
                }
                else
                {
                    this.MoveTo(pos, 200, Easing.OutQuint);
                }
            }
        }
    }
}
