using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.UI
{
    public class ActionBar
    {
        private List<ItemBox> items = new List<ItemBox>();

        public ActionBar(Texture2D spriteSheet) {

            for (int i = 0; i < 5; i++)
            {
                items.Add(new ItemBox()
                {
                    SpriteSheet = spriteSheet,
                    //Position = Position, //new Vector2(Game1.WIDTH / 2 + i * 16, Game1.HEIGHT - 3 * 16),
                    IsSelected = false,
                });
            }
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
