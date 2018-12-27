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
			Tooltip.SetDefault("Long ago there was a great war of a long dried up sea. You're holding the remains of a soldier from millenia's past");
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
			item.consumable = false;
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