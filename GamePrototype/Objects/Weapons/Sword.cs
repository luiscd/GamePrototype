using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Objects.Weapons
{
    public class Sword : Object
    {
        public Sword()
        {
            Sprite = new Rectangle(192, 128, 16, 16);
            Damage = 1;
        }

    }
}
