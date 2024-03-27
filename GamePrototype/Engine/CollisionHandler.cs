using GamePrototype.Entities;
using GamePrototype.Entities.Actions;
using GamePrototype.Entities.Mob;
using GamePrototype.GameWorld.Tiles;
using GamePrototype.UI.Singulars;
using System.Linq;

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
            foreach (var powerUp in PowerUp.PowerUps)
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
                    mobEntity.IsHit = true;
                }
            }
        }

        public bool HandleWeaponsCollision(BaseEntity entity)
        {
            foreach (var weapon in Objects.Object.Weapons)
            {
                if (entity.CollisionBox.Intersects(weapon.CollisionBox))
                {
                    weapon.IsCollided = true;
                    return true;
                }
            }

            return false;
        }
    }
}
