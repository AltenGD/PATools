using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Threading;

namespace StreamToolUI.Main.Screens.Backgrounds
{
    public class BackgroundScreenDefault : BackgroundScreen
    {
        private Background background;

        private string backgroundName = @"bg";

        [BackgroundDependencyLoader]
        private void load()
        {
            display(createBackground());
        }

        private void display(Background newBackground)
        {
            background?.FadeOut(800, Easing.InOutSine);
            background?.Expire();

            AddInternal(background = newBackground);
        }

        private ScheduledDelegate nextTask;

        public void Next()
        {
            nextTask?.Cancel();
            nextTask = Scheduler.AddDelayed(() => { LoadComponentAsync(createBackground(), display); }, 100);
        }

        private Background createBackground()
        {
            Background newBackground;

            newBackground = new Background(backgroundName);

            return newBackground;
        }
    }
}
