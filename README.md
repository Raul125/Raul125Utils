# DamageIndicator

<a href="https://github.com/Raul125/Raul125Utils/releases"><img src="https://img.shields.io/github/v/release/Raul125/Raul125Utils?include_prereleases&label=Release" alt="Releases"></a>
<a href="https://github.com/Raul125/Raul125Utils/releases"><img src="https://img.shields.io/github/downloads/Raul125/Raul125Utils/total?label=Downloads" alt="Downloads"></a>

**<size=50>! All content of this plugin are plugin requests ¡</size>**

```yaml
Raul125Utils:
# Indicates whether the plugin is enabled or not
  is_enabled: true
  # Indicates whether damagehint part is enabled
  damage_hint_is_enabled: true
  # Displayed hint when you damage a player
  damage_hint: >-
    You are hurting <color=green>%player</color>

    <color=red>%damage</color> of damage caused
  # Time of the displayed hint
  damage_hint_time: 2
  # Indicates whether OrdersSystem part is enabled
  orders_system_is_enabled: true
  # Use hints in OrdersSystem?
  orders_system_hint: true
  # Displayed time of an order
  orders_system_time: 5
  # Color of the displayed message
  orders_system_color: '#1e18dc'
  # Individual cooldown of a commander, necessary time to pass before sending another order
  orders_system_cooldown_time: 25
  # Indicates whether DetonationRequirement part is enabled
  detonation_requirement_is_enabled: true
  # Necessary generators to activate the nuke 
  detonation_requirement_generators: 4
  # Indicates whether EnergyOverload part is enabled
  energy_overload_is_enabled: true
  # Should block checkpoints?
  energy_overload_checkpoints: true
  # For how long checkpoints should be locked?
  energy_overload_checkpoints_time: 20
  # Chance of an checkpoints event to happen
  energy_overload_checkpoints_chance: 35
  # Should turn off the lights?
  energy_overload_lights_off: true
  # For how long light should be turned off? 
  energy_overload_lights_time: 30
  # Chance of an lights event to happen
  energy_overload_lights_chance: 35
  # Indicates whether EmergencyBackup part is enabled
  emergency_backup_is_enabled: true
  # Neccesary cooldown between backups
  emergency_backup_cooldown: 200
  # Max Backups per round
  emergency_backup_max_per_round: 2
  # Indicates whether Hard096RP part is enabled
  hard096_r_p_is_enabled: true
  # Indicates whether TeamKillBroadcast part is enabled
  team_kill_broad_cast_is_enabled: true
  # Time of the broadcast
  team_kill_broad_cast_time: 15
  # Broadcast sent when you are teamkilled
  team_kill_broad_cast_content: >-
    <color=yellow>You were </color><color=red>teamkilled by </color><color=green>%player</color>

    <color=yellow>Date: %date</color>

    <color=yellow>Take a screenshot and report this to the administrators</color>
```

# Damage Hint
You recive a hint when you damage other player.

# Orders System
If you are a MtfCommander you can use the command `c Order`, it will display a hint or a broadcast, depends of you configuration to all mtf players of your unit.

# Detonation Requeriment
You need to activate a configurable amount of generators to activate the warhead, it doesn't affect to the R.A button.

# Energy Overload
When a generator is activated, there is a chance that checkpoints will be blocked and the Hcz lights will turn off, all is configurable.

# Emergency Backup
If you are in the Mtf side you can call an Emergency Backup Team, you have to go to the intercom, have a radio in the hands and start speaking, then, a mtf squad will spawn, it has cooldown and max calls per round.

# Hard096Rp
If the Scp096 has a target, it won't calm.

# TeamKill BroadCast
If you suffer a teamkill, you will recive a broadcast with the nickname of the killer, all is configurable.

Work in progress...
