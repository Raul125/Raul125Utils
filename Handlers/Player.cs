// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="Raul125">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Raul125Utils.Handlers
{
    using System.Collections.Generic;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using static Raul125Utils;

    /// <summary>
    /// Handles player events.
    /// </summary>
    internal sealed class Player
    {
        /// <inheritdoc cref="Handlers.Player.OnHurting(HurtingEventArgs)"/>
        public void OnHurting(HurtingEventArgs ev)
        {
            // DamageHint Part
            if (Instance.Config.DamageHintIsEnabled == false)
            {
                return;
            }

            if (ev.IsAllowed == false)
            {
                return;
            }

            if (ev.Target == null)
            {
                return;
            }

            if (ev.Target.IsDead || ev.Target.IsInvisible || ev.Amount < 0)
            {
                return;
            }

            ev.Attacker.ShowHint(Instance.Config.DamageHint.Replace("%damage", ev.Amount.ToString()).Replace("%player", ev.Target.Nickname), Instance.Config.DamageHintTime);
        }
    }
}
