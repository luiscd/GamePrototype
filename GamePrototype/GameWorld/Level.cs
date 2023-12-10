using GamePrototype.Engine;
using GamePrototype.Entities;
using GamePrototype.Entities.Mob;
using GamePrototype.GameWorld.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            chunkSize = 16;
            worldSize = 10;
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
        }


        void PopulateWorld(int[,] world, int chunkSize, int worldSize)
        {
            for (int i = 0; i < worldSize; i++)
            {
                for (int j = 0; j < worldSize; j++)
                {
                    int[,] chunk = new int[chunkSize, chunkSize];
                    PlaceChunkInWorld(world, chunk, chunkSize, worldSize, i, j);
                }
            }
        }

        void PlaceChunkInWorld(int[,] world, int[,] chunk, int chunkSize, int worldSize, int xIndex, int yIndex)
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

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            float worldSpeed = 0.10f;
            Vector2 direction = new Vector2(1, 1);

            inputManager.UpdateState();

            if (inputManager.IsKeyDown(Keys.Right))
            {
                direction.X = -1;
                mapPosition.X = CalculateMapPositionX(worldSpeed, deltaTime, direction);
            }
            else if (inputManager.IsKeyDown(Keys.Left))
            {
                direction.X = 1;
                mapPosition.X = CalculateMapPositionX(worldSpeed, deltaTime, direction);

            }

            if (inputManager.IsKeyDown(Keys.Down))
            {
                direction.Y = -1;
                mapPosition.Y = CalculateMapPositionY(worldSpeed, deltaTime, direction);

            }
            else if (inputManager.IsKeyDown(Keys.Up))
            {
                direction.Y = 1;
                mapPosition.Y = CalculateMapPositionY(worldSpeed, deltaTime, direction);
            }

            foreach (var tile in BaseTile.Tiles)
            {
                if ()
                {
                    tile.TilePosition += new Vector2(mapPosition.X, mapPosition.Y);
                }
            }

            //foreach (var mob in Mob.Mobs)
            //{
            //    mob.Position = mapPosition;
            //}
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in BaseTile.Tiles)
            {
                if ((tile.TilePosition.X < (chunkSize + tile.TileSize) * tile.TileSize) &&
                    (tile.TilePosition.X > -(chunkSize + tile.TileSize) * tile.TileSize) &&
                    (tile.TilePosition.Y < chunkSize * tile.TileSize) &&
                    (tile.TilePosition.Y > -(chunkSize + 1) * tile.TileSize))
                {
                    tile.Draw(spriteBatch);
                }

            }
        }

    }
}
