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
        Level level = new Level();
        
        public GamePanel(Game1 game, GraphicsDevice graphicsDevice)
        {
            spriteSheet = game.Content.Load<Texture2D>("spriteSheet");
            level.LoadLevel(spriteSheet);

            Entities.BaseEntity.Entities.Add(
                new Player()
                {
                    SpriteSheet = spriteSheet,
                    Direction = new Vector2(1, 1),
                    SpriteRectangle = new Rectangle(0, 8, 8, 8),
                    Position = new Vector2(-4, -4),
                });
        }

        public void Update(GameTime gameTime)
        {
            level.Update(gameTime);

            //foreach (var entity in Entities.BaseEntity.Entities)
            //{
            //    entity.Update(gameTime);
            //}
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);
         
            foreach (var entity in Entities.BaseEntity.Entities)
            {
                entity.Draw(spriteBatch);
            }
        }

    }
}
