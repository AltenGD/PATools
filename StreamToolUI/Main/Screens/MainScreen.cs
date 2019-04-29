using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osu.Framework.Screens;
using osuTK;
using StreamToolUI.Main.Beatmap;
using StreamingTool.Main.Properties.PA;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using osu.Framework.Graphics.Textures;
using System.IO;
using Newtonsoft.Json;
using StreamToolUI.Main.Screens.Components;

namespace StreamToolUI.Main.Screens
{
    public class MainScreen : Screen
    {
        private Box background;

        public MainScreen()
        {
            AddRangeInternal(new Drawable[]
            {
                background = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    FillMode = FillMode.Fill,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre
                },
                new BeatmapLevelListing
                {
                    RelativeSizeAxes = Axes.Both
                }
            });
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore tex)
        {
            background.Texture = tex.Get("bg");
        }
    }
}
