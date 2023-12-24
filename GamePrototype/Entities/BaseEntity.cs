using System;
using System.Collections.Generic;
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

        private Vector2 worldPosition;
        public Vector2 WorldPosition
        {
            get { return worldPosition; }
            set { worldPosition = value; }
        }

        public Texture2D SpriteSheet { get; set; }
        public float Speed { get; set; }
        public int Hp { get; set; }

        private Vector2 direction;
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public BaseEntity() { }

        public void SetDirectionX(int _direction)
        {
            direction.X = _direction;
            //direction = physics.SetDirectionX(direction, _direction);
            //Effect = this.direction.X == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        }

        public void SetDirectionY(int _direction)
        {
            direction.Y = _direction;
        }

        public void CalculateWorldPositionX(double deltaTime)
        {
            worldPosition.X += Speed * (float)deltaTime * Direction.X;
        }

        public void CalculateWorldPositionY(double deltaTime)
        {
            worldPosition.Y += Speed * (float)deltaTime * Direction.Y;
        }

    }
}
