using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Graphics;

namespace StreamToolUI.Main.Overlays.Settings.Sections.Audio
{
    public class AudVolume : SettingsSubsection
    {
        protected override string Header => "Volume";

        [BackgroundDependencyLoader]
        private void load(AudioManager audio)
        {
            Children = new Drawable[]
            {
                new SettingsSlider<double> { LabelText = "Master", Bindable = audio.Volume, KeyboardStep = 0.01f },
                new SettingsSlider<double> { LabelText = "Effect", Bindable = audio.VolumeSample, KeyboardStep = 0.01f },
                new SettingsSlider<double> { LabelText = "Music", Bindable = audio.VolumeTrack, KeyboardStep = 0.01f }
            };
        }
    }
}
