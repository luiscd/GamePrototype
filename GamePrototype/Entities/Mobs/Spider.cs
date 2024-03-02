using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamePrototype.Entities.Mob
{
    public class Spider : Mob
    {

        public Spider()
        {
            Effect = SpriteEffects.None;
            SpriteSize = 16;

            //
            // Idle animation
            //
            SpriteArrayIdle = new Rectangle[4];
            SpriteArrayIdle[0] = new Rectangle(288, 64, SpriteSize, SpriteSize);
            SpriteArrayIdle[1] = new Rectangle(304, 64, SpriteSize, SpriteSize);
            SpriteArrayIdle[2] = new Rectangle(320, 64, SpriteSize, SpriteSize);
            SpriteArrayIdle[3] = new Rectangle(336, 64, SpriteSize, SpriteSize);

            //
            // Movement animation
            //
            SpriteArrayMovement = new Rectangle[4];
            SpriteArrayMovement[0] = new Rectangle(288, 80, SpriteSize, SpriteSize);
            SpriteArrayMovement[1] = new Rectangle(288, 80, SpriteSize, SpriteSize);
            SpriteArrayMovement[2] = new Rectangle(288, 80, SpriteSize, SpriteSize);
            SpriteArrayMovement[3] = new Rectangle(288, 80, SpriteSize, SpriteSize);

            SpriteArray = SpriteArrayIdle;

            //
            //Hit animation
            //
            SpriteArrayHit = new Rectangle[4];
            SpriteArrayHit[0] = new Rectangle(352, 64, SpriteSize, SpriteSize);
            SpriteArrayHit[1] = new Rectangle(368, 64, SpriteSize, SpriteSize);
            SpriteArrayHit[2] = new Rectangle(384, 64, SpriteSize, SpriteSize);
            SpriteArrayHit[3] = new Rectangle(400, 64, SpriteSize, SpriteSize);

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
