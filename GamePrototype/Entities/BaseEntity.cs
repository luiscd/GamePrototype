using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamePrototype.Entities
{
    public class BaseEntity
    {
        public static List<BaseEntity> Entities = new List<BaseEntity>();
        public Rectangle SpriteRectangle { get; set; }
        public int Radius { get; set; }
        public int SpriteSize { get; set; }

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Texture2D SpriteSheet { get; set; }
        public float Speed { get; set; }
        public int Hp { get; set; }
        public bool IsMob { get; set; }

        private Vector2 direction;
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public BaseEntity() { }


        /// <summary>
        /// Base Entity Update Method
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            //EntityRectangle = new Rectangle((int)Position.X, (int)Position.Y, SpriteSize, SpriteSize);
            //CalculateWorldPositionX(gameTime);
            var dt = gameTime.ElapsedGameTime.TotalSeconds; 
            Position = new Vector2((float)((int)0.15f * dt * direction.X), (float)((int)0.15f * dt * direction.Y));
            Debug.WriteLine("Position vector: " + Position);
        }

        /// <summary>
        /// Base Entity Draw Method
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, Position, SpriteRectangle, Color.White);
        }


        public void SetDirectionX(int _direction)
        {
            direction.X = _direction;
        }

        public void SetDirectionY(int _direction)
        {
            direction.Y = _direction;
        }

        public void CalculateWorldPositionX(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            position.X += Speed * deltaTime * Direction.X;
        }

        public void CalculateWorldPositionY(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            position.Y += Speed * deltaTime * Direction.Y;
        }

    }
}
