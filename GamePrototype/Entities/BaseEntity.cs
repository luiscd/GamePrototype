using System.Collections.Generic;
using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Bson;

namespace GamePrototype.Entities
{

    public abstract class BaseEntity
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
        public Rectangle[] SpriteArrayHitUp { get; set; }
        public Rectangle[] SpriteArrayHitDown { get; set; }
        public Rectangle[] SpriteArrayHitLeft { get; set; }
        public Rectangle[] SpriteArrayHitRight { get; set; }

        public Rectangle CollisionBox { get; set; }
        public bool IsDead { get; set; }
        public bool IsHit { get; set; }
        public bool IsMoving { get; set; }

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

        public static Vector2 StaticWorldPosition;

        public Texture2D SpriteSheet { get; set; }
        public float Speed { get; set; }

        private Vector2 direction;
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        private string directionString;
        public string DirectionString { get; set; }

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
            //SpriteSheet = GlobalVariables.LoadSpriteSheet();
            CollisionBox = new Rectangle((int)WorldPosition.X - 4, (int)WorldPosition.Y - 4, 8, 8);
        }

        public void SetDefaultDirection()
        {
            Direction = Vector2.Zero;
        }

        public void SetDirectionX(int _direction)
        {
            direction.X = _direction;
            Effect = direction.X == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        }

        public void SetDirectionY(int _direction)
        {
            direction.Y = _direction;
        }

        public void TakeDmg(int attackDmg)
        {
            Health = Health - attackDmg;
        }

        public void ApplyKnockBack(Vector2 knockBack)
        {
            WorldPosition = new Vector2(knockBack.X * (1 - 1), knockBack.Y * (1 - 1));
        }

        public Vector2 CalculateKnockBack( Vector2 targetPosition, float knockbackForce)
        {
            //Vector2 attackerPosition,
            // Step 1: Calculate the direction vector
            Vector2 direction = targetPosition;// - attackerPosition;

            // Step 2: Normalize the direction vector
            direction.Normalize();

            // Step 3: Apply the knockback force
            Vector2 knockback = direction * knockbackForce;

            return knockback;
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
            SetDirectionX(1);
            SetDirectionY(0);
            CalculateWorldPositionX(deltaTime);
        }

        public void MoveLeft(double deltaTime)
        {
            SetDirectionX(-1);
            SetDirectionY(0);
            CalculateWorldPositionX(deltaTime);
        }

        public void MoveUp(double deltaTime)
        {
            SetDirectionX(0);
            SetDirectionY(-1);
            CalculateWorldPositionY(deltaTime);
        }

        public void MoveDown(double deltaTime)
        {
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
        
        public void TakeDamage(int attackDmg)
        {
            Health -= attackDmg;
        }
    }
}
