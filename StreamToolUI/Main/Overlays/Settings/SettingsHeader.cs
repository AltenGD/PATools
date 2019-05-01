using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using StreamToolUI.Main.Graphics.Colors;
using static StreamToolUI.Main.Graphics.Sprites.StreamGameFont;

namespace StreamToolUI.Main.Overlays.Settings
{
    public class SettingsHeader : Container
    {
        private readonly string heading;
        private readonly string subheading;

        public SettingsHeader(string heading, string subheading)
        {
            this.heading = heading;
            this.subheading = subheading;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;

            Children = new Drawable[]
            {
                new FillFlowContainer
                {
                    AutoSizeAxes = Axes.Y,
                    RelativeSizeAxes = Axes.X,
                    Direction = FillDirection.Vertical,
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Text = heading,
                            Font = GetFont(size: 60),
                            Margin = new MarginPadding
                            {
                                Left = SettingsOverlay.CONTENT_MARGINS,
                            },
                        },
                        new SpriteText
                        {
                            Colour = StreamToolColors.Primary,
                            Text = subheading,
                            Font = GetFont(size: 28),
                            Margin = new MarginPadding
                            {
                                Left = SettingsOverlay.CONTENT_MARGINS,
                                Bottom = 30
                            },
                        },
                    }
                }
            };
        }
    }
}
