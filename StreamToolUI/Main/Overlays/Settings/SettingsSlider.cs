using System;
using osu.Framework.Graphics;
using StreamToolUI.Main.Graphics.UI;

namespace StreamToolUI.Main.Overlays.Settings
{
    public class SettingsSlider<T> : SettingsSlider<T, StreamGameSliderBar<T>>
        where T : struct, IEquatable<T>, IComparable, IConvertible
    {
    }

    public class SettingsSlider<T, U> : SettingsItem<T>
        where T : struct, IEquatable<T>, IComparable, IConvertible
        where U : StreamGameSliderBar<T>, new()
    {
        protected override Drawable CreateControl() => new U
        {
            Margin = new MarginPadding { Top = 5, Bottom = 5 },
            RelativeSizeAxes = Axes.X
        };

        public bool TransferValueOnCommit
        {
            get => ((U)Control).TransferValueOnCommit;
            set => ((U)Control).TransferValueOnCommit = value;
        }

        public float KeyboardStep
        {
            get => ((U)Control).KeyboardStep;
            set => ((U)Control).KeyboardStep = value;
        }
    }
}
