using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

using InventoryBuffStations.Common.Configs;

namespace InventoryBuffStations.Common.Players {
	public class SugarRushBuff : ModPlayer
	{
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
