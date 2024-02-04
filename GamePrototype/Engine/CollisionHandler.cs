using GamePrototype.Entities;
using GamePrototype.Entities.Player;
using GamePrototype.GameWorld.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Engine
{
    public class CollisionHandler
    {
        public CollisionHandler()
        {
        }

        public void HandleCollisionsWorld(BaseEntity entity)
        {
            var collisionTiles = Tile.Tiles.Where(tile => !tile.IsWalkable && !tile.CollisionBox.IsEmpty);
            
            foreach (var tile in collisionTiles)
            {
                if (entity.CollisionBox.Intersects(tile.CollisionBox))
                {
                    entity.SetLastPosition();
                }
            }
        }

        public bool HandleCollisionsEntities(BaseEntity entity)
        {
            foreach (var mobEntity in BaseEntity.Entities) 
            {
                if (entity.CollisionBox.Intersects(mobEntity.CollisionBox))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
