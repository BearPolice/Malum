using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using System;
using System.Linq;
using Malum.Items;

namespace Malum.Items.Weapons.Other
{
    public class Valflame : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 40;
            item.magic = true;
            item.width = 54;
            item.height = 54;
            item.mana = 4;
            item.useTime = 1;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3f;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.consumable = false;
            item.shoot = ProjectileID.MolotovFire3;
            item.shootSpeed = 40f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 80f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(175, 20);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(1, 0);

        }
    }
}