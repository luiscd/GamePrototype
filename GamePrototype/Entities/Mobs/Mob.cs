using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Entities.Mob
{
    public class Mob : BaseEntity
    {

        int actionLocker;
        public static List<Mob> Mobs = new List<Mob>();

        public Mob() { }


        public override void Update(GameTime gameTime)
        {
            actionLocker++;

            if (actionLocker == 120)
            {
                Random random = new Random();
                int randomValue = random.Next(100);

                if (randomValue <= 25)
                {
                    SetDirectionX(1);
                    SetDirectionY(0);
                }

                if (randomValue > 25 && randomValue <= 50)
                {
                    SetDirectionX(-1);
                    SetDirectionX(0);
                }

                if (randomValue > 50 && randomValue <= 75)
                {
                    SetDirectionX(0);
                    SetDirectionX(1);
                }

                if (randomValue > 75 && randomValue <= 100)
                {
                    SetDirectionX(0);
                    SetDirectionX(-1);
                }

                actionLocker = 0;
            }

            base.Update(gameTime);
        }
    }
}
