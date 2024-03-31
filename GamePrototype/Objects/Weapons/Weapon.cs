using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Objects.Weapons
{
    public abstract class Weapon : Object
    {
        public static List<Weapon> Weapons = new List<Weapon>();

        public int Damage { get; set; }
        
    }
}
