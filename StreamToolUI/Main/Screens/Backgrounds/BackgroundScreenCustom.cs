using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StreamToolUI.Main.Screens.Backgrounds
{
    public class BackgroundScreenCustom : BackgroundScreen
    {
        private readonly FileStream texture;
        private readonly string textureName;

        public BackgroundScreenCustom(FileStream texture)
        {
            this.texture = texture;
            AddInternal(new Background(texture));
        }

        public BackgroundScreenCustom(string textureName)
        {
            this.textureName = textureName;
            AddInternal(new Background(textureName));
        }

        public override bool Equals(BackgroundScreen other)
        {
            var backgroundScreenCustom = other as BackgroundScreenCustom;
            if (backgroundScreenCustom == null) return false;

            return base.Equals(other) && texture == backgroundScreenCustom.texture || base.Equals(other) && textureName == backgroundScreenCustom.textureName;
        }
    }
}
