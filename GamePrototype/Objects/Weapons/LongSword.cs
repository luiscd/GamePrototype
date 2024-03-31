using Microsoft.Xna.Framework;

namespace GamePrototype.Objects.Weapons
{
    public class LongSword : Weapon
    {

        public LongSword()
        {
            Sprite = new Rectangle(208, 128, 16, 16);
            Damage = 3;
        }

    }
}
