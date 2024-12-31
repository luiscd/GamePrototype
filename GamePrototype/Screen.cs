using GamePrototype.Engine;
using GamePrototype.Entities.Actions;
using GamePrototype.Entities.Mob;
using GamePrototype.Entities.Player;
using GamePrototype.GameWorld;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using GamePrototype.Objects.Misc;

namespace GamePrototype
{
    public class Screen
    {
        public Engine.Engine engine;

        public static List<Mob> VisibleMobList = new List<Mob>();

        private Level level;
        public Camera camera;
        public Player player;
        public Chest chest;  
        private Phantom phantom;
        int spriteRadius = 8;

        Die die;
        InputManager inputManager;

        /// <summary>
        /// Constructor
        /// </summary>
        public Screen()
        {
            inputManager = new InputManager();
            level = new Level();
            level.LoadLevel();
            engine = new Engine.Engine(level);

            //LoadMob();
            LoadChest();

            LoadPlayer();
        }

        #region Public Methods

        public void Update(GameTime gameTime)
        {
            level.Update(gameTime);
            player.Update(gameTime);
            chest.Update(gameTime);

            foreach (var mob in Mob.Mobs)
            {
                mob.Update(gameTime);

                if (IsMobDead(mob))
                {
                    CreateDieAction(mob);
                }

                if (die != null)
                {
                    die?.Update(gameTime);
                    if (!die.IsAnimationPlaying)
                        die = null;
                }
            }

            RemoveDeadMobs();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);
            
            foreach (var mob in VisibleMobList)
            {
                mob.Draw(spriteBatch);
            }

            chest.Draw(spriteBatch);

            foreach (var loot in Objects.Object.Loot)
            {
                loot.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);

            die?.Draw(spriteBatch);
        }

        #endregion


        #region Private Methods

        private void CreateDieAction(Mob mob)
        {
            die = new Die(mob.Direction)
            {
                IsAnimationPlaying = true,
                Position = mob.WorldPosition,
                SpriteArray = mob.SpriteArrayDie,
            };
        }

        private bool IsMobDead(Mob mob)
        {
            return mob.IsDead;
        }

        private void RemoveDeadMobs()
        {
            Mob.Mobs.RemoveAll(entity => entity.IsDead);
        }

        private void LoadPlayer()
        {
            //var playerEntity = engine.configReader.LoadEntities().FirstOrDefault(entity => entity.Type == 0);
            player = new Player()
            {
                Speed = 0.11f,
                Direction = new Vector2(0, 0),
                WorldPosition = new Vector2(-spriteRadius, -spriteRadius),
                Name = "player",
                AttackDamage = 2,
                Health = 20,
                Mana = 10,
                Level = 1
            };
        }

        private void LoadMob()
        {
            //var mobEntity = engine.configReader.LoadEntities().FirstOrDefault(e => e.Type == 1);
            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                Mob.Mobs.Add(new Phantom()
                {
                    Speed = 0.05f,
                    Direction = new Vector2(0, 0),
                    WorldPosition = new Vector2(random.Next(-level.WorldWidth, level.WorldWidth), random.Next(-level.WorldHeight, level.WorldHeight)),
                    Name = "Panthom", //mobEntity.Name,
                    AttackDamage = 2, //mobEntity.AttackDamage,
                    Health = 50, //mobEntity.Health,
                    Mana = 10, //mobEntity.Mana,
                    Level = 1
                });

                Mob.Mobs.Add(new Spider()
                {
                    Speed = 0.05f,
                    Direction = new Vector2(0, 0),
                    WorldPosition = new Vector2(0, 0),
                    Name = "Spider", // mobEntity.Name,
                    AttackDamage = 10, //mobEntity.AttackDamage,
                    Health = 15, //mobEntity.Health,
                    Mana = 10, //mobEntity.Mana,
                    Level = 1
                });
            }
        }

        private void LoadChest()
        {
            chest = new Chest()
            {
                Position = new Vector2(100, 100),  
            };
        }

        #endregion

    }

}
