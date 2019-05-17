using System.Collections.Generic;
using System.ComponentModel;
using osu.Framework.Input.Bindings;

namespace StreamToolUI.Main.Containers
{
    public class GlobalActionContainer : KeyBindingContainer<GlobalAction>
    {
        public override IEnumerable<KeyBinding> DefaultKeyBindings => new[]
        {
            new KeyBinding(InputKey.Tab, GlobalAction.ToggleSettings)
        };

        public GlobalActionContainer(KeyCombinationMatchingMode keyCombinationMatchingMode = KeyCombinationMatchingMode.Exact, SimultaneousBindingMode simultaneousBindingMode = SimultaneousBindingMode.All)
            : base(simultaneousBindingMode, keyCombinationMatchingMode)
        {
        }
    }
    public enum GlobalAction
    {
        [Description("Toggle settings")]
        ToggleSettings,
    }
}
