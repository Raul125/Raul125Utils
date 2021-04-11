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
        public string DamageHint { get; private set; } = "You are hurting %player\n%damage of damage caused";

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Time of the displayed hint")]
        public float DamageHintTime { get; private set; } = 2f;

        /// <summary>
        /// Gets a value indicating whether DamageHint is enabled or not.
        /// </summary>
        [Description("Indicates whether OrdersSystem part is enabled")]
        public bool OrdersSystemIsEnabled { get; private set; } = true;

        /// <summary>
        /// Gets a value indicating whether DamageHint is enabled or not.
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
        [Description("Individual cooldown of a commander, necessary time to pass before sending another order")]
        public float OrdersSystemCooldownTime { get; private set; } = 25f;

        /// <summary>
        /// Gets a value indicating whether DamageHint is enabled or not.
        /// </summary>
        [Description("Indicates whether DetonationRequirement part is enabled")]
        public bool DetonationRequirementIsEnabled { get; private set; } = true;

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Necessary generators to activate the nuke ")]
        public int DetonationRequirementGenerators { get; private set; } = 2;
    }
}
