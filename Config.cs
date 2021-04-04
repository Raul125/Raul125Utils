// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace DamageIndicator
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
        /// Gets a value indicating whether gets the bool config.
        /// </summary>
        [Description("Displayed hint when you damage a player")]
        public string Hint { get; private set; } = "Du hast %player, %damage Schaden gemacht";

        /// <summary>
        /// Gets the int config.
        /// </summary>
        [Description("Time of the displayed hint")]
        public float Hint_Time { get; private set; } = 2f;
    }
}
