using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamePrototype.Objects.Misc
{
    public class Chest : Object
    {
        Animation animation;

        public Chest()
        {
            SpriteArray = new Rectangle[8];
            SpriteArray[0] = new Rectangle(16, 224, 16, 16);
            SpriteArray[1] = new Rectangle(32, 224, 16, 16);
            SpriteArray[2] = new Rectangle(48, 224, 16, 16);
            SpriteArray[3] = new Rectangle(64, 224, 16, 16);
            SpriteArray[4] = new Rectangle(80, 224, 16, 16);
            SpriteArray[5] = new Rectangle(96, 224, 16, 16);
            SpriteArray[6] = new Rectangle(112, 224, 16, 16);
            SpriteArray[7] = new Rectangle(128, 224, 16, 16);

            animation = new Animation();
            animation.TimeToUpdate = 0.17f;
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime, SpriteArray);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, Position, SpriteArray[animation.FrameIndex], Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            base.Draw(spriteBatch);
        }
    }
}
