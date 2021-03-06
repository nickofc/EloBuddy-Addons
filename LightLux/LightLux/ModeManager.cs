﻿using EloBuddy;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Utils;
using LightLux.Modes;
using System;
using System.Collections.Generic;

namespace LightLux
{
    public static class ModeManager
    {
        private static List<ModeBase> Modes { get; set; }

        static ModeManager()
        {
            Modes = new List<ModeBase>();
            Modes.AddRange(new ModeBase[]
            {
                new PermaActive(),
                new Combo(),
                new Harass(),
                new LaneClear(),
            });

            //Listen to events we need
            //Game.OnTick += OnTick;
            Game.OnUpdate += OnTick;
        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }

        private static void OnTick(EventArgs args)
        {
            if (Program._Player.IsDead)
                return;
            // Execute all modes
            Modes.ForEach(mode =>
            {
                try
                {
                    // Precheck if the mode should be executed
                    if (mode.ShouldBeExecuted())
                    {
                        // Execute the mode
                        mode.Execute();
                    }
                }
                catch (Exception e)
                {
                    // Please enable the debug window to see and solve the exceptions that might occur!
                    Logger.Log(LogLevel.Error, "Error executing mode '{0}'\n{1}", mode.GetType().Name, e);
                }
            });
        }
    }
}