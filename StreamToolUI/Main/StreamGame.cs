using osu.Framework.Graphics;
using osu.Framework.Logging;
using osu.Framework.Screens;
using StreamToolUI.Main.Screens;

namespace StreamToolUI.Main
{
    public class StreamGame : StreamGameBase
    {
        private ScreenStack stack;

        public StreamGame()
        {
            Children = new Drawable[]
            {
                stack = new ScreenStack
                {
                    RelativeSizeAxes = Axes.Both
                }
            };

            stack.ScreenPushed += screenPushed;
            stack.ScreenExited += screenExited;
        }

        protected override void LoadComplete()
        {
            stack.Push(new MainScreen());
            base.LoadComplete();
        }

        private void screenPushed(IScreen lastScreen, IScreen newScreen)
        {
            Logger.Log($"Screen pushed: {newScreen}");
        }

        private void screenExited(IScreen lastScreen, IScreen newScreen)
        {
            Logger.Log($"Screen exited: {newScreen}");

            if (newScreen == null)
                Exit();
        }
    }
}
