using GamePrototype.Engine;
using GamePrototype.GameWorld;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Security.Authentication;

namespace GamePrototype.Entities.Player
{
    public class Player : BaseEntity
    {
        InputManager inputManager;
        Animation animation;

        private Rectangle[] spriteArray = new Rectangle[6];

        public Player() : base()
        {
            inputManager = new InputManager();
            animation = new Animation();

            //
            //Down movement animation
            //
            SpriteArrayDown = new Rectangle[6];
            SpriteArrayDown[0] = new Rectangle(160, 0, 16, 16);
            SpriteArrayDown[1] = new Rectangle(176, 0, 16, 16);
            SpriteArrayDown[2] = new Rectangle(192, 0, 16, 16);
            SpriteArrayDown[3] = new Rectangle(208, 0, 16, 16);
            SpriteArrayDown[4] = new Rectangle(224, 0, 16, 16);
            SpriteArrayDown[5] = new Rectangle(240, 0, 16, 16);

            //
            //Down idle animation
            //
            SpriteArrayIdleDown = new Rectangle[6];
            SpriteArrayIdleDown[0] = new Rectangle(160, 16, 16, 16);
            SpriteArrayIdleDown[1] = new Rectangle(176, 16, 16, 16);
            SpriteArrayIdleDown[2] = new Rectangle(192, 16, 16, 16);
            SpriteArrayIdleDown[3] = new Rectangle(208, 16, 16, 16);
            SpriteArrayIdleDown[4] = new Rectangle(224, 16, 16, 16);
            SpriteArrayIdleDown[5] = new Rectangle(240, 16, 16, 16);

            //
            //Movement right animation
            //
            SpriteArrayRight = new Rectangle[6];
            SpriteArrayRight[0] = new Rectangle(160, 32, 16, 16);
            SpriteArrayRight[1] = new Rectangle(178, 32, 16, 16);
            SpriteArrayRight[2] = new Rectangle(192, 32, 16, 16);
            SpriteArrayRight[3] = new Rectangle(208, 32, 16, 16);
            SpriteArrayRight[4] = new Rectangle(224, 32, 16, 16);
            SpriteArrayRight[5] = new Rectangle(240, 32, 16, 16);


            //
            //Rigt idle animation
            //
            SpriteArrayIdleRight = new Rectangle[6];
            SpriteArrayIdleRight[0] = new Rectangle(160, 48, 16, 16);
            SpriteArrayIdleRight[1] = new Rectangle(178, 48, 16, 16);
            SpriteArrayIdleRight[2] = new Rectangle(192, 48, 16, 16);
            SpriteArrayIdleRight[3] = new Rectangle(208, 48, 16, 16);
            SpriteArrayIdleRight[4] = new Rectangle(224, 48, 16, 16);
            SpriteArrayIdleRight[5] = new Rectangle(240, 48, 16, 16);


            //SpriteArrayIdleRight = new Rectangle[6];
            //for (int i = 0; i < 6; i++)
            //{
            //    SpriteArrayIdleRight[i] = new Rectangle(i * 16, 48, 16, 16);
            //}

            ////Movement left animation
            //SpriteArrayLeft = new Rectangle[6];
            //for (int i = 0; i < 6; i++)
            //{
            //    SpriteArrayLeft[i] = new Rectangle(i * 16, 48, 16, 16);
            //}

            //SpriteArrayIdleLeft = new Rectangle[6];
            //for (int i = 0; i < 6; i++)
            //{
            //    SpriteArrayIdleLeft[i] = new Rectangle(i * 16, 48, 16, 16);
            //}

            spriteArray = SpriteArrayIdleDown;
        }

        public void Update(GameTime gameTime, Level level)
        {
            inputManager.UpdateState();
            var deltaTime = gameTime.ElapsedGameTime.TotalMilliseconds;

            if (inputManager.IsKeyDown(Keys.Right))
            {
                spriteArray = SpriteArrayRight;
                SetDirectionX(1);

                if ((WorldPosition.X / 4) + 2 >= (level.WorldWidth * Direction.X))
                {
                    SetDirectionX(0);
                }

                CalculateWorldPositionX(deltaTime);

            }
            else if (inputManager.IsKeyDown(Keys.Left))
            {
                //spriteArray = SpriteArrayLeft;
                SetDirectionX(-1);
                if (WorldPosition.X / 4 <= level.WorldWidth * Direction.X)
                {
                    SetDirectionX(0);
                }

                CalculateWorldPositionX(deltaTime);
            }

            if (inputManager.IsKeyDown(Keys.Up))
            {
                //spriteArray = SpriteArrayUp;
                SetDirectionY(-1);
                if (WorldPosition.Y / 4 <= level.WorldHeight * Direction.Y)
                {
                    SetDirectionY(0);
                }

                CalculateWorldPositionY(deltaTime);
            }
            else if (inputManager.IsKeyDown(Keys.Down))
            {
                spriteArray = SpriteArrayDown;
                SetDirectionY(1);
                if (WorldPosition.Y / 4 + 2 >= (level.WorldHeight * Direction.Y))
                {
                    SetDirectionY(0);
                }

                CalculateWorldPositionY(deltaTime);
            }

            animation.Update(gameTime, spriteArray);        
        }

        public void Draw(SpriteBatch spriteBactch)
        {
            spriteBactch.Draw(SpriteSheet, WorldPosition, spriteArray[animation.frameIndex], Color.White);
        }

    }
}
