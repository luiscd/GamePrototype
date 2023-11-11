using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype
{
    public class Tile
    {

        public Rectangle SpriteRectangle { get; set; }
        public Rectangle TileRectangle { get; set; }
        public int TileSize { get; set; }
        public Vector2 TilePosition { get; set; }


        public Tile() { }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
