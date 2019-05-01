using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Bindables;
using osu.Framework.Configuration;
using osu.Framework.IO.Stores;
using osu.Framework.Platform;
using StreamToolUI.Main.Configuration;
using osu.Framework.Graphics.Performance;
using static StreamToolUI.Main.Configuration.StreamGameConfigManager;
using osu.Framework.Logging;

namespace StreamToolUI.Main
{
    public class StreamGameBase : Game
    {
        protected StreamGameConfigManager LocalConfig;

        protected Bindable<bool> fpsDisplayVisible;

        protected DependencyContainer dependencies;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        public StreamGameBase()
        {
            Name = @"PA Streaming Tool";
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Resources.AddStore(new NamespacedResourceStore<byte[]>(new DllResourceStore(@"StreamToolUI.dll"), @"Resources"));

            dependencies.CacheAs(LocalConfig);

            dependencies.Cache(this);

            Fonts.AddStore(new GlyphStore(Resources, @"Fonts/purista"));
            Fonts.AddStore(new GlyphStore(Resources, @"Fonts/Neogrey Medium"));
            Fonts.AddStore(new GlyphStore(Resources, @"Fonts/Neogrey"));

            dependencies.Cache(Fonts);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            fpsDisplayVisible = LocalConfig.GetBindable<bool>(StreamGameSettings.ShowFpsDisplay);
            fpsDisplayVisible.ValueChanged += visible => { FrameStatisticsMode = visible.NewValue ? FrameStatisticsMode.Minimal : FrameStatisticsMode.None; };
            fpsDisplayVisible.TriggerChange();
        }

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);
            if (LocalConfig == null)
                LocalConfig = new StreamGameConfigManager(host.Storage);

            Logger.Log(LocalConfig != null ? "LocalConfig Loaded Sucessfully!" : "LocalConfig Loaded Unsucessfully.", level: LogLevel.Debug);

            var desktopWindow = host.Window as DesktopGameWindow;

            if (desktopWindow != null)
                desktopWindow.Title = "PA Streaming Tool";
        }
    }
}
