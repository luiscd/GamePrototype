using GamePrototype.GameWorld.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace GamePrototype.GameWorld
{
    public class Level
    {
        private int worldSize;
        private int chunkSize;
        

        public int TileRadius { get; set; }
        public int WorldWidth { get; set; }
        public int WorldHeight { get; set; }
        private int[,] world;

        public static List<BaseTile> VisibleTiles = new List<BaseTile>();

        public Level()
        {
            chunkSize = 16;
            worldSize = 4;
            TileRadius = 8;
            WorldWidth = chunkSize * worldSize;
            WorldHeight = chunkSize * worldSize;
        }

        public void LoadLevel(Texture2D spriteSheet)
        {
            int tileSize = 16;
            
            world = new int[chunkSize * worldSize, chunkSize * worldSize];
            int xOffset = (worldSize * chunkSize * tileSize) / 2;
            int yOffset = (worldSize * chunkSize * tileSize) / 2;

            PopulateWorld(world, chunkSize, worldSize);

            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    int value = world[i, j];

                    BaseTile.Tiles.Add(
                        new FloorTile()
                        {
                            TileSize = tileSize,
                            TileOffsetX = xOffset,
                            TileOffsetY = yOffset,
                            SpriteSheet = spriteSheet, // Make sure you have spriteSheet defined
                            SpriteRectangle = new Rectangle(value * tileSize, value * tileSize, tileSize, tileSize),
                            TilePosition = new Vector2((j * tileSize) - xOffset, (i * tileSize) - yOffset)
                        });
                }
            }
        }

        private static void PopulateWorld(int[,] world, int chunkSize, int worldSize)
        {
            Debug.WriteLine(chunkSize);

            for (int i = 0; i < worldSize; i++)
            {
                for (int j = 0; j < worldSize; j++)
                {
                    int[,] chunk = new int[chunkSize, chunkSize];
                    PlaceChunkInWorld(world, chunk, chunkSize, i, j);
                }
            }
        }

        private static void PlaceChunkInWorld(int[,] world, int[,] chunk, int chunkSize, int xIndex, int yIndex)
        {
            for (int i = 0; i < chunkSize; i++)
            {
                for (int j = 0; j < chunkSize; j++)
                {
                    world[xIndex * chunkSize + i, yIndex * chunkSize + j] = chunk[i, j];
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in VisibleTiles)
            {
                tile.Draw(spriteBatch);
            }
        }

    }
}
