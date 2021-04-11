// -----------------------------------------------------------------------
// <copyright file="Server.cs" company="PlaceholderCompany">
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
    /// Handles player events.
    /// </summary>
    internal sealed class Server
    {
        private Dictionary<Exiled.API.Features.Player, bool> ordersSystemCooldown = new Dictionary<Exiled.API.Features.Player, bool>();

        /// <inheritdoc cref="Handlers.Server.OnSendingConsoleCommand(SendingConsoleCommandEventArgs)"/>
        public void OnSendingConsoleCommand(SendingConsoleCommandEventArgs ev)
        {
            if (Raul125Utils.Instance.Config.OrdersSystemIsEnabled == false)
            {
                return;
            }

            if (ev.Name == "c")
            {
                ev.IsAllowed = false;

                if (this.ordersSystemCooldown.TryGetValue(ev.Player, out bool cooldown))
                {
                    ev.ReturnMessage = " <b><color=red>Don't spam...</color></b>";
                    return;
                }

                if (ev.Player.Role == RoleType.NtfCommander)
                {
                    foreach (Exiled.API.Features.Player ply in Exiled.API.Features.Player.List.Where(x => x.Team == Team.MTF && x.IsAlive && x.ReferenceHub.characterClassManager.NetworkCurUnitName == ev.Player.ReferenceHub.characterClassManager.NetworkCurUnitName).ToList())
                    {
                        if (Raul125Utils.Instance.Config.OrdersSystemHint)
                        {
                            ev.Player.ShowHint(ev.Arguments.ToString(), Raul125Utils.Instance.Config.OrdersSystemTime);
                        }
                        else
                        {
                            ev.Player.Broadcast((ushort)Raul125Utils.Instance.Config.OrdersSystemTime, ev.Arguments.ToString());
                        }
                    }

                    ev.ReturnMessage = " <b><color=green>Sending Order...</color></b>";
                    this.ordersSystemCooldown[ev.Player] = true;
                    Timing.CallDelayed(Raul125Utils.Instance.Config.OrdersSystemCooldownTime, () =>
                    {
                        this.ordersSystemCooldown[ev.Player] = false;
                        this.ordersSystemCooldown.Remove(ev.Player);
                    });
                }
                else
                {
                    ev.ReturnMessage = " <b><color=red>You aren't an <color=blue>NtfCommander</color></color></b>";
                }
            }
        }
    }
}
