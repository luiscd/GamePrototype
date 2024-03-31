using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamePrototype.Objects.Weapons
{
    public class Hammer : Weapon
    {

        private Vector2 knockbackDirection;
        private float knockbackMagnitude;

        public Hammer()
        {
            Sprite = new Rectangle(224, 128, 16, 16);
            Damage = 4;
        }
        public void KnockBack(Vector2 direction, float magnitude)
        {
            // Normalize the direction vector to ensure consistent knockback speed
            direction = Vector2.Normalize(direction);

            // Calculate the knockback velocity
            Vector2 knockbackVelocity = direction * magnitude;

            // Apply the knockback velocity to the character's velocity
            //Velocity += knockbackVelocity;
        }
    }
}
