using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Objects.Loot.Consumables
{
    public class HealthPotion : Object
    {
        public HealthPotion() : base()
        {
            SpriteArray = new Rectangle[1];
            SpriteArray[0] = new Rectangle(96, 240, 8, 8);
        }
    }
}
