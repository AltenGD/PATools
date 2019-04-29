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
using StreamToolUI.Main.Screens.Backgrounds;

namespace StreamToolUI.Main.Screens
{
    public class MainScreen : StreamScreen
    {
        private BackgroundScreenDefault background;

        protected override BackgroundScreen CreateBackground() => background;

        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                new BeatmapLevelListing
                {
                    RelativeSizeAxes = Axes.Both
                }
            });

            LoadComponentAsync(background = new BackgroundScreenDefault());
        }
    }
}
