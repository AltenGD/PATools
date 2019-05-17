using osu.Framework.Graphics.Cursor;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using StreamToolUI.Main.Graphics.Colors;
using osu.Framework.Platform;

namespace StreamToolUI.Main.Graphics.Sprites
{
    public class SpriteTextLink : SpriteText, IHasTooltip
    {
        private GameHost host;
        private string url;

        public string TooltipText { get; set; }

        public SpriteTextLink(string url)
            => this.url = url;

        [BackgroundDependencyLoader]
        private void load(GameHost host)
        {
            Colour = StreamToolColors.Link;
            this.host = host;
        }

        protected override bool OnClick(ClickEvent e)
        {
            if (url != null)
                host.OpenUrlExternally(url);

            return base.OnClick(e);
        }

        protected override bool OnHover(HoverEvent e)
        {
            this.FadeColour(StreamToolColors.LinkBright, 200, Easing.OutExpo);
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            this.FadeColour(StreamToolColors.Link, 200, Easing.OutExpo);
            base.OnHoverLost(e);
        }
    }
}
