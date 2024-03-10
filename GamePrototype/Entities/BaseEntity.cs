using System.Collections.Generic;
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
        public Rectangle[] SpriteArrayDie { get; set; }

        public Rectangle CollisionBox { get; set; }
        public bool IsDead { get; set; }
        public bool IsHit { get; set; }

        public int Radius { get; set; }
        public int SpriteSize { get; set; }
        private Vector2 lastPosition;

        public Vector2 LastPosition
        {
            get { return lastPosition; }
            set { lastPosition = value; }
        }

        private Vector2 worldPosition;
        public Vector2 WorldPosition
        {
            get { return worldPosition; }
            set { worldPosition = value; }
        }

        public Texture2D SpriteSheet { get; set; }
        public float Speed { get; set; }

        private Vector2 direction;
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public SpriteEffects Effect { get; set; }

        // Properties
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int AttackDamage { get; set; }
        public int Level { get; set; }
        public int Type { get; set; }

        public Rectangle[] SpriteArray { get; set; }

        public BaseEntity()
        {
            SpriteSheet = GlobalVariables.LoadSpriteSheet();
            CollisionBox = new Rectangle((int)WorldPosition.X - 4, (int)WorldPosition.Y - 4, 8, 8);
        }

        public void SetDefaultDirection()
        {
            Direction = Vector2.Zero;
        }

        public void SetDirectionX(int _direction)
        {
            direction.X = _direction;
        }

        public void SetDirectionY(int _direction)
        {
            direction.Y = _direction;
        }

        public void TakeDmg(int attackDmg)
        {
            Health = Health - attackDmg;
        }

        public void CalculateWorldPositionX(double deltaTime)
        {
            worldPosition.X += Speed * (float)deltaTime * Direction.X;
            CollisionBox = new Rectangle((int)WorldPosition.X + 4, (int)WorldPosition.Y + 4, 8, 8);
        }

        public void CalculateWorldPositionY(double deltaTime)
        {
            worldPosition.Y += Speed * (float)deltaTime * Direction.Y;
            CollisionBox = new Rectangle((int)WorldPosition.X + 4, (int)WorldPosition.Y + 4, 8, 8);
        }

        public float GetTopBoundary()
        {
            return WorldPosition.Y;
        }

        public float GetLeftBoundary()
        {
            return WorldPosition.X;
        }

        public float GetRightBoundary()
        {
            return WorldPosition.X + SpriteSize;
        }

        public float GetBottomBoundary()
        {
            return WorldPosition.Y + SpriteSize;
        }

        public void MoveRight(double deltaTime)
        {
            SpriteArray = SpriteArrayRight;
            Effect = SpriteEffects.None;
            SetDirectionX(1);
            SetDirectionY(0);
            CalculateWorldPositionX(deltaTime);
        }

        public void MoveLeft(double deltaTime)
        {
            SpriteArray = SpriteArrayRight;
            Effect = SpriteEffects.FlipHorizontally;
            SetDirectionX(-1);
            SetDirectionY(0);
            CalculateWorldPositionX(deltaTime);
        }

        public void MoveUp(double deltaTime)
        {
            SpriteArray = SpriteArrayUp;
            SetDirectionX(0);
            SetDirectionY(-1);
            CalculateWorldPositionY(deltaTime);
        }

        public void MoveDown(double deltaTime)
        {
            SpriteArray = SpriteArrayDown;
            SetDirectionX(0);
            SetDirectionY(1);
            CalculateWorldPositionY(deltaTime);
        }

        public void SetLastPosition()
        {
            worldPosition = lastPosition;
            CollisionBox = new Rectangle((int)WorldPosition.X + 4, (int)WorldPosition.Y + 4, 8, 8);
        }

        public bool IsDeadMethod()
        {
            return Health < 1;
        }
    }
}
