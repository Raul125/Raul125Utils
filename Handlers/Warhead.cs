// -----------------------------------------------------------------------
// <copyright file="Warhead.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Raul125Utils.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;

    /// <summary>
    /// Handles warhead events.
    /// </summary>
    internal sealed class Warhead
    {
        /// <inheritdoc cref="Handlers.Server.OnSendingConsoleCommand(SendingConsoleCommandEventArgs)"/>
        public void OnStarting(StartingEventArgs ev)
        {
            if (Raul125Utils.Instance.Config.DetonationRequirementIsEnabled == false)
            {
                return;
            }

            if (ev.IsAuto)
            {
                return;
            }

            if (ev.Player == null)
            {
                return;
            }

            if (ev.Player.IsHost)
            {
                return;
            }

            ev.IsAllowed = false;

            if (Exiled.API.Features.Map.ActivatedGenerators > Raul125Utils.Instance.Config.DetonationRequirementGenerators - 1)
            {
                ev.IsAllowed = true;
            }

            if (ev.IsAllowed == false)
            {
                int gener = Raul125Utils.Instance.Config.DetonationRequirementGenerators - Exiled.API.Features.Map.ActivatedGenerators;
                if (gener == 1)
                {
                    ev.Player.ShowHint($"<color=red>You need to activate <color=green><b>{gener}</b></color> more generator to start the warhead</color>", 5f);
                }
                else
                {
                    ev.Player.ShowHint($"<color=red>You need to activate <color=green><b>{gener}</b></color> more generators to start the warhead</color>", 5f);
                }
            }
        }
    }
}
