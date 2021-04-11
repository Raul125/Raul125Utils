// <copyright file="Raul125Utils.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Raul125Utils
{
    using System;

    using Exiled.API.Enums;
    using Exiled.API.Features;

    /// <summary>
    /// The example plugin.
    /// </summary>
    public class Raul125Utils : Plugin<Config>
    {
        private static Raul125Utils singleton = new Raul125Utils();

        private Handlers.Player eventsPl;
        private Handlers.Server eventsSv;
        private Handlers.Warhead eventsWh;

        private Raul125Utils()
        {
        }

        /// <summary>
        /// Gets the only existing instance of this plugin.
        /// </summary>
        public static Raul125Utils Instance => singleton;

        /// <inheritdoc/>
        public override string Author { get; } = "Raul125";

        /// <inheritdoc/>
        public override string Name { get; } = "Raul125Utils";

        /// <inheritdoc/>
        public override string Prefix { get; } = "Raul125Utils";

        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 0, 3);

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
            this.eventsPl = new Handlers.Player();
            this.eventsSv = new Handlers.Server();
            this.eventsWh = new Handlers.Warhead();
            Exiled.Events.Handlers.Player.Hurting += this.eventsPl.OnHurting;
            Exiled.Events.Handlers.Server.SendingConsoleCommand += this.eventsSv.OnSendingConsoleCommand;
            Exiled.Events.Handlers.Warhead.Starting += this.eventsWh.OnStarting;
        }

        /// <summary>
        /// Unregisters the plugin events.
        /// </summary>
        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Hurting -= this.eventsPl.OnHurting;
            Exiled.Events.Handlers.Server.SendingConsoleCommand -= this.eventsSv.OnSendingConsoleCommand;
            Exiled.Events.Handlers.Warhead.Starting -= this.eventsWh.OnStarting;
            this.eventsPl = null;
            this.eventsSv = null;
            this.eventsWh = null;
        }
    }
}
