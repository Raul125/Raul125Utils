// -----------------------------------------------------------------------
// <copyright file="Server.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
#pragma warning disable SA1200 // Using directives should be placed correctly
using Raul125Utils.Methods;
#pragma warning restore SA1200 // Using directives should be placed correctly

namespace Raul125Utils.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using Interactables.Interobjects.DoorUtils;
    using MEC;

    /// <summary>
    /// Handles server events.
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
                    if (cooldown == true)
                    {
                        ev.ReturnMessage = " <b><color=red>Don't spam...</color></b>";
                    }

                    return;
                }

                if (ev.Player.Role == RoleType.NtfCommander)
                {
                    foreach (Exiled.API.Features.Player ply in Exiled.API.Features.Player.List.Where(x => x.Team == Team.MTF && x.IsAlive && x.ReferenceHub.characterClassManager.NetworkCurUnitName == ev.Player.ReferenceHub.characterClassManager.NetworkCurUnitName))
                    {
                        string msg = string.Join(separator: " ", values: ev.Arguments);
                        if (Raul125Utils.Instance.Config.OrdersSystemHint)
                        {
                            ply.ShowHint($"<color={Raul125Utils.Instance.Config.OrdersSystemColor}>" + msg + "</color>", Raul125Utils.Instance.Config.OrdersSystemTime);
                        }
                        else
                        {
                            ply.Broadcast((ushort)Raul125Utils.Instance.Config.OrdersSystemTime, $"<color={Raul125Utils.Instance.Config.OrdersSystemColor}>" + msg + "</color>");
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

        /// <inheritdoc cref="Handlers.Server.OnWaitingForPlayers()"/>
        public void OnWaitingForPlayers()
        {
            Methods.Methods.BackupsCooldown = false;
            Methods.Methods.BackupsPerRound = 0;
            Methods.Methods.Scp096Targets.Clear();
        }
    }
}
