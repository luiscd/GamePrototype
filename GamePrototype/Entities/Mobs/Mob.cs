using GamePrototype.Engine;
using GamePrototype.Entities.Actions;
using GamePrototype.Objects;
using GamePrototype.Objects.Loot.Consumables;
using GamePrototype.Objects.Loot.Currencies;
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

        int actionLocker;

        CollisionHandler collisionHandler;
        GameTime gameTime;

        public static List<Mob> Mobs = new List<Mob>();
        public Animation animation;
        public Hit hit;

        public Rectangle[] SpriteArrayIdle { get; set; }
        public Rectangle[] SpriteArrayMovement { get; set; }
        public Rectangle[] SpriteArrayHit { get; set; }

        private bool isBoss;
        public bool IsBoss
        {
            get { return isBoss; }
            set { isBoss = value; }
        }

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

            CalculateWorldPositionX(deltaTime);
            CalculateWorldPositionY(deltaTime);

            if (IsCloserToPlayer())
            {
                ChasePlayer();
            }
            else
            {
                RandomMovement();
            }

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
                //DropXp();
                DropLoot();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!animation.IsPaused)
            {
                spriteBatch.Draw(SpriteSheet, WorldPosition, SpriteArray[animation.FrameIndex], Color.White, 0f, Vector2.Zero, 1f, Effect, 0.0f);
            }

            if (animation.IsPaused)
            {
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

        private bool IsCloserToPlayer()
        {
            var playerPosition = Player.Player.GetPlayerPosition();
            var aggroRadius = 70;
            var distance = Vector2.Distance(WorldPosition, playerPosition);
            return distance < aggroRadius;
        }

        private void ChasePlayer()
        {
            var playerPosition = Player.Player.GetPlayerPosition();
            var playerDirection = playerPosition - WorldPosition;
            playerDirection.Normalize();
            SetDirectionX(playerDirection.X > 0 ? 1 : -1);
            SetDirectionY(playerDirection.Y > 0 ? 1 : -1);
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
                    SetDirectionX(1);
                    SetDirectionY(0);
                }

                if (randomValue > 25 && randomValue <= 50)
                {
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

        private void DropXp()
        {

        }

        private void DropLoot()
        {
            var lootValue = RandomEnumValue<LootEnum>();

            switch (lootValue)
            {
                case LootEnum.HEALTH_POTION:
                    Objects.Object.Loot.Add(new HealthPotion()
                    {
                        Position = new Vector2(WorldPosition.X, WorldPosition.Y),
                        CollisionBox = new Rectangle((int)WorldPosition.X, (int)WorldPosition.Y, 16, 16),
                    });
                    break;

                case LootEnum.MANA_POTION:
                    Objects.Object.Loot.Add(new ManaPotion()
                    {
                        Position = new Vector2(WorldPosition.X, WorldPosition.Y),
                        CollisionBox = new Rectangle((int)WorldPosition.X, (int)WorldPosition.Y, 16, 16),
                    });
                    break;

                case LootEnum.FOOD:
                    Objects.Object.Loot.Add(new Food()
                    {
                        Position = new Vector2(WorldPosition.X, WorldPosition.Y),
                        CollisionBox = new Rectangle((int)WorldPosition.X, (int)WorldPosition.Y, 16, 16),
                    });
                    break;

                case LootEnum.GOLD:
                    Objects.Object.Loot.Add(new Gold()
                    {
                        Position = new Vector2(WorldPosition.X, WorldPosition.Y),
                        CollisionBox = new Rectangle((int)WorldPosition.X, (int)WorldPosition.Y, 16, 16),
                    });
                    break;

                default:
                    break;
            }

        }

        private static T RandomEnumValue<T>()
        {
            Random rand = new Random();
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(rand.Next(v.Length));
        }
    }
}
