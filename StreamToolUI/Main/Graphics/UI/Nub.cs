using System;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;

namespace StreamToolUI.Main.Graphics.UI
{
    public class Nub : Container, IHasCurrentValue<bool>
    {
        public Nub()
        {
            Box fill;

            Size = new Vector2(30);

            BorderColour = Color4.White;
            BorderThickness = 4;

            Masking = true;

            Children = new[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.Transparent,
                    AlwaysPresent = true
                },
                fill = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Size = new Vector2(0.65f),
                    AlwaysPresent = true,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre
                }
            };

            if (Current.Value)
                fill.ScaleTo(1f, 300, Easing.OutExpo);
            else
                fill.ScaleTo(0f, 300, Easing.OutExpo);

            Current.ValueChanged += filled =>
            {
                if (filled.NewValue)
                    fill.ScaleTo(1f, 300, Easing.OutExpo);
                else
                    fill.ScaleTo(0f, 300, Easing.OutExpo);
            };
        }

        private readonly Bindable<bool> current = new Bindable<bool>();

        public Bindable<bool> Current
        {
            get => current;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                current.UnbindBindings();
                current.BindTo(value);
            }
        }
    }
}