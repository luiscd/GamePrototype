using GamePrototype.Entities;
using GamePrototype.Entities.Actions;
using GamePrototype.Entities.Mob;
using GamePrototype.GameWorld.Tiles;
using GamePrototype.Objects.Weapons;
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
            return Tile.Tiles.Any(tile => !tile.IsWalkable && !tile.CollisionBox.IsEmpty && entity.CollisionBox.Intersects(tile.CollisionBox));
        }

        public bool HandleCollisionsEntities(BaseEntity entity)
        {
            return BaseEntity.Entities.Any(bEntity => bEntity.CollisionBox.Intersects(entity.CollisionBox));
        }

        public bool HandleCollisionPowerUps(BaseEntity entity)
        {
            return PowerUp.PowerUps.Where(powerUp => entity.CollisionBox.Intersects(powerUp.CollisionBox))
                                .Select(powerUp =>
                                {
                                    powerUp.IsCollided = true;
                                    return powerUp;
                                }).Any();
        }

        public void HandleAttackCollision(Attack attack)
        {
            Mob.Mobs.Where(mob => attack.CollisionBox.Intersects(mob.CollisionBox))
                    .Select(mob =>
                    {
                        mob.IsHit = true;
                        return mob;
                    });
        }

        public bool HandleWeaponsCollision(BaseEntity entity)
        {
            return Weapon.Weapons.Where(weapon => entity.CollisionBox.Intersects(weapon.CollisionBox))
                               .Select(weapon =>
                               {
                                   weapon.IsCollided = true;
                                   return weapon;
                               }).Any();
        }
    }
}
