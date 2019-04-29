using System;
using osuTK.Graphics;

namespace StreamToolUI.Main.Graphics.Colors
{
    /// <summary>Provides the colors of the application and functions related to them.</summary>
    public static class StreamToolColors
    {
        /// <summary>Returns a <see cref="Color4"/> value from a hex string.</summary>
        /// <param name="hex">The hex string of the color.</param>
        public static Color4 FromHex(string hex)
        {
            if (hex[0] == '#')
                hex = hex.Substring(1);

            switch (hex.Length)
            {
                case 3:
                    return new Color4((byte)(getByte(0, 1) * 17), (byte)(getByte(1, 1) * 17), (byte)(getByte(2, 1) * 17), 255);
                case 6:
                    return new Color4(getByte(0, 2), getByte(2, 2), getByte(4, 2), 255);
                default:
                    throw new ArgumentException(@"Invalid hex string length!");
            }

            byte getByte(int n, int k) => Convert.ToByte(hex.Substring(n, k), 16);
        }

        public static Color4 Easy => FromHex("64B5F6");

        public static Color4 Normal => FromHex("6CCBCF");

        public static Color4 Hard => FromHex("FFB039");

        public static Color4 Expert => FromHex("E47272");

        public static Color4 ExpertPlus => FromHex("373737");

        public static Color4 Unknown => FromHex("BDBDBD");

        public static Color4 Link => FromHex("5AB0FF");

        public static Color4 LinkBright => FromHex("7ccaff");

        public static Color4 Primary => FromHex("E636B6");

        public static Color4 Used => FromHex("818181");
    }
}
