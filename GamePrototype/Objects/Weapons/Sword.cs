using Microsoft.Xna.Framework;

namespace GamePrototype.Objects.Weapons
{
    public class Sword : Weapon
    {
        public Sword()
        {
            Sprite = new Rectangle(192, 128, 16, 16);
            Damage = 1;
        }

    }
}
