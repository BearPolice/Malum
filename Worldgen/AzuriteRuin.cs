using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Malum;

namespace Malum.Worldgen
{
    public class AzuriteRuin
    {
         private static readonly int[,] StructureArray = new int[,]
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

          public static void StructureGen(int xPosO, int yPosO, bool mirrored)
        {
            /**Azurite Ruin code
            /**
             * 0 = Null. Void. Whatever
             * 1 = Stone Slab 4 Nerds
             * 2 = Azurite 4 Nerds
             * 3 = Stone Slap Wall
             * 4 = TBat Likes To Suck Big PP
             * */

            for (int i = 0; i < StructureArray.GetLength(1); i++)
            {
                for (int j = 0; j < StructureArray.GetLength(0); j++)
                {
                     if (mirrored)
                    {
                        if (TileCheckSafe((int)(xPosO + StructureArray.GetLength(1) - i), (int)(yPosO + j)))
                        {
                              }
                            if (StructureArray[j, i] == 1)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, 273, true, true);
                            }
                             if (StructureArray[j, i] == 2)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, Malum.instance.TileType("AzuriteOre"), true, true);
                            }
                              if (StructureArray[j, i] == 3)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                  WorldGen.KillWall(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceWall(xPosO + StructureArray.GetLength(1) - i, yPosO + j, 147, true); //stone slab wall or whatever
                            }
                               if (StructureArray[j, i] == 4)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                            }
                                
                    else
                    {
                            if (TileCheckSafe((int)(xPosO + StructureArray.GetLength(1) - i), (int)(yPosO + j)))
                        {
                              }
                            if (StructureArray[j, i] == 1)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, 273, true, true);
                            }
                             if (StructureArray[j, i] == 2)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, Malum.instance.TileType("AzuriteOre"), true, true);
                            }
                              if (StructureArray[j, i] == 3)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                  WorldGen.KillWall(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceWall(xPosO + StructureArray.GetLength(1) - i, yPosO + j, 147, true); //stone slab wall or whatever
                            }
                               if (StructureArray[j, i] == 4)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                            }
                        }
                    }
                }
            }
        }

        //Making sure tiles arent out of bounds
        private static bool TileCheckSafe(int i, int j)
        {
            if (i > 0 && i < Main.maxTilesX && j > 0 && j < Main.maxTilesY)
                return true;
            return false;
        }
    }
}