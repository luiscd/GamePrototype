using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Entities.Mob
{
    public class Zombie : BaseEntity
    {

        public Zombie() {
            Speed = 0.15f;
            Direction = new Vector2(1, 1);
            //Position = new Vector2((1024 / 2) - 12, (768 / 2) - 12),
            Position = new Vector2(100, 100);
            SpriteRectangle = new Rectangle(0, 8, 16, 16);
            EntityRectangle = new Rectangle(100, 100, 16, 16);
        }


    }
}
