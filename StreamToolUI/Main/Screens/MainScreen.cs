using osu.Framework.Allocation;
using osu.Framework.Graphics;
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
                new BeatmapLevelListing { RelativeSizeAxes = Axes.Both },
            });

            LoadComponentAsync(background = new BackgroundScreenDefault());
        }
    }
}
