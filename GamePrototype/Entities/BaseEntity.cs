using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamePrototype.Entities
{

    public class BaseEntity
    {
        public static List<BaseEntity> Entities = new List<BaseEntity>();

        public Rectangle[] SpriteArrayRight { get; set; }
        public Rectangle[] SpriteArrayIdleRight { get; set; }

        public Rectangle[] SpriteArrayLeft { get; set; }
        public Rectangle[] SpriteArrayIdleLeft { get; set; }

        public Rectangle[] SpriteArrayUp { get; set; }
        public Rectangle[] SpriteArrayIdleUp { get; set; }

        public Rectangle[] SpriteArrayDown { get; set; }
        public Rectangle[] SpriteArrayIdleDown { get; set; }


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

        public enum UpdateState
        {
            Idle,
            Movement
        }

        private UpdateState UpdState;
        
        // Properties
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int AttackDamage { get; set; }
        public int Level { get; set; }
        public int Type { get; set; }

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

        public void SetWorldPositionX(float _worldPositionX)
        {
            worldPosition.X = _worldPositionX / 4;
        }

        public void SetWorldPostionY(int _worldPositionY)
        {
            worldPosition.Y = _worldPositionY;
        }

    }
}
