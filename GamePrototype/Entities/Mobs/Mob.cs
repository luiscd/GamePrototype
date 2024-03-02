using GamePrototype.Engine;
using GamePrototype.Entities.Actions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GamePrototype.Entities.Mob
{
    public class Mob : BaseEntity
    {
        public static List<Mob> Mobs = new List<Mob>();

        int actionLocker;

        public Animation animation;
        CollisionHandler collisionHandler;
        GameTime gameTime;

        public Rectangle[] SpriteArrayIdle { get; set; }
        public Rectangle[] SpriteArrayMovement { get; set; }

        public Rectangle[] SpriteArrayHit { get; set; }

        public Mob()
        {
            animation = new Animation()
            {
                TimeToUpdate = 0.20f
            };

            collisionHandler = new CollisionHandler();
        }

        public void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
            var deltaTime = gameTime.ElapsedGameTime.TotalMilliseconds;

            animation.Update(this.gameTime, SpriteArray);

            RandomMovement();
            CalculateWorldPositionX(deltaTime);
            CalculateWorldPositionY(deltaTime);
            CollisionHandle();
            ResetSprite();

            if (IsDeadMethod())
                IsDead = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, WorldPosition, SpriteArray[animation.frameIndex], Color.White, 0f, Vector2.Zero, 1f, Effect, 0.0f);
        }

        private void CollisionHandle()
        {
            if (collisionHandler.HandleCollisionsWorld(this))
                SetLastPosition();
        }

        private void ResetSprite()
        {
            if (animation.frameIndex == SpriteArray.Length - 1)
            {
                animation.frameIndex = 0;
                SpriteArray = SpriteArrayIdle;
            }
        }

        private void RandomMovement()
        {
            actionLocker++;

            if (actionLocker == 120)
            {
                Random random = new Random();
                int randomValue = random.Next(100);

                if (randomValue <= 25)
                {
                    Effect = SpriteEffects.None;
                    SetDirectionX(1);
                    SetDirectionY(0);
                }

                if (randomValue > 25 && randomValue <= 50)
                {
                    Effect = SpriteEffects.FlipHorizontally;
                    SetDirectionX(-1);
                    SetDirectionY(0);
                }

                if (randomValue > 50 && randomValue <= 75)
                {
                    SetDirectionX(0);
                    SetDirectionY(1);
                }

                if (randomValue > 75 && randomValue <= 100)
                {
                    SetDirectionX(0);
                    SetDirectionY(-1);
                }

                actionLocker = 0;
            }
        }

        public void HandleHit()
        {
            SpriteArray = SpriteArrayHit;
            TakeDamage(2);
        }

        private void TakeDamage(int attackDmg)
        {
            Health -= attackDmg;
        }

        private void DropLoot()
        {

        }

    }
}
