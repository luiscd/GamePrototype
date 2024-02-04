using GamePrototype.Engine;
using GamePrototype.Entities.Player;
using GamePrototype.GameWorld;
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
        int spriteRadius = 8;

        public Screen(Texture2D spriteSheet)
        {
            level = new Level(spriteSheet);
            level.LoadLevel();
            engine = new Engine.Engine(level);

            var playerEntity = engine.configReader.LoadEntities().FirstOrDefault(entity => entity.Type == 0);
            //var zombieEntity = configReader.LoadEntities().FirstOrDefault(e => e.Type == 1);

            player = new Player()
            {
                SpriteSheet = spriteSheet,
                Speed = 0.10f,
                Direction = new Vector2(0, 0),
                WorldPosition = new Vector2(-spriteRadius, -spriteRadius),
                Name = playerEntity.Name,
                AttackDamage = playerEntity.AttackDamage,
                Health = playerEntity.Health,
                Mana = playerEntity.Mana,
                Level = 1
            };


            //zombie = new Zombie()
            //{
            //    SpriteSheet = spriteSheet,
            //    Speed = 0.10f,
            //    Direction = new Vector2(0, 0),
            //    WorldPosition = new Vector2(-spriteRadius, spriteRadius),
            //    Name = zombieEntity.Name,
            //    AttackDamage = zombieEntity.AttackDamage,
            //    Health = zombieEntity.Health,
            //};
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }

    }
}
