using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Engine
{
    public class Animation
    {

        public int frameIndex = 0;
        private float timeElapsed;
        private float timeToUpdate = 0.15f;

        public Animation()
        {
        }

        public void Update(GameTime gameTime, Rectangle[] spriteArray)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if (frameIndex < spriteArray.Length - 1)
                {
                    frameIndex++;
                }
                else
                {
                    frameIndex = 0;
                }
            }
        }
    }
}
