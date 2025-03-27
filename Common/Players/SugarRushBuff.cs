using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using InventoryBuffStations.Common.Configs;

namespace InventoryBuffStations.Common.Players {
	public class SugarRushBuff : ModPlayer
	{
		/// <summary>
		/// Applies the Slice of Cake's infinite Sugar Rush buff
		/// when its config option is toggled.
		/// </summary>
		public override void PreUpdate()
		{
			base.PreUpdate();
			if (Player.HasBuff(BuffID.SugarRush) && ModContent.GetInstance<BuffConfig>().InfiniteSugarRushToggle) {
				// Clear the old buff duration
				Player.ClearBuff(BuffID.SugarRush);
				Player.AddBuff(BuffID.SugarRush, 3);
			}
		}
	}
}
