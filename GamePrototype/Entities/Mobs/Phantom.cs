using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Entities.Mob
{
    public class Phantom : Mob
    {
        public Phantom()
        {
            Effect = SpriteEffects.None;
            SpriteSize = 16;

            //
            //Movement right animation
            //
            SpriteArrayIdle = new Rectangle[4];
            SpriteArrayIdle[0] = new Rectangle(288, 0, SpriteSize, SpriteSize);
            SpriteArrayIdle[1] = new Rectangle(304, 0, SpriteSize, SpriteSize);
            SpriteArrayIdle[2] = new Rectangle(320, 0, SpriteSize, SpriteSize);
            SpriteArrayIdle[3] = new Rectangle(336, 0, SpriteSize, SpriteSize);

            //
            //Rigth idle animation
            //
            SpriteArrayMovement = new Rectangle[6];
            SpriteArrayMovement[0] = new Rectangle(288, 16, SpriteSize, SpriteSize);
            SpriteArrayMovement[1] = new Rectangle(304, 16, SpriteSize, SpriteSize);
            SpriteArrayMovement[2] = new Rectangle(320, 16, SpriteSize, SpriteSize);
            SpriteArrayMovement[3] = new Rectangle(336, 16, SpriteSize, SpriteSize);
            SpriteArrayMovement[4] = new Rectangle(352, 16, SpriteSize, SpriteSize);
            SpriteArrayMovement[5] = new Rectangle(368, 16, SpriteSize, SpriteSize);

            SpriteArray = SpriteArrayIdle;

            //
            //Hit animation
            //
            SpriteArrayHit = new Rectangle[4];
            SpriteArrayHit[0] = new Rectangle(288, 32, SpriteSize, SpriteSize);
            SpriteArrayHit[1] = new Rectangle(304, 32, SpriteSize, SpriteSize);
            SpriteArrayHit[2] = new Rectangle(320, 32, SpriteSize, SpriteSize);
            SpriteArrayHit[3] = new Rectangle(336, 32, SpriteSize, SpriteSize);


            //
            //Die animation
            //
            SpriteArrayDie = new Rectangle[8];
            SpriteArrayDie[0] = new Rectangle(288, 48, 16, 16);
            SpriteArrayDie[1] = new Rectangle(304, 48, 16, 16);
            SpriteArrayDie[2] = new Rectangle(320, 48, 16, 16);
            SpriteArrayDie[3] = new Rectangle(336, 48, 16, 16);
            SpriteArrayDie[4] = new Rectangle(352, 48, 16, 16);
            SpriteArrayDie[5] = new Rectangle(368, 48, 16, 16);
            SpriteArrayDie[6] = new Rectangle(384, 48, 16, 16);
            SpriteArrayDie[7] = new Rectangle(400, 48, 16, 16);
        }

    }
}
