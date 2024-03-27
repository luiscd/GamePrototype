using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.GameWorld.Tiles
{
    public class Tile
    {

        public static List<Tile> Tiles = new List<Tile>();
        public static List<Tile> WallTiles = new List<Tile>();

        public Rectangle SpriteRectangle { get; set; }
        public Rectangle CollisionBox { get; set; }

        //public Rectangle TileRectangle { get; set; }

        private int tileSize;
        public int TileSize
        {
            get { return tileSize; }
            set { tileSize = 16; }
        }

        private Vector2 tilePosition;
        public Vector2 TilePosition
        {
            get { return tilePosition; }
            set { tilePosition = value; }
        }

        public Texture2D SpriteSheet { get; set; }
        public bool IsDraw { get; set; }

        public int TileOffsetX { get; set; }
        public int TileOffsetY { get; set; }

        public bool IsWalkable { get; set; }

        public Tile()
        {
            SpriteSheet = GlobalVariables.LoadSpriteSheet();
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, TilePosition, SpriteRectangle, Color.White, 0f, Vector2.Zero, 1f, 0, 0.0f);
        }

        public float GetBottomBoundary()
        {
            return TilePosition.Y + TileSize / 3;
        }

        public float GetTopBoundary()
        {
            return TilePosition.Y;
        }

        public float GetLeftBoundary()
        {
            return TilePosition.X;
        }

        public float GetRightBoundary()
        {
            return TilePosition.X + TileSize;
        }

    }
}
