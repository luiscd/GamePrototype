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
        public bool isAnimationFinished = false;
        private float timeElapsed;
        public float TimeToUpdate { get; set; } /*= 0.20f;*/

        public Animation()
        {
        }

        public void Update(GameTime gameTime, Rectangle[] spriteArray)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeElapsed > TimeToUpdate)
            {
                timeElapsed -= TimeToUpdate;

                if (frameIndex < spriteArray.Length - 1)
                {
                    frameIndex++;
                }
                else
                {
                    frameIndex = 0;
                    isAnimationFinished = true;
                }
            }
        }
    }
}
