// -----------------------------------------------------------------------
// <copyright file="Mixed.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace DamageIndicator.Handlers
{
    using System.Collections.Generic;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using static DamageIndicator;

    /// <summary>
    /// Handles player events.
    /// </summary>
    internal sealed class Mixed
    {
        /// <inheritdoc cref="Handlers.Mixed.OnHurting(HurtingEventArgs)"/>
        public void OnHurting(HurtingEventArgs ev)
        {
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

            ev.Attacker.ShowHint(Instance.Config.Hint.Replace("%damage", ev.Amount.ToString()).Replace("%player", ev.Target.Nickname));
        }
    }
}
