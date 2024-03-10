using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Entities.Actions
{
    public class Die
    {
        public bool IsAnimationPlaying { get; set; }

        public Rectangle[] SpriteArray { get; set; }

        private Texture2D spriteSheet;
        public Vector2 Position;
        private SpriteEffects spriteEffect;

        Animation animation;

        public Die(Vector2 direction)
        {
            spriteSheet = GlobalVariables.LoadSpriteSheet();
                        
            animation = new Animation()
            {
                TimeToUpdate = 0.10f
            };

            spriteEffect = SpriteEffects.None;

            if (direction.X < 0) spriteEffect = SpriteEffects.FlipHorizontally;
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime, SpriteArray);

            if (animation.IsAnimationFinished)
                IsAnimationPlaying = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, Position, SpriteArray[animation.FrameIndex], Color.White, 0f, Vector2.Zero, 1f, spriteEffect, 0.0f);
        }
    }
}
