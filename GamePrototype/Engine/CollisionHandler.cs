using GamePrototype.Entities;
using GamePrototype.Entities.Actions;
using GamePrototype.Entities.Mob;
using GamePrototype.Entities.Player;
using GamePrototype.GameWorld.Tiles;
using GamePrototype.UI.Singulars;
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

        public void HandleCollisionsEntities(BaseEntity entity)
        {
            foreach (var mobEntity in BaseEntity.Entities)
            {
                if (entity.CollisionBox.Intersects(mobEntity.CollisionBox))
                {
                    entity.TakeDmg(mobEntity.AttackDamage);
                }
            }
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


        public void HandleAttackCollision(Attack attack)
        {
            foreach (var mobEntity in Mob.Mobs)
            {
                if (attack.CollisionBox.Intersects(mobEntity.CollisionBox))
                {
                    mobEntity.HandleHit();
                }
            }
        }
    }
}
