using GamePrototype.Engine;
using GamePrototype.Entities.Actions;
using GamePrototype.Entities.Mob;
using GamePrototype.Entities.Player;
using GamePrototype.GameWorld;
using GamePrototype.GameWorld.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace GamePrototype
{
    public class Screen
    {
        private Level level;
        public Engine.Engine engine;
        public Camera camera;
        public Player player;
        private Phantom phantom;
        int spriteRadius = 8;

        Die die;

        public Screen()
        {
            level = new Level();
            level.LoadLevel();
            engine = new Engine.Engine(level);

            var playerEntity = engine.configReader.LoadEntities().FirstOrDefault(entity => entity.Type == 0);
            player = new Player()
            {
                //SpriteSheet = spriteSheet,
                Speed = 0.12f,
                Direction = new Vector2(0, 0),
                WorldPosition = new Vector2(-spriteRadius, -spriteRadius),
                Name = playerEntity.Name,
                AttackDamage = playerEntity.AttackDamage,
                Health = playerEntity.Health,
                Mana = playerEntity.Mana,
                Level = 1
            };

            LoadMob();
        }

        public void LoadMob()
        {
            var mobEntity = engine.configReader.LoadEntities().FirstOrDefault(e => e.Type == 1);
            //for (int i = 0; i < 2; i++)
            //{
            Mob.Mobs.Add(new Phantom()
            {
                Speed = 0.05f,
                Direction = new Vector2(0, 0),
                WorldPosition = new Vector2(0, 0),
                Name = mobEntity.Name,
                AttackDamage = mobEntity.AttackDamage,
                Health = mobEntity.Health,
                Mana = mobEntity.Mana,
                Level = 1
            });

            //Mob.Mobs.Add(new Spider()
            //{
            //    Speed = 0.05f,
            //    Direction = new Vector2(0, 0),
            //    WorldPosition = new Vector2(0, 0),
            //    Name = mobEntity.Name,
            //    AttackDamage = mobEntity.AttackDamage,
            //    Health = mobEntity.Health,
            //    Mana = mobEntity.Mana,
            //    Level = 1
            //});
            //}
        }

        public void Update(GameTime gameTime)
        {
            level.Update(gameTime);
            player.Update(gameTime);

            foreach (var mob in Mob.Mobs)
            {
                mob.Update(gameTime);

                if (mob.IsDead)
                {
                    die = new Die(mob.Direction)
                    {
                        IsAnimationPlaying = true,
                        Position = mob.WorldPosition,
                        SpriteArray = mob.SpriteArrayDie,
                    };
                }
            }

            if (die != null)
            {
                die?.Update(gameTime);
                if (!die.IsAnimationPlaying)
                    die = null;
            }

            Mob.Mobs.RemoveAll(entity => entity.IsDead);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);
            player.Draw(spriteBatch);

            foreach (var mob in Mob.Mobs)
            {
                mob.Draw(spriteBatch);
            }

            die?.Draw(spriteBatch);
        }

    }
}
