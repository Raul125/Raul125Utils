// -----------------------------------------------------------------------
// <copyright file="Methods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Raul125Utils.Methods
{
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using Interactables.Interobjects.DoorUtils;
    using MEC;
    using UnityEngine;

    /// <summary>
    /// Methods.
    /// </summary>
    public static class Methods
    {
#pragma warning disable SA1401 // Fields should be private
        /// <summary>
        /// Backups cooldown bool.
        /// </summary>
        public static bool BackupsCooldown = false;

        /// <summary>
        /// Max Backups per round system.
        /// </summary>
        public static int BackupsPerRound = 0;

        /// <summary>
        /// Scp096 Targets list.
        /// </summary>
        public static List<Player> Scp096Targets = new List<Player>();

        /// <summary>
        /// Disable the lockdown of the checkpoints.
        /// </summary>
        /// <returns>Nothing.</returns>
        public static IEnumerator<float> EnergyOverloadCheckpoints()
        {
            yield return Timing.WaitForSeconds(Raul125Utils.Instance.Config.EnergyOverloadLightsTime);

            var checkpointHcz = Exiled.API.Features.Map.GetDoorByName("CHECKPOINT_EZ_HCZ");
            var checkpointLczA = Exiled.API.Features.Map.GetDoorByName("CHECKPOINT_LCZ_A");
            var checkpointLczB = Exiled.API.Features.Map.GetDoorByName("CHECKPOINT_LCZ_B");

            checkpointHcz.ServerChangeLock(Interactables.Interobjects.DoorUtils.DoorLockReason.NoPower, false);
            checkpointLczA.ServerChangeLock(Interactables.Interobjects.DoorUtils.DoorLockReason.NoPower, false);
            checkpointLczB.ServerChangeLock(Interactables.Interobjects.DoorUtils.DoorLockReason.NoPower, false);
        }

        /// <summary>
        /// Disable the lockdown of the checkpoints.
        /// </summary>
        /// <returns>Nothing.</returns>
        public static IEnumerator<float> EmergencyBackupCooldown()
        {
            yield return Timing.WaitForSeconds(Raul125Utils.Instance.Config.EmergencyBackupCooldown);

            BackupsCooldown = false;
        }
    }
}
