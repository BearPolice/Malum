using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Malum.Items.Placeable
{
	public class AzuriteBar : ModItem
	{
     				public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Azurite Bar");
			Tooltip.SetDefault("Fossils from the great war of the ancient sea.");
		}
		
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.value = 2100;
			item.consumable = true;
			item.createTile = mod.TileType("AzuriteBar");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AzuriteOre", 4);
            recipe.AddTile(77);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}