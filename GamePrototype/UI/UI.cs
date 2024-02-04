using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.UI
{
    public class UI
    {
        private List<ItemBox> items = new List<ItemBox>();
        public Vector2 Position { get; set; }

        public UI(Texture2D spriteSheet)
        {
            Position = new Vector2(Game1.WIDTH / 2 - 16, Game1.HEIGHT - 3 * 16);
                        
            for (int i = 0; i < 5; i++)
            {
                items.Add(new ItemBox() {
                    SpriteSheet = spriteSheet,
                    Position = Position, //new Vector2(Game1.WIDTH / 2 + i * 16, Game1.HEIGHT - 3 * 16),
                    IsSelected = false,
                });
            }
        }
        

        public void Update(GameTime gameTime)
        {

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in items)
            {
                item.Draw(spriteBatch);
            }
        }

    }
}
