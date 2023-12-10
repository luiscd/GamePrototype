using GamePrototype.Entities.Mob;
using GamePrototype.Entities.Player;
using GamePrototype.GameWorld;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace GamePrototype
{
    public class GamePanel
    {
        Texture2D spriteSheet;
        Level level = new Level();

        public GamePanel(Game1 game, GraphicsDevice graphicsDevice)
        {
            spriteSheet = game.Content.Load<Texture2D>("spriteSheet");

            Entities.BaseEntity.Entities.Add(
                new Player()
                {
                    IsMob = false,
                    SpriteSheet = spriteSheet,
                    Direction = new Vector2(1, 1),
                    SpriteRectangle = new Rectangle(0, 8, 8, 8),
                    Position = new Vector2(-4, -4),
                });

            Mob.Mobs.Add(
                new Zombie()
                {
                    IsMob = true,
                    SpriteSheet = spriteSheet,
                    Direction = new Vector2(1, 1),
                    SpriteRectangle = new Rectangle(0, 8, 8, 8),
                    Position = new Vector2(50, 50),
                });



            level.LoadLevel(spriteSheet);
        }

        public void Update(GameTime gameTime)
        {
            level.Update(gameTime);

            //foreach (var entity in Entities.BaseEntity.Entities)
            //{
            //    entity.Update(gameTime);
            //}

            foreach (var mob in Mob.Mobs)
            {
                mob.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);

            foreach (var mob in Mob.Mobs)
            {
                mob.Draw(spriteBatch);
            }
        }

    }
}
