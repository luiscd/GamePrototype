using GamePrototype.Engine;
using GamePrototype.Entities.Actions;
using GamePrototype.Entities.Player;
using GamePrototype.UI.UiBars;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GamePrototype.Entities.Mob
{
    public class Mob : BaseEntity
    {
        public static List<Mob> Mobs = new List<Mob>();

        int actionLocker;

        public Animation animation;
        CollisionHandler collisionHandler;
        GameTime gameTime;
        public Hit hit;

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

            LastPosition = WorldPosition;

            RandomMovement();

            CalculateWorldPositionX(deltaTime);
            CalculateWorldPositionY(deltaTime);

            CollisionHandle();

            if (IsHit)
            {
                HandleHitAction();
            }
            else
            {
                animation.Update(this.gameTime, SpriteArray);
            }

            if (IsDeadMethod())
            {
                IsDead = true;
                DropXp();
                DropLoot();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!animation.IsPaused)
            {
                spriteBatch.Draw(SpriteSheet, WorldPosition, SpriteArray[animation.FrameIndex], Color.White, 0f, Vector2.Zero, 1f, Effect, 0.0f);
            }

            if (animation.IsPaused) {
                hit.Draw(spriteBatch);
            }
        }

        private void HandleHitAction()
        {
            if (hit == null)
            {
                hit = new Hit()
                {
                    Position = WorldPosition,
                    SpriteEffect = Effect,
                    SpriteArray = SpriteArrayHit
                };

                animation.Stop();
                var activeWeapon = ActionBar.Items.FirstOrDefault(item => item.IsSelected);
                TakeDamage(activeWeapon.Dmg);
            }

            hit.Update(gameTime);

            if (!hit.IsAnimationPlaying)
            {
                hit = null;
                IsHit = false;
                animation.Resume();
            }

        }

        private void CollisionHandle()
        {
            if (collisionHandler.HandleCollisionsWorld(this))
                SetLastPosition();
        }

        private void ChasePlayer()
        {
        }

        private void RandomMovement()
        {
            actionLocker++;

            if (actionLocker == 120)
            {
                Random random = new();
                int randomValue = random.Next(100);
                SpriteArray = SpriteArrayMovement;

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
                
        public void TakeDamage(int attackDmg)
        {
            Health -= attackDmg;
        }

        private void DropLoot()
        {

        }

        private void DropXp()
        {

        }
    }
}
