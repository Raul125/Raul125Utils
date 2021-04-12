// -----------------------------------------------------------------------
// <copyright file="Map.cs" company="Raul125">
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
    /// Handles map events.
    /// </summary>
    internal sealed class Map
    {
        /// <inheritdoc cref="Handlers.Map.OnGeneratorActivated(GeneratorActivatedEventArgs)"/>
        public void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
        {
            if (Instance.Config.EnergyOverloadIsEnabled == false)
            {
                return;
            }

            if (Instance.Config.EnergyOverloadCheckpoints == true)
            {
                if (Rand.Next(100) < Instance.Config.EnergyOverloadCheckpointsChance)
                {
                    var checkpointHcz = Exiled.API.Features.Map.GetDoorByName("CHECKPOINT_EZ_HCZ");
                    var checkpointLczA = Exiled.API.Features.Map.GetDoorByName("CHECKPOINT_LCZ_A");
                    var checkpointLczB = Exiled.API.Features.Map.GetDoorByName("CHECKPOINT_LCZ_B");

                    if (checkpointHcz.NetworkActiveLocks == 0)
                    {
                        checkpointHcz.ServerChangeLock(Interactables.Interobjects.DoorUtils.DoorLockReason.NoPower, true);
                        if (checkpointHcz.NetworkTargetState == true)
                        {
                            checkpointHcz.NetworkTargetState = false;
                        }
                    }

                    if (checkpointLczA.NetworkActiveLocks == 0)
                    {
                        checkpointLczA.ServerChangeLock(Interactables.Interobjects.DoorUtils.DoorLockReason.NoPower, true);
                        if (checkpointLczA.NetworkTargetState == true)
                        {
                            checkpointLczA.NetworkTargetState = false;
                        }
                    }

                    if (checkpointLczB.NetworkActiveLocks == 0)
                    {
                        checkpointLczB.ServerChangeLock(Interactables.Interobjects.DoorUtils.DoorLockReason.NoPower, true);
                        if (checkpointLczB.NetworkTargetState == true)
                        {
                            checkpointLczB.NetworkTargetState = false;
                        }
                    }

                    Timing.RunCoroutine(Methods.Methods.EnergyOverloadCheckpoints());
                }
            }

            if (Instance.Config.EnergyOverloadLightsOff == true)
            {
                if (Rand.Next(100) < Instance.Config.EnergyOverloadLightsChance)
                {
                    Exiled.API.Features.Map.TurnOffAllLights(Instance.Config.EnergyOverloadLightsTime, true);
                }
            }
        }
    }
}
