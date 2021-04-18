// <copyright file="Raul125Utils.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Raul125Utils
{
    using System;

    using Exiled.API.Enums;
    using Exiled.API.Features;
    using HarmonyLib;

    /// <summary>
    /// Raul125 Utils Plugin.
    /// </summary>
    public class Raul125Utils : Plugin<Config>
    {
        /// <summary>
        /// Random System.
        /// </summary>
        public static readonly System.Random Rand = new System.Random();

        private Handlers.Player eventsPl;
        private Handlers.Server eventsSv;
        private Handlers.Warhead eventsWh;
        private Handlers.Map eventsMap;
        private Handlers.Scp096 events096;

        /// <summary>
        /// Gets the only existing instance of this plugin.
        /// </summary>
        public static Raul125Utils Instance => Singleton;

        /// <inheritdoc/>
        public override string Author { get; } = "Raul125";

        /// <inheritdoc/>
        public override string Name { get; } = "Raul125Utils";

        /// <inheritdoc/>
        public override string Prefix { get; } = "Raul125Utils";

        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 0, 7);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(2, 8, 0);

        /// <inheritdoc/>
        public override PluginPriority Priority { get; } = PluginPriority.Lower;

        private static Raul125Utils Singleton { get; set; }

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            base.OnEnabled();
            Singleton = this;
            this.RegisterEvents();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            base.OnDisabled();
            Singleton = null;
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
            this.eventsMap = new Handlers.Map();
            this.events096 = new Handlers.Scp096();
            Exiled.Events.Handlers.Player.Hurting += this.eventsPl.OnHurting;
            Exiled.Events.Handlers.Player.Died += this.eventsPl.OnDied;
            Exiled.Events.Handlers.Player.Destroying += this.eventsPl.OnDestroying;
            Exiled.Events.Handlers.Player.IntercomSpeaking += this.eventsPl.OnIntercomSpeaking;
            Exiled.Events.Handlers.Server.SendingConsoleCommand += this.eventsSv.OnSendingConsoleCommand;
            Exiled.Events.Handlers.Server.WaitingForPlayers += this.eventsSv.OnWaitingForPlayers;
            Exiled.Events.Handlers.Warhead.Starting += this.eventsWh.OnStarting;
            Exiled.Events.Handlers.Map.GeneratorActivated += this.eventsMap.OnGeneratorActivated;
            Exiled.Events.Handlers.Scp096.CalmingDown += this.events096.OnCalmingDown;
            Exiled.Events.Handlers.Scp096.AddingTarget += this.events096.OnAddingTarget;
        }

        /// <summary>
        /// Unregisters the plugin events.
        /// </summary>
        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Hurting -= this.eventsPl.OnHurting;
            Exiled.Events.Handlers.Player.Died -= this.eventsPl.OnDied;
            Exiled.Events.Handlers.Player.Destroying -= this.eventsPl.OnDestroying;
            Exiled.Events.Handlers.Player.IntercomSpeaking -= this.eventsPl.OnIntercomSpeaking;
            Exiled.Events.Handlers.Server.SendingConsoleCommand -= this.eventsSv.OnSendingConsoleCommand;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= this.eventsSv.OnWaitingForPlayers;
            Exiled.Events.Handlers.Warhead.Starting -= this.eventsWh.OnStarting;
            Exiled.Events.Handlers.Map.GeneratorActivated -= this.eventsMap.OnGeneratorActivated;
            Exiled.Events.Handlers.Scp096.CalmingDown -= this.events096.OnCalmingDown;
            Exiled.Events.Handlers.Scp096.AddingTarget -= this.events096.OnAddingTarget;
            this.eventsPl = null;
            this.eventsSv = null;
            this.eventsWh = null;
        }
    }
}
