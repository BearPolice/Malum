using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace Malum
{
	public class MalumWorld : ModWorld
	{
          
              public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                // Shinies pass removed by some other mod.
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("Azurite Ores", delegate (GenerationProgress progress)
            {
                progress.Message = "Scattering fossils of the ancient sea";

                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), mod.TileType("AzuriteOre"), false, 0f, 0f, false, true);
                }
            }));
        }
    }
}