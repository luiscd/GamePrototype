using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GamePrototype.Entities.Player
{
    public class Player : BaseEntity
    {
        InputManager inputManager;

        public Player()
        {
            inputManager = new InputManager();
        }

        public void Update(GameTime gameTime)
        {
            var deltaTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            inputManager.UpdateState();

            if (inputManager.IsKeyDown(Keys.Right))
            {
                SetDirectionX(1);
                CalculateWorldPositionX(deltaTime);
            }
            else if (inputManager.IsKeyDown(Keys.Left))
            {
                SetDirectionX(-1);
                CalculateWorldPositionX(deltaTime);
            }

            if (inputManager.IsKeyDown(Keys.Up))
            {
                SetDirectionY(-1);
                CalculateWorldPositionY(deltaTime);
            }
            else if (inputManager.IsKeyDown(Keys.Down))
            {
                SetDirectionY(1);
                CalculateWorldPositionY(deltaTime);
            }
        }

        public void Draw(SpriteBatch spriteBactch)
        {
            spriteBactch.Draw(SpriteSheet, WorldPosition, SpriteRectangle, Color.White);
        }
    }
}
