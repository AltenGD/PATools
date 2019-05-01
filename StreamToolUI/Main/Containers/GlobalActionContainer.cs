using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Input;
using osu.Framework.Input.Bindings;
using static StreamToolUI.Main.Containers.GlobalActionContainer;

namespace StreamToolUI.Main.Containers
{
    public class GlobalActionContainer : KeyBindingContainer<GlobalAction>, IHandleGlobalInput
    {
        private readonly Drawable handler;

        public GlobalActionContainer(StreamGameBase game)
        {
            if (game is IKeyBindingHandler<GlobalAction>)
                handler = game;
        }

        public override IEnumerable<KeyBinding> DefaultKeyBindings => new[]
        {
            new KeyBinding(InputKey.Tab, GlobalAction.ToggleSettings)
        };

        public IEnumerable<KeyBinding> GlobalKeyBinding => new[]
        {
            new KeyBinding(new[] { InputKey.Control, InputKey.O }, GlobalAction.ToggleSettings)
        };

        protected override IEnumerable<Drawable> KeyBindingInputQueue =>
            handler == null ? base.KeyBindingInputQueue : base.KeyBindingInputQueue.Prepend(handler);

        public enum GlobalAction
        {
            [Description("Toggle settings")]
            ToggleSettings,
        }
    }
}
