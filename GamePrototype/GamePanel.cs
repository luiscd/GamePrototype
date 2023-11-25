using GamePrototype.Entities.Mob;
using GamePrototype.Entities.Player;
using GamePrototype.GameWorld;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamePrototype
{
    public class GamePanel
    {
        Texture2D spriteSheet;
        Level level;
        Player player;
        Zombie zombie;
        
        int spriteSize = 16;
        int entitySize = 32;

        public GamePanel(Game1 game, GraphicsDevice graphicsDevice)
        {
            spriteSheet = game.Content.Load<Texture2D>("spriteSheet");
            level = new Level(spriteSheet);

            //(1024 / 2) - 16, (768 / 2) - 16)
            player = new Player(new Vector2(500,500))
            {
                Speed = 0.15f,
                Direction = new Vector2(1, 1),
                SpriteSheet = spriteSheet,
                SpriteSize = spriteSize,
            };

            zombie = new Zombie()
            {
                Speed = 0.15f,
                Direction = new Vector2(1, 1),
                SpriteSheet = spriteSheet,
                SpriteSize = spriteSize,
                SpriteRectangle = new Rectangle(0, 0, spriteSize, spriteSize),
                EntityRectangle = new Rectangle(100 - 16, 100 - 16, entitySize, entitySize),
            };

            Entities.BaseEntity.Entities.Add(player);
            Entities.BaseEntity.Entities.Add(zombie);
        }

        public void Update(GameTime gameTime)
        {
            level.Update(gameTime);
            //player.Update(gameTime);

            //foreach (var entity in Entities.BaseEntity.Entities)
            //{
            //    entity.Update(gameTime);
            //}
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);
            //player.Draw(spriteBatch);
            //foreach (var entity in Entities.BaseEntity.Entities)
            //{
            //    entity.Draw(spriteBatch);
            //}
        }

    }
}
