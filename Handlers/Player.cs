// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="Raul125">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Raul125Utils.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Extensions;
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

            if (ev.Target == ev.Attacker)
            {
                return;
            }

            ev.Attacker.ShowHint(Instance.Config.DamageHint.Replace("%damage", ev.Amount.ToString()).Replace("%player", ev.Target.Nickname), Instance.Config.DamageHintTime);
        }

        /// <inheritdoc cref="Handlers.Player.OnIntercomSpeaking(IntercomSpeakingEventArgs)"/>
        public void OnIntercomSpeaking(IntercomSpeakingEventArgs ev)
        {
            if (ev.Player == null)
            {
                return;
            }

            if (ev.Player.Side != Exiled.API.Enums.Side.Mtf)
            {
                return;
            }

            if (Methods.Methods.BackupsCooldown == true)
            {
                return;
            }

            if (Methods.Methods.BackupsPerRound == Raul125Utils.Instance.Config.EmergencyBackupMaxPerRound)
            {
                return;
            }

            if (Methods.Methods.BackupsCooldown == false && ev.Player.CurrentItem.id == ItemType.Radio)
            {
                if (Exiled.API.Features.Player.List.Where(x => x.Role == RoleType.Spectator).ToList().Count < 1)
                {
                    return;
                }

                Respawn.ForceWave(Respawning.SpawnableTeamType.NineTailedFox, true);
                ev.Player.ShowHint("You have called a Emergency Backup Team", 10);
                Methods.Methods.BackupsCooldown = true;
                Methods.Methods.BackupsPerRound += 1;
                Timing.RunCoroutine(Methods.Methods.EmergencyBackupCooldown());
            }
        }

        /// <inheritdoc cref="Handlers.Player.OnDied(DiedEventArgs)"/>
        public void OnDied(DiedEventArgs ev)
        {
            if (ev.Target == null)
            {
                return;
            }

            if (Raul125Utils.Instance.Config.Hard096RPIsEnabled == true)
            {
                if (Methods.Methods.Scp096Targets.Contains(ev.Target))
                {
                    Methods.Methods.Scp096Targets.Remove(ev.Target);
                }
            }

            if (ev.Killer == null)
            {
                return;
            }

            if (ev.Target == ev.Killer)
            {
                return;
            }

            if (Instance.Config.TeamKillBroadCastIsEnabled == true)
            {
                if (ev.Killer.Team == ev.Target.Team)
                {
                    ev.Target.Broadcast((ushort)Instance.Config.TeamKillBroadCastTime, Instance.Config.TeamKillBroadCastContent.Replace("%player", ev.Killer.Nickname).Replace("%date", DateTime.Now.ToString()));
                }
            }
        }

        /// <inheritdoc cref="Handlers.Player.OnDestroying(DestroyingEventArgs)"/>
        public void OnDestroying(DestroyingEventArgs ev)
        {
            if (ev.Player == null)
            {
                return;
            }

            if (Raul125Utils.Instance.Config.Hard096RPIsEnabled == true)
            {
                if (Methods.Methods.Scp096Targets.Contains(ev.Player))
                {
                    Methods.Methods.Scp096Targets.Remove(ev.Player);
                }
            }
        }
    }
}
