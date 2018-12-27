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
namespace Malum
{
  public class MalumWorld : ModWorld
  {
      #region the ruins
        
            /**Azurite Ruin code
            /**
             * 0 = Null. Void. Whatever
             * 1 = Stone Slab 4 Nerds
             * 2 = Azurite 4 Nerds
             * 3 = Stone Slap Wall
             * 4 = TBat Likes To Suck Big PP
             * */
        private static readonly byte[,] RuinShrine =
        {
             {0,0,0,0,0,0,0,0,0,0,0},
             {0,1,1,1,1,1,1,1,1,1,0},
             {0,2,4,4,4,4,4,4,4,2,0},
             {0,0,2,2,2,2,2,2,2,0,0},
             {0,0,4,3,1,2,2,1,3,4,0},
             {0,0,4,3,1,2,2,1,3,4,0},
             {0,0,4,3,1,2,2,1,3,4,0},
             {0,0,1,1,1,1,1,1,1,1,0},
             {0,0,1,1,1,1,1,1,1,1,0},
             {0,0,2,2,2,2,2,2,2,2,0},
        };
        #endregion

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            // useful debug tool type thing. Help me find the names of tasks to decide where to put this one.
            var taskNames = tasks.Select(x => x.Name).ToList();
            // I've tried injecting the task before "Piles" and "Spreading Grass", "Piles" can cause furniture interference.
            // Neither works. So far "Planting Trees" is the only one I can get to work.
            var index = tasks.FindIndex(x => x.Name == "Planting Trees");
            if (index != -1)
            {                
                tasks.Insert(index, new PassLegacy("[Malum] Ruins", AddRuin));
            }
              // insert a cleanup task
            index = tasks.FindIndex(x => x.Name == "Micro Biomes");
            if (index != -1)
            {
                tasks.Insert(index, new PassLegacy("[Malum] Making sure that pesky ruin is ruined", CleanupRuin)); 
            }
        }
            
        public void AddRuin(GenerationProgress progress = null)
        {
            if (GenerateRuin)
                return;

            try
            {
                bool Success = MakeRuin(progress);
                if (Success)
                {
                    GenerateRuin = true;
                }
            }
            catch (Exception exception)
            {
                Main.NewText("Something happened. You, as some nerd who found this bug, should DM it to Lizardry#2626 on discord with the logs.txt");
                ErrorLogger.Log(exception);
            }
        }
        
        public void CleanupRuin(GenerationProgress progress = null)
        {
            // bail if the house never generated, something is wrong :(
            if (!GenerateRuin)
                return;

            // bail if already done.
            if (IsItRuined)
                return;

            try
            {
                bool Success = AbortAbort(progress);
                if (Success)
                {
                    IsItRuined = true;
                }
            }
            catch (Exception exception)
            {
                Main.NewText("Something happened. You, as some nerd who found this bug, should DM it to Lizardry#2626 on discord with the logs.txt");
                ErrorLogger.Log(exception);
            }
        }
        
        bool MakeRuin(GenerationProgress progress)
        {            
            string RuinGen = "We're ruining something";
            if (progress != null)
            {
                progress.Message = RuinGen;
                progress.Set(0.25f);
            }
            // before we do anything, create a new World Key for this world
            WorldRuinKey = Main.rand.Next(1, int.MaxValue);
                 RuinStartPositionX = WorldGen.genRand.Next(Main.maxTilesX / 2 - 70, Main.spawnTileX - 25);
            for (var Attempts = 0; Attempts < 10000; Attempts++)
            {
                for (var i = 0; i < 25; i++)
                {
                   RuinStartPositionY = 190;
                    do
                    {
                        RuinStartPositionY++;
                    }
                    while ((!Main.tile[RuinStartPositionX + i, RuinPositionY].active() && RuinPositionY < Main.worldSurface) || Main.tile[RuinStartPositionX + i, RuinStartPositionY].type == TileID.Trees || Main.tile[RuinStartPositionX + i, RuinStartPositionY].type == 27);
                    if (!Main.tile[RuinStartPositionX, RuinStartPositionY].active() || Main.tile[RuinStartPositionX, RuinStartPositionY].liquid > 0)
                    {
                        RuinStartPositionX++;
                    }
                    if (Main.tile[RuinStartPositionX + i, RuinStartPositionY].active())
                    {
                        if (Main.tile[RuinStartPositionX, RuinStartPositionY].liquid > 0) { 
                            RuinStartPositionX = WorldGen.genRand.Next(Main.maxTilesX / 2 - 70, Main.spawnTileX - 25);
                        }
                        else
                        {
                            goto GenerateBuild;
                        }                        
                    }
                }
            }
            goto GenerateBuild;

            GenerateBuild:
            GenerateRuinStructureWithByteArrays(true);
            return true; 
        }
        
              // flag tracking whether the initial house creation point has been offset by the building's height, should only occur once.
        public bool IsRuinOffsetSet = false;
        public void GenerateRuinStructureWithByteArrays(bool isFirstPass)
        {
            if (!IsRuinOffsetSet)
            {
                RuinStartPositionY -= RuinTiles.GetLength(0);
                IsRuinOffsetSet = true;
            }
            // if we're here it means we are ready to generate our structure

            // tiles
            for (var X = 0; X < RuinTiles.GetLength(1); X++)
            {
                for (var Y = 0; Y < RuinTiles.GetLength(0); Y++)
                {
                    int offsetX = RuinStartPositionX + X;
                    int offsetY = RuinStartPositionY + Y;
                    var tile = Framing.GetTileSafely(offsetX, offsetY);
                    switch (RuinTiles[Y, X])
                    {
                        case 0:
                            if (isFirstPass)
                            {
                                tile.type = 0;
                                tile.active(false);
                            }
                            break;
                        case 1:
                            tile.type = TileID.StoneSlab;
                            tile.active(true);
                            break;
                        case 2:
                            tile.type = ModTile.AzuriteOre;
                            tile.active(true);
                            break;
                        case 3:
                             tile.type = 0;
                            tile.active(false);
                            break;
                   
                    }
                }
            }
                     // sample tiles at the origin (it's to the right, this isn't perfect)
            var sampleTile = Framing.GetTileSafely(RuinStartPositionX, RuinStartPositionY + 1);
            bool isSnowBiome = false;
            if (sampleTile.type == TileID.SnowBlock || sampleTile.type == TileID.IceBlock)
                isSnowBiome = true;


            // experimental, also doesn't work when the tiles below are snow... which happens at spawn sometimes.
            // put dirt under the house and make sure gaps are filled. this might look weird.
            for (var Y = 0; Y < 5; Y++)
            {
                for (var X = -1 - (Y * 2); X < RuinTiles.GetLength(1) + 1 + (Y * 2); X++)
                {
                    int offsetX = RuinStartPositionX + X;
                    int offsetY = RuinStartPositionY + RuinTiles.GetLength(0) + Y;
                    var tile = Framing.GetTileSafely(offsetX, offsetY);
                    bool isEdge = IsAnySideExposed(offsetX, offsetY);
                    tile.type = isSnowBiome ? TileID.SnowBlock : (isEdge ? TileID.Grass : TileID.Dirt);
                    // if it's a slope, unslope that shit. quit putting gaps in the ground terraria.
                    tile.slope(0);
                    tile.halfBrick(false);
                    tile.active(true);
                }
            }
        }

        bool RunRuinCleanupRoutine(GenerationProgress progress)
        {
            // we already have the starting position, just cut straight to the build cleanup.
            string RuinGen = "Cleaning up Grandpa's House...";
            if (progress != null)
            {
                progress.Message = RuinGen;
                progress.Set(0.50f);
            }

            GenerateRuinStructureWithByteArrays(false);

        }
    }
}
//unfinished