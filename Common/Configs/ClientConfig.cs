using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace InventoryBuffStations.Common.Configs
{
	public class ClientConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[DefaultValue(false)]
		public bool MuteSoundsToggle;
	}
}
