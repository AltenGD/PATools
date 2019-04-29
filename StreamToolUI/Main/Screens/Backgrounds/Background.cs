using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using System.IO;

namespace StreamToolUI.Main.Screens.Backgrounds
{
    public class Background : BufferedContainer
    {
        public Sprite Sprite;
        private string textureName;
        private readonly FileStream texture;

        public Background(FileStream texture)
        {
            CacheDrawnFrameBuffer = true;

            this.texture = texture;
            RelativeSizeAxes = Axes.Both;

            Add(Sprite = new Sprite
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                FillMode = FillMode.Fill,
            });
        }

        public Background(string textureName)
        {
            CacheDrawnFrameBuffer = true;

            this.textureName = textureName;
            RelativeSizeAxes = Axes.Both;

            Add(Sprite = new Sprite
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                FillMode = FillMode.Fill,
            });
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            if (texture != null)
                Sprite.Texture = Texture.FromStream(texture);

            if (!string.IsNullOrEmpty(textureName))
                Sprite.Texture = textures.Get(textureName);
        }
    }
}
