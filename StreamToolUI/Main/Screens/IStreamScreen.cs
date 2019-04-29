using osu.Framework.Bindables;
using osu.Framework.Screens;

namespace StreamToolUI.Main.Screens
{
    public interface IStreamScreen : IScreen
    {
        /// <summary>
        /// The amount of parallax to be applied while this screen is displayed.
        /// </summary>
        float BackgroundParallaxAmount { get; }
    }
}