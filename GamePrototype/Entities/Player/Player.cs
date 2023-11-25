using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Entities.Player
{
    public class Player : BaseEntity
    {

        InputManager inputManager;

        public Player(Vector2 position)
        {
            inputManager = new InputManager();
            SpriteRectangle = new Rectangle(0, 0, 8, 8);
            EntityRectangle = new Rectangle((int)position.X, (int)position.Y, 24, 24);           
        }

        public override void Update(GameTime gameTime)
        {
            inputManager.UpdateState();

            if (inputManager.IsKeyDown(Keys.Right))
            {
                SetDirectionX(1);
                CalculateWorldPositionX(gameTime);
            }
            else if (inputManager.IsKeyDown(Keys.Left))
            {
                SetDirectionX(-1);
                CalculateWorldPositionX(gameTime);
            }

            if (inputManager.IsKeyDown(Keys.Up))
            {
                SetDirectionY(-1);
                CalculateWorldPositionY(gameTime);
            }
            else if (inputManager.IsKeyDown(Keys.Down))
            {
                SetDirectionY(1);
                CalculateWorldPositionY(gameTime);
            }

            base.Update(gameTime);  
        }
    }
}
