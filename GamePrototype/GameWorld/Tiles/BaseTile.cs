using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.GameWorld.Tiles
{
    public class BaseTile
    {

        public static List<BaseTile> Tiles = new List<BaseTile>();
        public Rectangle SpriteRectangle { get; set; }
        //public Rectangle TileRectangle { get; set; }
        public int TileSize { get; set; }
        public Vector2 TilePosition { get; set; }
        public Texture2D SpriteSheet { get; set; }

        public BaseTile()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, TilePosition, SpriteRectangle, Color.White);
        }

    }
}
