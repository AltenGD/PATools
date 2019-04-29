using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Configuration;
using osu.Framework.IO.Stores;
using osu.Framework.Platform;

namespace StreamToolUI.Main
{
    public class StreamGameBase : Game
    {
        private DependencyContainer dependencies;
        private Storage storage;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        public StreamGameBase()
        {
            Name = @"PA Streaming Tool";

            storage = new NativeStorage("PAStreamTool");
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Resources.AddStore(new NamespacedResourceStore<byte[]>(new DllResourceStore(@"StreamToolUI.dll"), @"Resources"));

            dependencies.Cache(this);
            dependencies.Cache(storage);

            Fonts.AddStore(new GlyphStore(Resources, @"Fonts/purista"));
            Fonts.AddStore(new GlyphStore(Resources, @"Fonts/Neogrey Medium"));
            Fonts.AddStore(new GlyphStore(Resources, @"Fonts/Neogrey"));

            dependencies.Cache(Fonts);
        }

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);

            var desktopWindow = host.Window as DesktopGameWindow;

            if (desktopWindow != null)
                desktopWindow.Title = "PA Streaming Tool";
        }
    }
}
