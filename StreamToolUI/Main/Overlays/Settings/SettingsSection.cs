using osuTK;
using osuTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics.Sprites;
using StreamToolUI.Main.Graphics.Sprites;
using StreamToolUI.Main.Graphics.Colors;

namespace StreamToolUI.Main.Overlays.Settings
{
    public abstract class SettingsSection : Container, IHasFilterableChildren
    {
        protected FillFlowContainer FlowContent;
        protected override Container<Drawable> Content => FlowContent;

        public abstract IconUsage Icon { get; }
        public abstract string Header { get; }

        public IEnumerable<IFilterable> FilterableChildren => Children.OfType<IFilterable>();
        public IEnumerable<string> FilterTerms => new[] { Header };

        private const int header_size = 46;
        private const int header_margin = 15;
        private const int border_size = 2;

        public bool MatchingFilter
        {
            set => this.FadeTo(value ? 1 : 0);
        }

        public bool FilteringActive { get; set; }

        protected SettingsSection()
        {
            Margin = new MarginPadding { Top = 20 };
            AutoSizeAxes = Axes.Y;
            RelativeSizeAxes = Axes.X;

            FlowContent = new FillFlowContainer
            {
                Margin = new MarginPadding
                {
                    Top = header_size + header_margin
                },
                Direction = FillDirection.Vertical,
                Spacing = new Vector2(0, 30),
                AutoSizeAxes = Axes.Y,
                RelativeSizeAxes = Axes.X,
            };
        }
        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                new Box
                {
                    Colour = new Color4(0, 0, 0, 255),
                    RelativeSizeAxes = Axes.X,
                    Height = border_size,
                },
                new Container
                {
                    Padding = new MarginPadding
                    {
                        Top = 20 + border_size,
                        Bottom = 10,
                    },
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Font = StreamGameFont.GetFont(size: header_size),
                            Text = Header,
                            Colour = StreamToolColors.FromHex("FFC634"),
                            Margin = new MarginPadding { Left = SettingsOverlay.CONTENT_MARGINS, Right = SettingsOverlay.CONTENT_MARGINS }
                        },
                        FlowContent
                    }
                },
            });
        }
    }
}
