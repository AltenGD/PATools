using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;
using StreamToolUI.Main.Graphics.Colors;

namespace StreamToolUI.Main.Beatmap.Components
{
    public class PlayButton : Container
    {
        public readonly BindableBool Playing = new BindableBool();
        public Track Preview { get; private set; }

        [Resolved]
        private AudioManager manager { get; set; }

        private Color4 hoverColour;
        private readonly SpriteIcon icon;

        private const float transition_duration = 500;

        public PlayButton(Track track)
        {
            Preview = track;

            Add(icon = new SpriteIcon
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                FillMode = FillMode.Fit,
                RelativeSizeAxes = Axes.Both,
                Icon = FontAwesome.Solid.Play,
            });

            Playing.ValueChanged += playingStateChanged;

            hoverColour = StreamToolColors.FromHex("FFC634");
        }

        protected override bool OnClick(ClickEvent e)
        {
            Playing.Toggle();
            return true;
        }

        protected override bool OnHover(HoverEvent e)
        {
            icon.FadeColour(hoverColour, 120, Easing.InOutQuint);
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            if (!Playing.Value)
                icon.FadeColour(Color4.White, 120, Easing.InOutQuint);
            base.OnHoverLost(e);
        }

        private void playingStateChanged(ValueChangedEvent<bool> e)
        {
            icon.Icon = e.NewValue ? FontAwesome.Solid.Stop : FontAwesome.Solid.Play;
            icon.FadeColour(e.NewValue || IsHovered ? hoverColour : Color4.White, 120, Easing.InOutQuint);

            if (e.NewValue)
            {
                if (Preview != null)
                {
                    manager.AddItem(Preview);
                    Preview.Start();
                    return;
                }
            }
            else
            {
                Preview?.Stop();
                manager.UnregisterItem(Preview);
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            Playing.Value = false;
        }
    }
}
