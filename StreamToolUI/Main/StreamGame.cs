﻿using osu.Framework;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osu.Framework.Screens;
using osu.Framework.Threading;
using StreamToolUI.Main.Containers;
using StreamToolUI.Main.Overlays;
using StreamToolUI.Main.Overlays.Settings;
using StreamToolUI.Main.Screens;
using StreamToolUI.Main.Tools;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StreamToolUI.Main
{
    public class StreamGame : StreamGameBase
    {
        private ScreenStack stack;

        private SettingsOverlay settings;

        public void ToggleSettings() => settings.ToggleVisibility();

        protected override void LoadComplete()
        {
            base.LoadComplete();
            AddRange(new Drawable[]
            {
                new StreamGameTooltipContainer()
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new GlobalActionContainer()
                        {
                            RelativeSizeAxes = Axes.Both,
                            Children = new Drawable[]
                            {
                                stack = new StreamGameScreenStack { RelativeSizeAxes = Axes.Both },
                                leftFloatingOverlayContent = new Container { RelativeSizeAxes = Axes.Both },
                            }
                        }
                    }
                }
            });

            stack.ScreenPushed += screenPushed;
            stack.ScreenExited += screenExited;

            stack.Push(new MainScreen());

            if (RuntimeInfo.OS == RuntimeInfo.Platform.Windows)
                Add(new SquirrelUpdateManager());

            loadComponentSingleFile(settings = new MainSettings(), leftFloatingOverlayContent.Add);
        }

        private void screenPushed(IScreen lastScreen, IScreen newScreen)
        {
            Logger.Log($"Screen pushed: {newScreen}");
        }

        private void screenExited(IScreen lastScreen, IScreen newScreen)
        {
            Logger.Log($"Screen exited: {newScreen}");

            if (newScreen == null)
                Exit();
        }

        private Task asyncLoadStream;

        private void loadComponentSingleFile<T>(T d, Action<T> add)
            where T : Drawable
        {
            // schedule is here to ensure that all component loads are done after LoadComplete is run (and thus all dependencies are cached).
            // with some better organisation of LoadComplete to do construction and dependency caching in one step, followed by calls to loadComponentSingleFile,
            // we could avoid the need for scheduling altogether.
            Schedule(() =>
            {
                var previousLoadStream = asyncLoadStream;

                //chain with existing load stream
                asyncLoadStream = Task.Run(async () =>
                {
                    if (previousLoadStream != null)
                        await previousLoadStream;

                    try
                    {
                        Logger.Log($"Loading {d}...", level: LogLevel.Debug);

                        // Since this is running in a separate thread, it is possible for OsuGame to be disposed after LoadComponentAsync has been called
                        // throwing an exception. To avoid this, the call is scheduled on the update thread, which does not run if IsDisposed = true
                        Task task = null;
                        var del = new ScheduledDelegate(() => task = LoadComponentAsync(d, add));
                        Scheduler.Add(del);

                        // The delegate won't complete if OsuGame has been disposed in the meantime
                        while (!IsDisposed && !del.Completed)
                            await Task.Delay(10);

                        // Either we're disposed or the load process has started successfully
                        if (IsDisposed)
                            return;

                        Debug.Assert(task != null);

                        await task;

                        Logger.Log($"Loaded {d}!", level: LogLevel.Debug);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                });
            });
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (e.ControlPressed && e.Key == osuTK.Input.Key.O)
                settings.ToggleVisibility();

            return base.OnKeyDown(e);
        }

        private Container leftFloatingOverlayContent;
    }
}
