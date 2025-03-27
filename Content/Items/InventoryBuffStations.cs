using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

using InventoryBuffStations.Common;
using InventoryBuffStations.Common.Configs;

namespace InventoryBuffStations.Content.Items
{
	public class InventoryBuffStations : GlobalItem
	{
		/// <summary>
		/// Applies to all buff stations.
		/// </summary>
		public override bool AppliesToEntity(Item item, bool lateInstantiation) {
			foreach (var station in Stations.stationBuffSfx) {
				if (item.type == station.Item1) return true;
			}
			return item.type == ItemID.SliceOfCake;
		}

		/// <summary>
		/// Toggles individual item picking/dividing, based on the station and config options.
		/// </summary>
		/// <param name="item">The item being right-clicked.</param>
		public override bool CanRightClick(Item item) {
			if (item.type != ItemID.SliceOfCake
			&& ModContent.GetInstance<BuffConfig>().ApplyBuffsPassivelyToggle) {
				return false;
			}
			else if (item.type == ItemID.SliceOfCake
			&& ModContent.GetInstance<BuffConfig>().InfiniteSugarRushToggle
			&& ModContent.GetInstance<BuffConfig>().ApplyBuffsPassivelyToggle) {
				return false;
			}

			return true;
		}

		/// <summary>
		/// When a station is right-clicked in the inventory, plays a sound and buffs the player.
		/// </summary>
		public override void RightClick(Item item, Player player)
		{
			// Prevents item deletion
			item.stack += 1;

			if (item.type == ItemID.SliceOfCake) {
				if (!ModContent.GetInstance<ClientConfig>().MuteSoundsToggle)
					SoundEngine.PlaySound(SoundID.Item2, player.position);
				player.AddBuff(BuffID.SugarRush, 7200);
				return;
			}

			foreach (var station in Stations.stationBuffSfx) {
				if (item.type == station.Item1) {
					player.AddBuff(station.Item2, 3);

					if (!ModContent.GetInstance<ClientConfig>().MuteSoundsToggle)
						SoundEngine.PlaySound(station.Item3, player.position);
				}
			}
		}
    	}
}
