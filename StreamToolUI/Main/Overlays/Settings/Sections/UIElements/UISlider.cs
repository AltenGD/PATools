using osu.Framework.Allocation;
using osu.Framework.Graphics;
using StreamToolUI.Main.Configuration;
using static StreamToolUI.Main.Configuration.StreamGameConfigManager;

namespace StreamToolUI.Main.Overlays.Settings.Sections.UIElements
{
    public class UISlider : SettingsSubsection
    {
        protected override string Header => "Slider";

        [BackgroundDependencyLoader]
        private void load(StreamGameConfigManager config)
        {
            Children = new Drawable[]
            {
                new SettingsSlider<double> { LabelText = "Slider at 10.0", Bindable = config.GetBindable<double>(StreamGameSettings.Slider1), KeyboardStep = 0.1f },
                new SettingsSlider<double> { LabelText = "Slider at 1.0", Bindable = config.GetBindable<double>(StreamGameSettings.Slider2), KeyboardStep = 0.01f },
                new SettingsSlider<double> { LabelText = "Slider at 0.5", Bindable = config.GetBindable<double>(StreamGameSettings.Slider3), KeyboardStep = 0.01f },
            };
        }
    }
}
