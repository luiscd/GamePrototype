using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.UI.Singulars
{
    public class ItemBox
    {
        public Texture2D SpriteSheet { get; set; }
        public bool IsSelected { get; set; }
        public Vector2 Position { get; set; }
        public int TileSize { get; set; }
        public Rectangle Sprite { get; set; }

        public ItemBox()
        {
            TileSize = 16;
            Sprite = new Rectangle(0, 208, TileSize, TileSize);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, Position, Sprite, Color.White);
        }
    }
}
