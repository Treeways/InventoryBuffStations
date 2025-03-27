using System;
using Terraria.Audio;
using Terraria.ID;

namespace InventoryBuffStations.Common {
	public static class Stations {
		/// <summary>
		/// Doesn't include the Slice of Cake.
		/// Item 1: Item ID
		/// Item 2: Buff ID
		/// Item 3: SoundStyle
		/// </summary>
		public static readonly Tuple<short, int, SoundStyle>[] stationBuffSfx =
		{
			Tuple.Create(ItemID.AmmoBox, BuffID.AmmoBox, SoundID.Item149),
			Tuple.Create(ItemID.BewitchingTable, BuffID.Bewitched, SoundID.Item4),
			Tuple.Create(ItemID.CrystalBall, BuffID.Clairvoyance, SoundID.Item4),
			Tuple.Create(ItemID.SharpeningStation, BuffID.Sharpened, SoundID.Item37),
			Tuple.Create(ItemID.WarTable, BuffID.WarTable, SoundID.Item4),
		};
	}
}
