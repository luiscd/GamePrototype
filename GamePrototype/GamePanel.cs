using GamePrototype.Entities.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype
{
    public class GamePanel
    {
        Texture2D spriteSheet;
        Level level;
        Player player;
        int spriteSize = 8;

        public GamePanel(Game1 game, GraphicsDevice graphicsDevice)
        {
            spriteSheet = game.Content.Load<Texture2D>("spriteSheet");
            level = new Level();
            player = new Player()
            {
                SpriteSheet = spriteSheet,
                SpriteSize = spriteSize,
                SpriteRectangle = new Rectangle(0, 0, spriteSize, spriteSize),
                EntityRectangle = new Rectangle(100, 100, spriteSize, spriteSize),
            };

            Entities.BaseEntity.Entities.Add(player);
        }

        public void Update(GameTime gameTime)
        {
            level.Update(gameTime);
            //player.Update(gameTime);

            foreach (var entity in Entities.BaseEntity.Entities)
            {
                entity.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);
            //player.Draw(spriteBatch);
            foreach (var entity in Entities.BaseEntity.Entities)
            {
                entity.Draw(spriteBatch);
            }
        }

    }
}
