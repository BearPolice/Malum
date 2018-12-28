using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Malum.Items.Weapons.Azurite
{
    public class Siegfried : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Siegfried");
            Tooltip.SetDefault("Will become legendary in the 14th sequel. Has high knockback.");
        }
        public override void SetDefaults()
        {
            item.damage = 12;
            item.melee = true;
            item.noMelee = false;
            item.width = 42;
            item.height = 44;
            item.useTime = 20;
            item.useAnimation = 23;
            item.useStyle = 1;
            item.knockBack = 10;
            item.value = 100000;
            item.rare = 3;
            //item.reuseDelay = 20;    
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            item.maxStack = 1;
            item.consumable = false;
            //item.noUseGraphic = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AzuriteBar", 10);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}