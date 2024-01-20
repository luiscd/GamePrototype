using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.GameWorld.Tiles
{
    public class WallTile : Tile
    {
        public WallTile(int xOffset, int yOffset, Texture2D spriteSheet, int tileSize, Vector2 position, int id)
        {
            TileOffsetX = xOffset;
            TileOffsetY = yOffset;
            SpriteSheet = spriteSheet;
            TilePosition = position;
            TileSize = tileSize;
            SpriteRectangle = GetWallTile(id);
            IsWalkable = false;
        }


        private Rectangle GetWallTile(int id)
        {
            Rectangle sprite = new Rectangle();

            switch (id)
            {
                case 1:
                    sprite = new Rectangle(0, 0, TileSize, TileSize);
                    break;

                case 2:
                    sprite = new Rectangle(16, 0, TileSize, TileSize);
                    break;

                case 3:
                    sprite = new Rectangle(80, 0, TileSize, TileSize);
                    break;

                case 4:
                    sprite = new Rectangle(0, 32, TileSize, TileSize);
                    break;

                case 5:
                    sprite = new Rectangle(16, 32, TileSize, TileSize);
                    break;

                case 6:
                    sprite = new Rectangle(80, 32, TileSize, TileSize);
                    break;

                case 7:
                    sprite = new Rectangle(0, 144, TileSize, TileSize);
                    break;

                case 8:
                    sprite = new Rectangle(80, 144, TileSize, TileSize);
                    break;

                case 9:
                    sprite = new Rectangle(0, 160, TileSize, TileSize);
                    break;

                case 10:
                    sprite = new Rectangle(16, 160, TileSize, TileSize);
                    break;

                case 11:
                    sprite = new Rectangle(80, 160, TileSize, TileSize);
                    break;

            }

            return sprite;
        }

    }
}
