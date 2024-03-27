using GamePrototype.Engine;
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
        public Rectangle SelectedSprite { get; set; }
        public bool IsFree { get; set; }    
        public int Dmg { get; set; }

        public ItemBox()
        {
            SpriteSheet = GlobalVariables.LoadSpriteSheet();
            TileSize = 16;
            Sprite = new Rectangle(0, 208, TileSize, TileSize);
            SelectedSprite = new Rectangle(0, 224, TileSize, TileSize);
            IsFree = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, Position, IsSelected ? SelectedSprite : Sprite, Color.White);
        }
    }
}
