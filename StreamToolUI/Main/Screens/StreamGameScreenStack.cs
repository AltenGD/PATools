using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using StreamToolUI.Main.Containers;

namespace StreamToolUI.Main.Screens
{
    public class StreamGameScreenStack : ScreenStack
    {
        [Cached]
        private BackgroundScreenStack backgroundScreenStack;

        private ParallaxContainer parallaxContainer;

        protected float ParallaxAmount => parallaxContainer.ParallaxAmount;

        public StreamGameScreenStack()
        {
            initializeStack();
        }

        public StreamGameScreenStack(IScreen baseScreen)
            : base(baseScreen)
        {
            initializeStack();
        }

        private void initializeStack()
        {
            InternalChild = parallaxContainer = new ParallaxContainer
            {
                RelativeSizeAxes = Axes.Both,
                Child = backgroundScreenStack = new BackgroundScreenStack { RelativeSizeAxes = Axes.Both },
            };
        }
    }
}
