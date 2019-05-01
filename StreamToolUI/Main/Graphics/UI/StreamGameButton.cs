using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osuTK.Graphics;
using StreamToolUI.Main.Graphics.Colors;
using System.Collections.Generic;
using static StreamToolUI.Main.Graphics.Sprites.StreamGameFont;

namespace StreamToolUI.Main.Graphics.UI
{
    public class StreamGameButton : Button, IFilterable
    {
        private Box hover;

        public StreamGameButton()
        {
            Height = 40;

            Content.Masking = true;
            Content.CornerRadius = 5;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            BackgroundColour = StreamToolColors.Primary;

            AddRange(new Drawable[]
            {
                hover = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Blending = BlendingMode.Additive,
                    Colour = Color4.White.Opacity(0.1f),
                    Alpha = 0,
                    Depth = -1
                }
            });
        }

        protected override bool OnHover(HoverEvent e)
        {
            hover.FadeIn(200);
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            hover.FadeOut(200);
            base.OnHoverLost(e);
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            Content.ScaleTo(0.9f, 4000, Easing.OutQuint);
            return base.OnMouseDown(e);
        }

        protected override bool OnMouseUp(MouseUpEvent e)
        {
            Content.ScaleTo(1, 1000, Easing.OutElastic);
            return base.OnMouseUp(e);
        }

        protected override SpriteText CreateText() => new SpriteText
        {
            Depth = -1,
            Origin = Anchor.Centre,
            Anchor = Anchor.Centre,
            Font = GetFont(size: 30)
        };

        public virtual IEnumerable<string> FilterTerms => new[] { Text };

        public bool MatchingFilter
        {
            set => this.FadeTo(value ? 1 : 0);
        }

        public bool FilteringActive { get; set; }
    }
}
