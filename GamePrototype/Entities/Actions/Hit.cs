using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamePrototype.Entities.Actions
{
    public class Hit
    {
        Animation animation;

        public Rectangle[] SpriteArray { get; set; }
        public bool IsAnimationPlaying { get; set; } = true;
        public Vector2 Position { get; set; }
        public SpriteEffects SpriteEffect { get; set; }

        private Texture2D spriteSheet;

        public Hit()
        {
            animation = new Animation();
            spriteSheet = GlobalVariables.LoadSpriteSheet();
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime, SpriteArray);

            if (animation.IsAnimationFinished)
                IsAnimationPlaying = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, Position, SpriteArray[animation.FrameIndex], Color.White, 0f, Vector2.Zero, 1f, SpriteEffect, 0.0f);
        }
    }
}
