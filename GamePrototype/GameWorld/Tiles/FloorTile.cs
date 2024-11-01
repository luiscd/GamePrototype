﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.GameWorld.Tiles
{
    public class FloorTile : Tile
    {

        public FloorTile(int xOffset, int yOffset, int tileSize, Vector2 position)
        {
            TileOffsetX = xOffset;
            TileOffsetY = yOffset;
            TilePosition = position;
            SpriteRectangle = new Rectangle(112, 176, tileSize, tileSize);
            IsWalkable = true;
        }
    }
}
