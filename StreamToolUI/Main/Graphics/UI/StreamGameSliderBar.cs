﻿using System;
using System.Globalization;
using osuTK;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using StreamToolUI.Main.Graphics.Colors;

namespace StreamToolUI.Main.Graphics.UI
{
    public class StreamGameSliderBar<T> : SliderBar<T>, IHasTooltip
        where T : struct, IEquatable<T>, IComparable, IConvertible
    {
        private const int max_decimal_digits = 5;

        protected readonly Nub Nub;
        private readonly Box leftBox;
        private readonly Box rightBox;

        public virtual string TooltipText { get; private set; }

        public StreamGameSliderBar()
        {
            Height = 12;
            RangePadding = 20;

            Children = new Drawable[]
            {
                leftBox = new Box
                {
                    Height = 2,
                    EdgeSmoothness = new Vector2(0, 0.5f),
                    Position = new Vector2(2, 0),
                    RelativeSizeAxes = Axes.None,
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                    Colour = StreamToolColors.Primary
                },
                rightBox = new Box
                {
                    Height = 2,
                    EdgeSmoothness = new Vector2(0, 0.5f),
                    Position = new Vector2(-2, 0),
                    RelativeSizeAxes = Axes.None,
                    Anchor = Anchor.CentreRight,
                    Origin = Anchor.CentreRight,
                    Alpha = 0.5f,
                    Colour = StreamToolColors.Primary
                },
                Nub = new Nub
                {
                    Origin = Anchor.Centre,
                    Anchor = Anchor.CentreLeft
                }
            };

            Current.DisabledChanged += disabled => { Alpha = disabled ? 0.3f : 1; };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            CurrentNumber.BindValueChanged(current => updateTooltipText(current.NewValue), true);
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            Nub.Current.Value = true;
            return base.OnMouseDown(e);
        }

        protected override bool OnMouseUp(MouseUpEvent e)
        {
            Nub.Current.Value = false;
            return base.OnMouseUp(e);
        }

        private void updateTooltipText(T value)
        {
            if (CurrentNumber.IsInteger)
                TooltipText = ((int)Convert.ChangeType(value, typeof(int))).ToString("N0");
            else
            {
                double floatValue = (double)Convert.ChangeType(value, typeof(double));
                double floatMinValue = (double)Convert.ChangeType(CurrentNumber.MinValue, typeof(double));
                double floatMaxValue = (double)Convert.ChangeType(CurrentNumber.MaxValue, typeof(double));

                if (floatMaxValue == 1 && floatMinValue >= -1)
                    TooltipText = floatValue.ToString("P0");
                else
                {
                    var decimalPrecision = normalise((decimal)Convert.ChangeType(CurrentNumber.Precision, typeof(decimal)), max_decimal_digits);

                    // Find the number of significant digits (we could have less than 5 after normalize())
                    var significantDigits = findPrecision(decimalPrecision);

                    TooltipText = floatValue.ToString($"N{significantDigits}");
                }
            }
        }

        protected override void UpdateAfterChildren()
        {
            base.UpdateAfterChildren();
            leftBox.Scale = new Vector2(MathHelper.Clamp(
                Nub.DrawPosition.X - Nub.DrawWidth / 2, 0, DrawWidth), 1);
            rightBox.Scale = new Vector2(MathHelper.Clamp(
                DrawWidth - Nub.DrawPosition.X - Nub.DrawWidth / 2, 0, DrawWidth), 1);
        }

        protected override void UpdateValue(float value)
        {
            Nub.MoveToX(RangePadding + UsableWidth * value, 250, Easing.OutQuint);
        }

        /// <summary>Removes all non-significant digits, keeping at most a requested number of decimal digits.</summary>
        /// <param name="d">The decimal to normalize.</param>
        /// <param name="sd">The maximum number of decimal digits to keep. The final result may have fewer decimal digits than this value.</param>
        /// <returns>The normalised decimal.</returns>
        private decimal normalise(decimal d, int sd)
            => decimal.Parse(Math.Round(d, sd).ToString(string.Concat("0.", new string('#', sd)), CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);

        /// <summary>Finds the number of digits after the decimal.</summary>
        /// <param name="d">The value to find the number of decimal digits for.</param>
        /// <returns>The number decimal digits.</returns>
        private int findPrecision(decimal d)
        {
            int precision = 0;
            while (d != Math.Round(d))
            {
                d *= 10;
                precision++;
            }

            return precision;
        }
    }
}
