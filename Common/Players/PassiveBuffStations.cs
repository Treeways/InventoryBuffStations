using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.Audio;

using InventoryBuffStations;
using InventoryBuffStations.Common.Configs;
using System.Collections.Generic;

namespace InventoryBuffStations.Common.Players {

	/// <summary>
	/// Applies station buffs passively, regardless of what player inventory it's in.
	/// </summary>
	public class PassiveBuffStations : ModPlayer
	{
		public override void PreUpdate()
		{
			if (ModContent.GetInstance<BuffConfig>().ApplyBuffsPassivelyToggle && !Player.dead) {
				// Slice of Cake
				if (
					ModContent.GetInstance<BuffConfig>().InfiniteSugarRushToggle &&
					Player.HasItemInAnyInventory(ItemID.SliceOfCake) &&
					// Prevents an infinite loop present in SugarRushBuff.cs
					!Player.HasBuff(BuffID.SugarRush)
				) {
					Player.AddBuff(BuffID.SugarRush, 3);
					// !Player.immune prevents sound blasting on player load-in or respawn
					if (!Player.immune && !ModContent.GetInstance<ClientConfig>().MuteSoundsToggle)
						SoundEngine.PlaySound(SoundID.Item2, Player.position);
				}

				// Other stations
				foreach (var station in Stations.stationBuffSfx) {
					if (Player.HasItemInAnyInventory(station.Item1) && !Player.HasBuff(station.Item2))
					{
						Player.AddBuff(station.Item2, 3);
						if (!Player.immune && !ModContent.GetInstance<ClientConfig>().MuteSoundsToggle)
							SoundEngine.PlaySound(station.Item3, Player.position);
					}
				}
			}
		}
	}
}
