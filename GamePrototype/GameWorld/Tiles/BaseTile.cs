using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.GameWorld.Tiles {
    public class BaseTile {

        public static List<BaseTile> Tiles = new List<BaseTile>();
        public Rectangle SpriteRectangle { get; set; }
        //public Rectangle TileRectangle { get; set; }

        private int tileSize;
        public int TileSize {
            get { return tileSize; }
            set { tileSize = value; }
        }

        private Vector2 tilePosition;
        public Vector2 TilePosition {
            get { return tilePosition; }
            set { tilePosition = value; }
        }

        public Texture2D SpriteSheet { get; set; }
        public bool IsDraw { get; set; }

        public int TileOffsetX { get; set; }
        public int TileOffsetY { get; set; }

        public BaseTile() {
        }

        public virtual void Update(GameTime gameTime) {
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(SpriteSheet, TilePosition, SpriteRectangle, Color.White);
        }

        //public void CalculatePosition(Vector2 direction, float worldSpeed, float deltaTime, int levelSize) {
        //    tilePosition = new Vector2(tilePosition.X + (worldSpeed * deltaTime * direction.X), tilePosition.Y + (worldSpeed * deltaTime * direction.Y));
        //    tilePosition.X = MathHelper.Clamp(tilePosition.X, 0, levelSize - tileSize); // Assuming tileSize is the width of each tile
        //    tilePosition.Y = MathHelper.Clamp(tilePosition.Y, 0, levelSize - tileSize); // Assuming tileSize is the height of each tile
        //}

    }
}
