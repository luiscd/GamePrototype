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
        public int FrameIndex { get; set; } = 0;
        public bool IsAnimationFinished { get; set; } = false;

        public float TimeToUpdate { get; set; } /*= 0.20f;*/

        private float timeElapsed;
        private bool isPaused = false;

        public Animation()
        {
        }

        public void Update(GameTime gameTime, Rectangle[] spriteArray)
        {
            if (!isPaused)
            {
                timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (timeElapsed > TimeToUpdate)
                {
                    timeElapsed -= TimeToUpdate;

                    if (FrameIndex < spriteArray.Length - 1)
                    {
                        FrameIndex++;
                    }
                    else
                    {
                        FrameIndex = 0;
                        IsAnimationFinished = true;
                    }
                }
            }
        }


        public void Stop()
        {
            isPaused = true;
        }

        public void Resume()
        {         
            isPaused = false;
        }

        public bool IsPaused { get { return isPaused; } }
        
    }
}
