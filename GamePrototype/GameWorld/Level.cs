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

        public Level(Texture2D spriteSheet)
        {
            inputManager = new InputManager();
            LoadFloorTiles(spriteSheet);
        }

        private void LoadFloorTiles(Texture2D spriteSheet)
        {
            for (int i = 0; i < Game1.WIDTH / 16; i++)
            {
                for (int j = 0; j < Game1.HEIGHT / 16; j++)
                {
                    BaseTile.Tiles.Add(
                        new FloorTile()
                        {
                            SpriteSheet = spriteSheet,
                            TileSize = 24,
                            SpriteRectangle = new Rectangle(0, 0, 16, 16),
                            TilePosition = new Vector2(i * 16, j * 16)
                        }
                        );
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            float worldSpeed = 0.15f;
            Vector2 direction = new Vector2 (1, 1);

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
