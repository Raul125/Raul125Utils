// -----------------------------------------------------------------------
// <copyright file="Scp096.cs" company="PlaceholderCompany">
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
    /// Handles Scp096 events.
    /// </summary>
    internal sealed class Scp096
    {
        /// <inheritdoc cref="Handlers.Scp096.OnAddingTarget(AddingTargetEventArgs)"/>
        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            if (Raul125Utils.Instance.Config.Hard096RPIsEnabled == false)
            {
                return;
            }

            if (ev.Target == null)
            {
                return;
            }

            if (ev.IsAllowed == false)
            {
                return;
            }

            if (!Methods.Methods.Scp096Targets.Contains(ev.Target))
            {
                Methods.Methods.Scp096Targets.Add(ev.Target);
            }
        }

        /// <inheritdoc cref="Handlers.Scp096.OnCalmingDown(CalmingDownEventArgs)"/>
        public void OnCalmingDown(CalmingDownEventArgs ev)
        {
            if (Raul125Utils.Instance.Config.Hard096RPIsEnabled == false)
            {
                return;
            }

            if (Methods.Methods.Scp096Targets.Count != 0)
            {
                ev.IsAllowed = false;
            }

            if (ev.IsAllowed == true)
            {
                Methods.Methods.Scp096Targets.Clear();
            }
        }
    }
}
