using osu.Framework.Graphics.Cursor;
using System.Collections.Generic;
using System.Linq;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osuTK;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osu.Framework.Screens;
using StreamToolUI.Main.Beatmap;
using StreamingTool.Main.Properties.PA;
using System;
using System.Threading.Tasks;
using osu.Framework.Graphics.Textures;
using System.IO;
using Newtonsoft.Json;
using StreamToolUI.Main.Graphics.Colors;
using osu.Framework.Platform;
using osu.Framework.Graphics.Colour;
using osuTK.Graphics;

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
