using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Malum.Items
{
	public class OcularVein : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocular Vein");
			Tooltip.SetDefault("Remnants of the great eye grant enhanced vision of the night.");
		}
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 10000;
			item.rare = -12;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            {
                player.AddBuff(BuffID.NightOwl, 2);
			}
		}

	}
}
