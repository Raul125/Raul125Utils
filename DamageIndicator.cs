// <copyright file="DamageIndicator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DamageIndicator
{
    using System;

    using Exiled.API.Enums;
    using Exiled.API.Features;

    /// <summary>
    /// The example plugin.
    /// </summary>
    public class DamageIndicator : Plugin<Config>
    {
        private static DamageIndicator singleton = new DamageIndicator();

        private Handlers.Mixed eventsPl;

        private DamageIndicator()
        {
        }

        /// <summary>
        /// Gets the only existing instance of this plugin.
        /// </summary>
        public static DamageIndicator Instance => singleton;

        /// <inheritdoc/>
        public override string Author { get; } = "Raul125";

        /// <inheritdoc/>
        public override string Name { get; } = "DamageIndicator";

        /// <inheritdoc/>
        public override string Prefix { get; } = "DamageIndicator";

        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 0, 0);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(2, 8, 0);

        /// <inheritdoc/>
        public override PluginPriority Priority { get; } = PluginPriority.Lower;

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            base.OnEnabled();

            this.RegisterEvents();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            base.OnDisabled();

            this.UnregisterEvents();
        }

        /// <summary>
        /// Registers the plugin events.
        /// </summary>
        private void RegisterEvents()
        {
            this.eventsPl = new Handlers.Mixed();
            Exiled.Events.Handlers.Player.Hurting += this.eventsPl.OnHurting;
        }

        /// <summary>
        /// Unregisters the plugin events.
        /// </summary>
        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Hurting -= this.eventsPl.OnHurting;
            this.eventsPl = null;
        }
    }
}
