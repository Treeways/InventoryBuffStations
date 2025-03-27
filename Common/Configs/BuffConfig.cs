using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace InventoryBuffStations.Common.Configs
{
	public class BuffConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[DefaultValue(false)]
		public bool InfiniteSugarRushToggle;
		[DefaultValue(false)]
		public bool ApplyBuffsPassivelyToggle;
	}
}
