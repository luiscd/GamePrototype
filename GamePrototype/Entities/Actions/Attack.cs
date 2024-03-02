using GamePrototype.Engine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Entities.Actions
{
    public class Attack
    {
        public bool IsAnimationPlaying { get; set; }
        public Rectangle CollisionBox { get; set; }

        private Texture2D SpriteSheet { get; set; }
        private Vector2 position;
        private Rectangle[] spriteArray;
        private Rectangle[] spriteArrayHorizontal;
        private Rectangle[] spriteArrayVertical;
        private SpriteEffects spriteEffect;

        Animation animation;

        public Attack(Vector2 _position, Vector2 _direction)
        {
            animation = new Animation()
            {
                TimeToUpdate = 0.10f
            };

            SpriteSheet = GlobalVariables.LoadSpriteSheet();

            spriteArrayHorizontal = new Rectangle[3];
            spriteArrayHorizontal[0] = new Rectangle(192, 96, 16, 16);
            spriteArrayHorizontal[1] = new Rectangle(208, 96, 16, 16);
            spriteArrayHorizontal[2] = new Rectangle(224, 96, 16, 16);

            spriteArrayVertical = new Rectangle[3];
            spriteArrayVertical[0] = new Rectangle(192, 112, 16, 16);
            spriteArrayVertical[1] = new Rectangle(208, 112, 16, 16);
            spriteArrayVertical[2] = new Rectangle(224, 112, 16, 16);

            spriteArray = spriteArrayHorizontal;

            position = SetPosition(_position, _direction);
            CollisionBox = new Rectangle((int)position.X, (int)position.Y, 16, 16);
        }

        private Vector2 SetPosition(Vector2 _position, Vector2 _direction)
        {

            if (_direction.X != 0)
            {
                spriteArray = spriteArrayHorizontal;
                spriteEffect = SpriteEffects.None;

                if (_direction.X < 0)
                    spriteEffect = SpriteEffects.FlipHorizontally;

                return new Vector2(_position.X + (16 * _direction.X), _position.Y);
            }

            if (_direction.Y != 0)
            {
                spriteArray = spriteArrayVertical;
                spriteEffect = SpriteEffects.None;

                if (_direction.Y < 0)
                    spriteEffect = SpriteEffects.FlipVertically;

                return new Vector2(_position.X, _position.Y + (16 * _direction.Y));
            }

            return new Vector2();
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime, spriteArray);

            if (animation.isAnimationFinished)
                IsAnimationPlaying = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, position, spriteArray[animation.frameIndex], Color.White, 0f, Vector2.Zero, 1f, spriteEffect, 0.0f);
        }

    }
}
