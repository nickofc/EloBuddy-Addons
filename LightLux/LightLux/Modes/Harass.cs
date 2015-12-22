﻿using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace LightLux.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            // TODO: Add harass logic here
            if (Config.Modes.Harass.UseE && Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical, Player.Instance.Position);
                if (target.IsValidTarget())
                {
                    var qPrediction = Q.GetPrediction(target);
                    if (qPrediction.HitChancePercent <= Program.hitchance && target != null)
                    {
                        Q.Cast(qPrediction.CastPosition);
                    }
                }
            }
            if (Config.Modes.Harass.UseE && E.IsReady())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Magical, Player.Instance.Position);
                if (target.IsValidTarget())
                {
                    var ePrediction = E.GetPrediction(target);
                    if (ePrediction.HitChancePercent <= Program.hitchance && target != null)
                    {
                        E.Cast(ePrediction.CastPosition);
                    }
                }
            }
        }
    }
}