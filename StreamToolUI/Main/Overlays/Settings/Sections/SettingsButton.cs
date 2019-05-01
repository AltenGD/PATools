using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Cursor;
using StreamToolUI.Main.Graphics.UI;

namespace StreamToolUI.Main.Overlays.Settings.Sections
{
    public class SettingsButton : StreamGameButton, IHasTooltip
    {
        public SettingsButton()
        {
            RelativeSizeAxes = Axes.X;
            Padding = new MarginPadding { Left = SettingsOverlay.CONTENT_MARGINS, Right = SettingsOverlay.CONTENT_MARGINS };
        }

        public string TooltipText { get; set; }

        public override IEnumerable<string> FilterTerms
        {
            get
            {
                if (TooltipText != null)
                    return base.FilterTerms.Append(TooltipText);

                return base.FilterTerms;
            }
        }
    }
}
