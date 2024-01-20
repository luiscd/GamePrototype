using GamePrototype.Engine;
using GamePrototype.GameWorld;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace GamePrototype.Entities.Player
{
    public class Player : BaseEntity
    {
        private bool isIdle;
        private Rectangle[] spriteArray = new Rectangle[6];
        private KeyboardState previousKeyboardState;
        
        InputManager inputManager;
        Animation animation;

        public Player() : base()
        {
            inputManager = new InputManager();
            animation = new Animation();
            Effect = SpriteEffects.None;
            SpriteSize = 16;

            //
            //Down movement animation
            //
            SpriteArrayDown = new Rectangle[6];
            SpriteArrayDown[0] = new Rectangle(192, 0, 16, 16);
            SpriteArrayDown[1] = new Rectangle(208, 0, 16, 16);
            SpriteArrayDown[2] = new Rectangle(224, 0, 16, 16);
            SpriteArrayDown[3] = new Rectangle(240, 0, 16, 16);
            SpriteArrayDown[4] = new Rectangle(256, 0, 16, 16);
            SpriteArrayDown[5] = new Rectangle(272, 0, 16, 16);

            //
            //Down idle animation
            //
            SpriteArrayIdleDown = new Rectangle[6];
            SpriteArrayIdleDown[0] = new Rectangle(192, 16, 16, 16);
            SpriteArrayIdleDown[1] = new Rectangle(208, 16, 16, 16);
            SpriteArrayIdleDown[2] = new Rectangle(224, 16, 16, 16);
            SpriteArrayIdleDown[3] = new Rectangle(240, 16, 16, 16);
            SpriteArrayIdleDown[4] = new Rectangle(256, 16, 16, 16);
            SpriteArrayIdleDown[5] = new Rectangle(272, 16, 16, 16);

            //
            //Movement right animation
            //
            SpriteArrayRight = new Rectangle[6];
            SpriteArrayRight[0] = new Rectangle(192, 32, 16, 16);
            SpriteArrayRight[1] = new Rectangle(208, 32, 16, 16);
            SpriteArrayRight[2] = new Rectangle(224, 32, 16, 16);
            SpriteArrayRight[3] = new Rectangle(240, 32, 16, 16);
            SpriteArrayRight[4] = new Rectangle(256, 32, 16, 16);
            SpriteArrayRight[5] = new Rectangle(272, 32, 16, 16);

            //
            //Rigth idle animation
            //
            SpriteArrayIdleRight = new Rectangle[6];
            SpriteArrayIdleRight[0] = new Rectangle(192, 48, 16, 16);
            SpriteArrayIdleRight[1] = new Rectangle(208, 48, 16, 16);
            SpriteArrayIdleRight[2] = new Rectangle(224, 48, 16, 16);
            SpriteArrayIdleRight[3] = new Rectangle(240, 48, 16, 16);
            SpriteArrayIdleRight[4] = new Rectangle(256, 48, 16, 16);
            SpriteArrayIdleRight[5] = new Rectangle(272, 48, 16, 16);

            //
            //Up movement animation
            //
            SpriteArrayUp = new Rectangle[6];
            SpriteArrayUp[0] = new Rectangle(192, 64, 16, 16);
            SpriteArrayUp[1] = new Rectangle(208, 64, 16, 16);
            SpriteArrayUp[2] = new Rectangle(224, 64, 16, 16);
            SpriteArrayUp[3] = new Rectangle(240, 64, 16, 16);
            SpriteArrayUp[4] = new Rectangle(256, 64, 16, 16);
            SpriteArrayUp[5] = new Rectangle(272, 64, 16, 16);

            //
            //Up idle animation
            //
            SpriteArrayIdleUp = new Rectangle[6];
            SpriteArrayIdleUp[0] = new Rectangle(192, 80, 16, 16);
            SpriteArrayIdleUp[1] = new Rectangle(208, 80, 16, 16);
            SpriteArrayIdleUp[2] = new Rectangle(224, 80, 16, 16);
            SpriteArrayIdleUp[3] = new Rectangle(240, 80, 16, 16);
            SpriteArrayIdleUp[4] = new Rectangle(256, 80, 16, 16);
            SpriteArrayIdleUp[5] = new Rectangle(272, 80, 16, 16);

            spriteArray = SpriteArrayIdleDown;

        }

        public void Update(GameTime gameTime, Engine.Engine engine)
        {
            var deltaTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            inputManager.UpdateState();

            if (inputManager.IsKeyDown(Keys.Right))
            {
                inputManager.SaveLastKeyPressed(Keys.Right);
                spriteArray = SpriteArrayRight;
                Effect = SpriteEffects.None;
                SetDirectionX(1);

                //if (WorldPosition.X >= engine.GetWorldEdgeX((int)Direction.X, -4))
                //    SetDirectionX(0);

                CalculateWorldPositionX(deltaTime);
            }
            else if (inputManager.IsKeyDown(Keys.Left))
            {
                inputManager.SaveLastKeyPressed(Keys.Left);
                spriteArray = SpriteArrayRight;
                Effect = SpriteEffects.FlipHorizontally;
                SetDirectionX(-1);

                //if (WorldPosition.X <= engine.GetWorldEdgeX((int)Direction.X, 1))
                //    SetDirectionX(0);

                CalculateWorldPositionX(deltaTime);
            }

            if (inputManager.IsKeyDown(Keys.Up))
            {
                inputManager.SaveLastKeyPressed(Keys.Up);
                spriteArray = SpriteArrayUp;
                SetDirectionY(-1);

                //if (WorldPosition.Y <= engine.GetWorldEdgeY((int)Direction.Y, 1))
                //    SetDirectionY(0);

                CalculateWorldPositionY(deltaTime);
            }
            else if (inputManager.IsKeyDown(Keys.Down))
            {
                inputManager.SaveLastKeyPressed(Keys.Down);
                spriteArray = SpriteArrayDown;
                SetDirectionY(1);

                //if (WorldPosition.Y >= engine.GetWorldEdgeY((int)Direction.Y, -4))
                //    SetDirectionY(0);

                CalculateWorldPositionY(deltaTime);
            }

            if (inputManager.IsKeyPressedEqual(Keys.Right) && inputManager.IsKeyUp(Keys.Right) ||
                inputManager.IsKeyPressedEqual(Keys.Left) && inputManager.IsKeyUp(Keys.Left))
            {
                spriteArray = SpriteArrayIdleRight;
            }

            if (inputManager.IsKeyPressedEqual(Keys.Down) && inputManager.IsKeyUp(Keys.Down))
            {
                spriteArray = SpriteArrayIdleDown;
            }

            if (inputManager.IsKeyPressedEqual(Keys.Up) && inputManager.IsKeyUp(Keys.Up))
            {
                spriteArray = SpriteArrayIdleUp;
            }

            animation.Update(gameTime, spriteArray);
        }

        public void Draw(SpriteBatch spriteBactch)
        {
            spriteBactch.Draw(SpriteSheet, WorldPosition, spriteArray[animation.frameIndex], Color.White, 0f, Vector2.Zero, 1f, Effect, 0.0f);
        }

    }
}
