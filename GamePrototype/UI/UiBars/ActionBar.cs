using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using GamePrototype.UI.Singulars;

namespace GamePrototype.UI.UiBars
{
    public class ActionBar
    {
        private static List<ItemBox> items = new List<ItemBox>();

        public ActionBar(Texture2D spriteSheet, UI ui)
        {
            for (int i = 0; i < 5; i++)
            {
                items.Add(new ItemBox()
                {
                    SpriteSheet = spriteSheet,
                    Position = new Vector2(ui.ActionBarRectangle.Center.X + i * 18 - 2 * 16, ui.ActionBarRectangle.Y + 6),
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
