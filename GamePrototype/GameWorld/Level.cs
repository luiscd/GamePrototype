using GamePrototype.Engine;
using GamePrototype.Entities;
using GamePrototype.Entities.Mob;
using GamePrototype.GameWorld.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GamePrototype.GameWorld
{
    public class Level
    {
        InputManager inputManager;
        private int worldSize;
        private int chunkSize;

        private Vector2 mapPosition;

        public Level()
        {
            inputManager = new InputManager();
            mapPosition = new Vector2(0, 0);
        }

        public void LoadLevel(Texture2D spriteSheet)
        {
            chunkSize = 2;
            worldSize = 3;
            int tileSize = 8;
            int[,] world = new int[chunkSize * worldSize, chunkSize * worldSize];
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


            float firstColumnX = GetFirstColumnPositionX(tileSize, chunkSize * worldSize, tileSize);
            // Assuming your tiles have a common Y position (e.g., 0)
            Vector2 firstColumnPosition = new Vector2(firstColumnX, 0);
            Debug.WriteLine(firstColumnPosition);
        }


        void PopulateWorld(int[,] world, int chunkSize, int worldSize)
        {
            for (int i = 0; i < worldSize; i++)
            {
                for (int j = 0; j < worldSize; j++)
                {
                    int[,] chunk = new int[chunkSize, chunkSize];
                    PlaceChunkInWorld(world, chunk, chunkSize, i, j);
                }
            }
        }

        void PlaceChunkInWorld(int[,] world, int[,] chunk, int chunkSize, int xIndex, int yIndex)
        {
            for (int i = 0; i < chunkSize; i++)
            {
                for (int j = 0; j < chunkSize; j++)
                {
                    world[xIndex * chunkSize + i, yIndex * chunkSize + j] = chunk[i, j];
                }
            }
        }

        float CalculateMapPositionX(float worldSpeed, float deltaTime, Vector2 direction)
        {
            return worldSpeed * deltaTime * direction.X;
        }

        float CalculateMapPositionY(float worldSpeed, float deltaTime, Vector2 direction)
        {
            return worldSpeed * deltaTime * direction.Y;
        }


        // Assuming tileSize is the width of each tile, numTilesX is the number of tiles in a row,
        // and tileSpacingX is the spacing between tiles (if any)
        float GetFirstColumnPositionX(float tileSize, int numTilesX, float tileSpacingX)
        {
            // Calculate the total width of the tiles and spacing in the first column
            float firstColumnWidth = (numTilesX - 1) * tileSpacingX + numTilesX * tileSize;

            // Assuming the origin (0, 0) is the top-left corner, the X position of the first column
            // is half the total width, as the tiles are centered
            return -firstColumnWidth / 2;
        }



        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            float worldSpeed = 0.10f;
            Vector2 direction = new Vector2(1, 1);

            inputManager.UpdateState();

            //foreach (var tile in BaseTile.Tiles)
            //{
                //if (inputManager.IsKeyDown(Keys.Right))
                //{
                //    direction.X = -1;
                //    tile.SetTilePosition(new Vector2(tile.TilePosition.X + CalculateMapPositionX(worldSpeed, deltaTime, direction), tile.TilePosition.Y));
                //}
                //else if (inputManager.IsKeyDown(Keys.Left))
                //{
                //    direction.X = 1;
                //    tile.SetTilePosition(new Vector2(tile.TilePosition.X + CalculateMapPositionX(worldSpeed, deltaTime, direction), tile.TilePosition.Y));

                //    if (tile.TilePosition.X > -1000)
                //    {
                //        tile.SetTilePosition(new Vector2(tile.TilePosition.X, tile.TilePosition.Y));
                //    }

                //}

                //if (inputManager.IsKeyDown(Keys.Up))
                //{
                //    direction.Y = 1;
                //    tile.SetTilePosition(new Vector2(tile.TilePosition.X, tile.TilePosition.Y + CalculateMapPositionY(worldSpeed, deltaTime, direction)));
                //}
                //else if (inputManager.IsKeyDown(Keys.Down))
                //{
                //    direction.Y = -1;
                //    tile.SetTilePosition(new Vector2(tile.TilePosition.X, tile.TilePosition.Y + CalculateMapPositionY(worldSpeed, deltaTime, direction)));
                //}


                //foreach (var mob in Mob.Mobs)
                //{
                //    mob.Position = mapPosition;
            //}
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in BaseTile.Tiles)
            {
                //if ((tile.TilePosition.X < (chunkSize + tile.TileSize) * tile.TileSize) &&
                //    (tile.TilePosition.X > -(chunkSize + tile.TileSize) * tile.TileSize) &&
                //    (tile.TilePosition.Y < chunkSize * tile.TileSize) &&
                //    (tile.TilePosition.Y > -(chunkSize + 1) * tile.TileSize))
                //{
                    tile.Draw(spriteBatch);
                //}

            }
        }

    }
}
