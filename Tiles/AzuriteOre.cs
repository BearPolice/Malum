using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Malum.Tiles
{
	public class AzuriteOre : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			drop = mod.ItemType("AzuriteOre");
			AddMapEntry(new Color(0, 125, 150));
            minPick = 35;
		}
	}
}