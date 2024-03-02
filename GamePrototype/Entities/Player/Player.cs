using GamePrototype.Engine;
using GamePrototype.Entities.Actions;
using GamePrototype.UI.Singulars;
using GamePrototype.UI.UiBars;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace GamePrototype.Entities.Player
{
    public class Player : BaseEntity
    {
        private CollisionHandler collisionHandler;
        InputManager inputManager;
        Animation animation;
        Attack attack;

        private Rectangle[] SpriteArrayAttackDown { get; set; }

        private Rectangle[] SpriteArrayAttack { get; set; }

        public bool IsAttacking { get; set; }

        public Player() : base()
        {
            inputManager = new InputManager();
            collisionHandler = new CollisionHandler();
            animation = new Animation()
            {
                TimeToUpdate = 0.20f,
            };

            Effect = SpriteEffects.None;
            SpriteSize = 16;

            //
            //Down movement animation
            //
            SpriteArrayDown = new Rectangle[6];
            SpriteArrayDown[0] = new Rectangle(192, 0, SpriteSize, SpriteSize);
            SpriteArrayDown[1] = new Rectangle(208, 0, SpriteSize, SpriteSize);
            SpriteArrayDown[2] = new Rectangle(224, 0, SpriteSize, SpriteSize);
            SpriteArrayDown[3] = new Rectangle(240, 0, SpriteSize, SpriteSize);
            SpriteArrayDown[4] = new Rectangle(256, 0, SpriteSize, SpriteSize);
            SpriteArrayDown[5] = new Rectangle(272, 0, SpriteSize, SpriteSize);

            //
            //Down idle animation
            //
            SpriteArrayIdleDown = new Rectangle[6];
            SpriteArrayIdleDown[0] = new Rectangle(192, SpriteSize, SpriteSize, SpriteSize);
            SpriteArrayIdleDown[1] = new Rectangle(208, SpriteSize, SpriteSize, SpriteSize);
            SpriteArrayIdleDown[2] = new Rectangle(224, SpriteSize, SpriteSize, SpriteSize);
            SpriteArrayIdleDown[3] = new Rectangle(240, SpriteSize, SpriteSize, SpriteSize);
            SpriteArrayIdleDown[4] = new Rectangle(256, SpriteSize, SpriteSize, SpriteSize);
            SpriteArrayIdleDown[5] = new Rectangle(272, SpriteSize, SpriteSize, SpriteSize);

            //
            //Movement right animation
            //
            SpriteArrayRight = new Rectangle[6];
            SpriteArrayRight[0] = new Rectangle(192, 32, SpriteSize, SpriteSize);
            SpriteArrayRight[1] = new Rectangle(208, 32, SpriteSize, SpriteSize);
            SpriteArrayRight[2] = new Rectangle(224, 32, SpriteSize, SpriteSize);
            SpriteArrayRight[3] = new Rectangle(240, 32, SpriteSize, SpriteSize);
            SpriteArrayRight[4] = new Rectangle(256, 32, SpriteSize, SpriteSize);
            SpriteArrayRight[5] = new Rectangle(272, 32, SpriteSize, SpriteSize);

            //
            //Rigth idle animation
            //
            SpriteArrayIdleRight = new Rectangle[6];
            SpriteArrayIdleRight[0] = new Rectangle(192, 48, SpriteSize, SpriteSize);
            SpriteArrayIdleRight[1] = new Rectangle(208, 48, SpriteSize, SpriteSize);
            SpriteArrayIdleRight[2] = new Rectangle(224, 48, SpriteSize, SpriteSize);
            SpriteArrayIdleRight[3] = new Rectangle(240, 48, SpriteSize, SpriteSize);
            SpriteArrayIdleRight[4] = new Rectangle(256, 48, SpriteSize, SpriteSize);
            SpriteArrayIdleRight[5] = new Rectangle(272, 48, SpriteSize, SpriteSize);

            //
            //Up movement animation
            //
            SpriteArrayUp = new Rectangle[6];
            SpriteArrayUp[0] = new Rectangle(192, 64, SpriteSize, SpriteSize);
            SpriteArrayUp[1] = new Rectangle(208, 64, SpriteSize, SpriteSize);
            SpriteArrayUp[2] = new Rectangle(224, 64, SpriteSize, SpriteSize);
            SpriteArrayUp[3] = new Rectangle(240, 64, SpriteSize, SpriteSize);
            SpriteArrayUp[4] = new Rectangle(256, 64, SpriteSize, SpriteSize);
            SpriteArrayUp[5] = new Rectangle(272, 64, SpriteSize, SpriteSize);

            //
            //Up idle animation
            //
            SpriteArrayIdleUp = new Rectangle[6];
            SpriteArrayIdleUp[0] = new Rectangle(192, 80, SpriteSize, SpriteSize);
            SpriteArrayIdleUp[1] = new Rectangle(208, 80, SpriteSize, SpriteSize);
            SpriteArrayIdleUp[2] = new Rectangle(224, 80, SpriteSize, SpriteSize);
            SpriteArrayIdleUp[3] = new Rectangle(240, 80, SpriteSize, SpriteSize);
            SpriteArrayIdleUp[4] = new Rectangle(256, 80, SpriteSize, SpriteSize);
            SpriteArrayIdleUp[5] = new Rectangle(272, 80, SpriteSize, SpriteSize);

            SpriteArray = SpriteArrayIdleDown;
        }

        public void Update(GameTime gameTime)
        {
            var deltaTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            inputManager.UpdateState();
            LastPosition = WorldPosition;

            //Right movement animation
            if (inputManager.IsKeyDown(Keys.Right))
            {
                inputManager.SaveLastKeyPressed(Keys.Right);
                MoveRight(deltaTime);
            }
            else if (inputManager.IsLastKeyPressedEqual(Keys.Right) && inputManager.IsKeyUp(Keys.Right) || inputManager.IsLastKeyPressedEqual(Keys.Left) && inputManager.IsKeyUp(Keys.Left))
            {
                SpriteArray = SpriteArrayIdleRight;
            }

            //Left movement animation
            if (inputManager.IsKeyDown(Keys.Left))
            {
                inputManager.SaveLastKeyPressed(Keys.Left);
                MoveLeft(deltaTime);
            }
            else if (inputManager.IsLastKeyPressedEqual(Keys.Right) && inputManager.IsKeyUp(Keys.Right) || inputManager.IsLastKeyPressedEqual(Keys.Left) && inputManager.IsKeyUp(Keys.Left))
            {
                SpriteArray = SpriteArrayIdleRight;
            }

            //Up movement animation
            if (inputManager.IsKeyDown(Keys.Up))
            {
                inputManager.SaveLastKeyPressed(Keys.Up);
                MoveUp(deltaTime);
            }
            else if (inputManager.IsLastKeyPressedEqual(Keys.Up) && inputManager.IsKeyUp(Keys.Up))
            {
                SpriteArray = SpriteArrayIdleUp;
            }

            //Down movement animation
            if (inputManager.IsKeyDown(Keys.Down))
            {
                inputManager.SaveLastKeyPressed(Keys.Down);
                MoveDown(deltaTime);
            }
            else if (inputManager.IsLastKeyPressedEqual(Keys.Down) && inputManager.IsKeyUp(Keys.Down))
            {
                SpriteArray = SpriteArrayIdleDown;
            }

            Attack(gameTime);
            CollisionDetection();
            animation.Update(gameTime, SpriteArray);
        }

        private void Attack(GameTime gameTime)
        {
            //Attack animation
            if (inputManager.IsKeyDown(Keys.Space))
            {
                if (!IsAttacking)
                {
                    IsAttacking = true;
                    inputManager.SaveLastKeyPressed(Keys.Space);
                    attack = new Attack(WorldPosition, Direction)
                    {
                        IsAnimationPlaying = true
                    };
                }
            }
            else
            {
                IsAttacking = false;
            }

            if (attack != null)
            {
                attack?.Update(gameTime);
                if (!attack.IsAnimationPlaying)
                {
                    attack = null;
                }
            }

        }

        private void CollectPowerUp()
        {
            PowerUp.PowerUps.RemoveAll(element => element.IsCollided);
            //TODO: atribuir o tipo de powerup e as suas propriedades
        }

        private void CollisionDetection()
        {
            collisionHandler.HandleCollisionsEntities(this);

            if (collisionHandler.HandleCollisionPowerUps(this))
                CollectPowerUp();

            if (collisionHandler.HandleCollisionsWorld(this))
                SetLastPosition();

            if (attack != null)
                collisionHandler.HandleAttackCollision(attack);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, WorldPosition, SpriteArray[animation.frameIndex], Color.White, 0f, Vector2.Zero, 1f, Effect, 0.0f);
            attack?.Draw(spriteBatch);
        }
    }

}
