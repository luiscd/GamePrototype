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

        public bool HandleCollisionsWorld(BaseEntity entity)
        {
            var collisionTiles = Tile.Tiles.Where(tile => !tile.IsWalkable && !tile.CollisionBox.IsEmpty);
            
            foreach (var tile in collisionTiles)
            {
                if (entity.CollisionBox.Intersects(tile.CollisionBox))
                {
                    return true;
                }
            }

            return false;
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

        public bool HandleCollisionPowerUps(BaseEntity entity)
        {
            foreach (var powerUp in UI.Singulars.PowerUp.PowerUps)
            {
                if (entity.CollisionBox.Intersects(powerUp.CollisionBox))
                {
                    powerUp.IsCollided = true;
                    return true;
                }
            }

            return false;
        }

    }
}
