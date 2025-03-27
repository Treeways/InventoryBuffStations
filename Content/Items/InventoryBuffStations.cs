using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

using InventoryBuffStations.Common.Configs;

namespace InventoryBuffStations.Content.Items
{
	public class InventoryBuffStations : GlobalItem
	{
		public override bool AppliesToEntity(Item item, bool lateInstantiation) {
			// Forgive me
			return
				item.type == ItemID.AmmoBox ||
				item.type == ItemID.BewitchingTable ||
				item.type == ItemID.CrystalBall ||
				item.type == ItemID.SharpeningStation ||
				item.type == ItemID.WarTable ||
				item.type == ItemID.SliceOfCake;
		}

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

		public override void RightClick(Item item, Player player)
		{
			item.stack += 1;
			SoundStyle sound;

			switch (item.type) {
				case ItemID.AmmoBox:
					sound = SoundID.Item149;
					player.AddBuff(BuffID.AmmoBox, 3);
					break;
				case ItemID.BewitchingTable:
					sound = SoundID.Item4;
					player.AddBuff(BuffID.Bewitched, 3);
					break;
				case ItemID.CrystalBall:
					sound = SoundID.Item4;
					player.AddBuff(BuffID.Clairvoyance, 3);
					break;
				case ItemID.SharpeningStation:
					sound = SoundID.Item37;
					player.AddBuff(BuffID.Sharpened, 3);
					break;
				case ItemID.WarTable:
					sound = SoundID.Item4;
					player.AddBuff(BuffID.WarTable, 3);
					break;
				case ItemID.SliceOfCake:
					sound = SoundID.Item2;
					player.AddBuff(BuffID.SugarRush, 7200);
					break;
				default:
					sound = SoundID.Meowmere;
					break;
			}

			if (!ModContent.GetInstance<ClientConfig>().MuteSoundsToggle) {
				SoundEngine.PlaySound(sound, player.position);
			}
		}
    	}
}
