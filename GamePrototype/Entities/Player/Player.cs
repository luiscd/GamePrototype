using GamePrototype.Engine;
using GamePrototype.GameWorld;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Reflection.Emit;

namespace GamePrototype.Entities.Player
{
    public class Player : BaseEntity
    {
        InputManager inputManager;

        public Player()
        {
            inputManager = new InputManager();
        }

        public void Update(GameTime gameTime, Level level)
        {
            inputManager.UpdateState();
            var deltaTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            var worldRadius = CalculateWorldRadius(level);

            if (inputManager.IsKeyDown(Keys.Right))
            {
                SetDirectionX(1);
                if (WorldPosition.X / 4 >= (level.WorldWidth * Direction.X))
                {
                    SetDirectionX(0);
                }

                CalculateWorldPositionX(deltaTime);
            }
            else if (inputManager.IsKeyDown(Keys.Left))
            {
                SetDirectionX(-1);
                if (WorldPosition.X / 4 <= level.WorldWidth * Direction.X)
                {
                    SetDirectionX(0);
                }

                CalculateWorldPositionX(deltaTime);
            }

            if (inputManager.IsKeyDown(Keys.Up))
            {
                SetDirectionY(-1);
                if (WorldPosition.Y / 4 <= level.WorldHeight * Direction.Y)
                {
                    SetDirectionY(0);
                }

                CalculateWorldPositionY(deltaTime);
            }
            else if (inputManager.IsKeyDown(Keys.Down))
            {
                SetDirectionY(1);
                if (WorldPosition.Y / 4 >= (level.WorldHeight * Direction.Y))
                {
                    SetDirectionY(0);
                }

                CalculateWorldPositionY(deltaTime);
            }
        }

        public void Draw(SpriteBatch spriteBactch)
        {
            spriteBactch.Draw(SpriteSheet, WorldPosition, SpriteRectangle, Color.White);
        }

        /// <summary>
        /// Method to calculate the radius between the player and the bounds of the level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public int CalculateWorldRadius(Level level)
        {
            //limite da posicao do mundo - posicao do player
            var radius = level.WorldWidth - WorldPosition.X;

           
            return 0;
        }
    }
}
