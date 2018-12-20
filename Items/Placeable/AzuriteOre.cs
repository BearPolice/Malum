using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Malum.Items.Placeable
{
	public class AzuriteOre : ModItem
	{
				public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Azurite Ore");
			Tooltip.SetDefault("Fossils from the great war of the ancient sea.");
		}
		
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.value = 525;
			item.consumable = true;
			item.createTile = mod.TileType("AzuriteOre");
		}
	}
}