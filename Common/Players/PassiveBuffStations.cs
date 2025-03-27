using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

using InventoryBuffStations.Common.Configs;
using Terraria.Audio;

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
					if (!Player.immune && !ModContent.GetInstance<ClientConfig>().MuteSoundsToggle)
						SoundEngine.PlaySound(SoundID.Item2, Player.position);
				}

				if (Player.HasItemInAnyInventory(ItemID.AmmoBox) && !Player.HasBuff(BuffID.AmmoBox))
				{
					Player.AddBuff(BuffID.AmmoBox, 3);
					if (!Player.immune && !ModContent.GetInstance<ClientConfig>().MuteSoundsToggle)
						SoundEngine.PlaySound(SoundID.Item149, Player.position);
				}

				if (Player.HasItemInAnyInventory(ItemID.BewitchingTable) && !Player.HasBuff(BuffID.Bewitched))
				{
					Player.AddBuff(BuffID.Bewitched, 3);
					if (!Player.immune && !ModContent.GetInstance<ClientConfig>().MuteSoundsToggle)
						SoundEngine.PlaySound(SoundID.Item4, Player.position);
				}

				if (Player.HasItemInAnyInventory(ItemID.CrystalBall) && !Player.HasBuff(BuffID.Clairvoyance))
				{
					Player.AddBuff(BuffID.Clairvoyance, 3);
					if (!Player.immune && !ModContent.GetInstance<ClientConfig>().MuteSoundsToggle)
						SoundEngine.PlaySound(SoundID.Item4, Player.position);

				}
				if (Player.HasItemInAnyInventory(ItemID.SharpeningStation) && !Player.HasBuff(BuffID.Sharpened))
				{
					Player.AddBuff(BuffID.Sharpened, 3);
					if (!Player.immune && !ModContent.GetInstance<ClientConfig>().MuteSoundsToggle)
						SoundEngine.PlaySound(SoundID.Item37, Player.position);
				}

				if (Player.HasItemInAnyInventory(ItemID.WarTable) && !Player.HasBuff(BuffID.WarTable))
				{
					Player.AddBuff(BuffID.WarTable, 3);
					if (!Player.immune && !ModContent.GetInstance<ClientConfig>().MuteSoundsToggle)
						SoundEngine.PlaySound(SoundID.Item4, Player.position);
				}
			}
		}
	}
}
