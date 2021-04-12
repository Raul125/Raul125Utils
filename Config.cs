// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Raul125Utils
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Features;
    using Exiled.API.Interfaces;

    /// <inheritdoc cref="IConfig"/>
    public sealed class Config : IConfig
    {
        /// <inheritdoc/>
        [Description("Indicates whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets a value indicating whether DamageHint is enabled or not.
        /// </summary>
        [Description("Indicates whether damagehint part is enabled")]
        public bool DamageHintIsEnabled { get; private set; } = true;

        /// <summary>
        /// Gets a value indicating whether gets the bool config.
        /// </summary>
        [Description("Displayed hint when you damage a player")]
        public string DamageHint { get; private set; } = "You are hurting <color=green>%player</color>\n<color=red>%damage</color> of damage caused";

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Time of the displayed hint")]
        public float DamageHintTime { get; private set; } = 2f;

        /// <summary>
        /// Gets a value indicating whether OrdersSystem is enabled or not.
        /// </summary>
        [Description("Indicates whether OrdersSystem part is enabled")]
        public bool OrdersSystemIsEnabled { get; private set; } = true;

        /// <summary>
        /// Gets a value indicating whether OrdersSystemHint is enabled or not.
        /// </summary>
        [Description("Use hints in OrdersSystem?")]
        public bool OrdersSystemHint { get; private set; } = true;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Displayed time of an order")]
        public float OrdersSystemTime { get; private set; } = 5f;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Color of the displayed message")]
        public string OrdersSystemColor { get; private set; } = "#1e18dc";

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Individual cooldown of a commander, necessary time to pass before sending another order")]
        public float OrdersSystemCooldownTime { get; private set; } = 25f;

        /// <summary>
        /// Gets a value indicating whether DetonationRequeriment is enabled or not.
        /// </summary>
        [Description("Indicates whether DetonationRequirement part is enabled")]
        public bool DetonationRequirementIsEnabled { get; private set; } = true;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Necessary generators to activate the nuke ")]
        public int DetonationRequirementGenerators { get; private set; } = 4;

        /// <summary>
        /// Gets a value indicating whether EnergyOverload is enabled or not.
        /// </summary>
        [Description("Indicates whether EnergyOverload part is enabled")]
        public bool EnergyOverloadIsEnabled { get; private set; } = true;

        /// <summary>
        /// Gets a value indicating whether gets the int config.
        /// </summary>
        [Description("Should block checkpoints?")]
        public bool EnergyOverloadCheckpoints { get; private set; } = true;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("For how long checkpoints should be locked?")]
        public float EnergyOverloadCheckpointsTime { get; private set; } = 20;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Chance of an checkpoints event to happen")]
        public int EnergyOverloadCheckpointsChance { get; private set; } = 35;

        /// <summary>
        /// Gets a value indicating whether gets the int config.
        /// </summary>
        [Description("Should turn off the lights?")]
        public bool EnergyOverloadLightsOff { get; private set; } = true;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("For how long light should be turned off? ")]
        public int EnergyOverloadLightsTime { get; private set; } = 30;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Chance of an lights event to happen")]
        public int EnergyOverloadLightsChance { get; private set; } = 35;

        /// <summary>
        /// Gets a value indicating whether EmergencyBackup is enabled or not.
        /// </summary>
        [Description("Indicates whether EmergencyBackup part is enabled")]
        public bool EmergencyBackupIsEnabled { get; private set; } = true;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Neccesary cooldown between backups")]
        public int EmergencyBackupCooldown { get; private set; } = 200;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Max Backups per round")]
        public int EmergencyBackupMaxPerRound { get; private set; } = 2;

        /// <summary>
        /// Gets a value indicating whether Hard096RP is enabled or not.
        /// </summary>
        [Description("Indicates whether Hard096RP part is enabled")]
        public bool Hard096RPIsEnabled { get; private set; } = true;

        /// <summary>
        /// Gets a value indicating whether TeamKillBroadCast is enabled or not.
        /// </summary>
        [Description("Indicates whether TeamKillBroadcast part is enabled")]
        public bool TeamKillBroadCastIsEnabled { get; private set; } = true;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Time of the broadcast")]
        public int TeamKillBroadCastTime { get; private set; } = 15;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Broadcast sent when you are teamkilled")]
        public string TeamKillBroadCastContent { get; private set; } = "<color=yellow>You were </color><color=red>teamkilled by </color><color=green>%player</color>\n<color=yellow>Date: %date</color>\n<color=yellow>Take a screenshot and report this to the administrators</color>";
    }
}
