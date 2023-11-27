using GamePrototype.Engine;
using GamePrototype.GameWorld.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.GameWorld
{
    public class Level
    {
        InputManager inputManager;

        private int[,] bitMap = new int[64, 64];

        public Level(Texture2D spriteSheet)
        {
            inputManager = new InputManager();
            LoadFloorTiles(spriteSheet);
        }

        private void LoadFloorTiles(Texture2D spriteSheet)
        {
            int rows = bitMap.GetLength(0);
            int cols = bitMap.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int value = bitMap[i, j];   

                    BaseTile.Tiles.Add(
                        new FloorTile()
                        {
                            SpriteSheet = spriteSheet,
                            SpriteRectangle = new Rectangle(value * 8, value * 8, 8, 8),
                            TilePosition = new Vector2(i * 8, j * 8)
                        }
                        );
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            float worldSpeed = 0.15f;
            Vector2 direction = new Vector2(1, 1);

            inputManager.UpdateState();

            if (inputManager.IsKeyDown(Keys.Right))
            {
                direction.X = 1;
                foreach (var tile in BaseTile.Tiles)
                {
                    tile.TilePosition = new Vector2(tile.TilePosition.X + (worldSpeed * deltaTime * direction.X), tile.TilePosition.Y);
                }
            }
            else if (inputManager.IsKeyDown(Keys.Left))
            {
                direction.X = -1;
                foreach (var tile in BaseTile.Tiles)
                {
                    tile.TilePosition = new Vector2(tile.TilePosition.X + (worldSpeed * deltaTime * direction.X), tile.TilePosition.Y);
                }
            }

            if (inputManager.IsKeyDown(Keys.Down))
            {
                direction.Y = 1;
                foreach (var tile in BaseTile.Tiles)
                {
                    tile.TilePosition = new Vector2(tile.TilePosition.X, tile.TilePosition.Y + (worldSpeed * deltaTime * direction.Y));
                }
            }
            else if (inputManager.IsKeyDown(Keys.Up))
            {
                direction.Y = -1;
                foreach (var tile in BaseTile.Tiles)
                {
                    tile.TilePosition = new Vector2(tile.TilePosition.X, tile.TilePosition.Y + (worldSpeed * deltaTime * direction.Y));
                }
            }


            //if (inputManager.IsKeyDown(Keys.Right))
            //{
            //    direction.X = 1;

            //    float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //    position.X += Speed * deltaTime * Direction.X;

            //    SetDirectionX(1);
            //    CalculateWorldPositionX(gameTime);
            //}
            //else if (inputManager.IsKeyDown(Keys.Left))
            //{
            //    direction.X = -1;
            //    float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //    position.X += Speed * deltaTime * Direction.X;


            //    SetDirectionX(-1);
            //    CalculateWorldPositionX(gameTime);
            //}

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in BaseTile.Tiles)
            {
                tile.Draw(spriteBatch);
            }
        }

    }
}
