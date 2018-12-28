using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Malum.Items.Weapons.Azurite
{
    public class AzuriteHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Azurite Hammer");
            Tooltip.SetDefault("Isn't this unsafe? Fossils are apparently fragile..");
        }

        public override void SetDefaults()
        {
            item.damage = 3;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 30;
            item.useAnimation = 10;
            item.hammer = 50;
            item.useStyle = 1;
            item.knockBack = 20;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AzuriteBar", 15);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}