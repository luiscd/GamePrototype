using GamePrototype.Engine;
using GamePrototype.Entities.Actions;
using GamePrototype.Objects.Weapons;
using GamePrototype.UI.Singulars;
using GamePrototype.UI.UiBars;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Net.Security;
using System.Security;

namespace GamePrototype.Entities.Player
{
    public class Player : BaseEntity
    {
        private CollisionHandler collisionHandler;
        InputManager inputManager;
        Animation animation;
        Attack attack;

        public int Stamina { get; set; } = 10;
        public bool IsAttacking { get; set; }

        private Rectangle[] SpriteArrayIdle = new Rectangle[6];
        private Rectangle[] SpriteArrayAttackVertical = new Rectangle[6];
        private Rectangle[] SpriteArrayAttackHorizontal = new Rectangle[6];

        /// <summary>
        /// Constructor
        /// </summary>
        public Player() : base()
        {
            inputManager = new InputManager();
            collisionHandler = new CollisionHandler();
            animation = new Animation()
            {
                TimeToUpdate = 0.20f,
            };

            Effect = SpriteEffects.None;
            SpriteSize = 16;
            SpriteSheet = GlobalVariables.GameTexturesDictionary["playerIdleDown"];
            SpriteArray = new Rectangle[6];

            for (int i = 0; i <= 5; i++)
            {
                SpriteArrayIdle[i] = new Rectangle(i * 16, 0, SpriteSize, SpriteSize);
            }

            for (int i = 0; i <= 5; i++)
            {
                SpriteArrayAttackVertical[i] = new Rectangle(i * 48, 0, 48, 32);
            }

            for (int i = 0; i <= 5; i++)
            {
                SpriteArrayAttackHorizontal[i] = new Rectangle(i * 32, 0, 32, 48);
            }

            SpriteArray = SpriteArrayIdle;
            DirectionString = "Down";
        }

        #region Public Methods
        public void Update(GameTime gameTime)
        {
            var deltaTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            inputManager.UpdateState();
            StaticWorldPosition = WorldPosition;
            LastPosition = WorldPosition;
            animation.Update(gameTime, SpriteArray);

            if (inputManager.IsKeyDown(Keys.Right))
            {
                IsMoving = true;
                DirectionString = "Right";
                SpriteSheet = GlobalVariables.GameTexturesDictionary["playerMoveRight"];
                MoveRight(deltaTime);
                inputManager.SaveLastKeyPressed(Keys.Right);
            }
            else if (inputManager.IsLastKeyPressedEqual(Keys.Right))
            {
                IsMoving = false;
            }

            if (inputManager.IsKeyDown(Keys.Left))
            {
                IsMoving = true;
                DirectionString = "Left";
                SpriteSheet = GlobalVariables.GameTexturesDictionary["playerMoveLeft"];
                MoveLeft(deltaTime);
                inputManager.SaveLastKeyPressed(Keys.Left);
            }
            else if (inputManager.IsLastKeyPressedEqual(Keys.Left))
            {
                IsMoving = false;
            }

            if (inputManager.IsKeyDown(Keys.Up))
            {
                IsMoving = true;
                DirectionString = "Up";
                SpriteSheet = GlobalVariables.GameTexturesDictionary["playerMoveUp"];
                MoveUp(deltaTime);
                inputManager.SaveLastKeyPressed(Keys.Up);
            }
            else if (inputManager.IsLastKeyPressedEqual(Keys.Up))
            {
                IsMoving = false;
            }

            if (inputManager.IsKeyDown(Keys.Down))
            {
                IsMoving = true;
                DirectionString = "Down";
                SpriteSheet = GlobalVariables.GameTexturesDictionary["playerMoveDown"];
                MoveDown(deltaTime);
                inputManager.SaveLastKeyPressed(Keys.Down);
            }
            else if (inputManager.IsLastKeyPressedEqual(Keys.Down))
            {
                IsMoving = false;
            }

            if (!IsMoving)
            {
                IdleAnimation();
            }

            //Attack(gameTime);

            if (inputManager.IsKeyDown(Keys.Space) && !inputManager.IsLastKeyPressedEqual(Keys.Space))
            {
                IsAttacking = true;
                inputManager.SaveLastKeyPressed(Keys.Space);   
                switch (DirectionString)
                {
                    case "Up":
                        WorldPosition = new Vector2(WorldPosition.X - 16, WorldPosition.Y);
                        SpriteArray = SpriteArrayAttackVertical;
                        SpriteSheet = GlobalVariables.GameTexturesDictionary["playerAttackUp"];
                        break;

                    case "Down":
                        WorldPosition = new Vector2(WorldPosition.X - 16, WorldPosition.Y);
                        SpriteArray = SpriteArrayAttackVertical;
                        SpriteSheet = GlobalVariables.GameTexturesDictionary["playerAttackDown"];
                        break;

                    case "Right":
                        WorldPosition = new Vector2(WorldPosition.X - 16, WorldPosition.Y - 16);
                        SpriteArray = SpriteArrayAttackHorizontal;
                        SpriteSheet = GlobalVariables.GameTexturesDictionary["playerAttackRight"];
                        break;

                    case "Left":
                        WorldPosition = new Vector2(WorldPosition.X - 16, WorldPosition.Y - 16);
                        SpriteArray = SpriteArrayAttackHorizontal;
                        SpriteSheet = GlobalVariables.GameTexturesDictionary["playerAttackLeft"];
                        break;

                    default:
                        break;
                }

                if (animation.IsAnimationFinished && inputManager.IsLastKeyPressedEqual(Keys.Space))
                {
                    IsAttacking = false;
                    SpriteArray = SpriteArrayIdle;
                    IdleAnimation();
                }
            }

            CollisionDetection();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, WorldPosition, SpriteArray[animation.FrameIndex], Color.White);
            attack?.Draw(spriteBatch);
        }

        public static Vector2 GetPlayerPosition()
        {
            return StaticWorldPosition;
        }

        #endregion

        #region Private Methods

        private void IdleAnimation()
        {
            switch (DirectionString)
            {
                case "Up":
                    SpriteSheet = GlobalVariables.GameTexturesDictionary["playerIdleUp"];
                    break;

                case "Down":
                    SpriteSheet = GlobalVariables.GameTexturesDictionary["playerIdleDown"];
                    break;

                case "Left":
                    SpriteSheet = GlobalVariables.GameTexturesDictionary["playerIdleLeft"];
                    break;

                case "Right":
                    SpriteSheet = GlobalVariables.GameTexturesDictionary["playerIdleRight"];
                    break;

                default:
                    break;
            }
        }

        private void Attack(GameTime gameTime)
        {
            if (inputManager.IsKeyDown(Keys.Space))
            {
                IsAttacking = true;
                inputManager.SaveLastKeyPressed(Keys.Space);
                switch (DirectionString)
                {
                    case "Up":
                        SpriteArray = SpriteArrayAttackVertical;
                        WorldPosition = new Vector2(WorldPosition.X - 16, WorldPosition.Y);
                        SpriteSheet = GlobalVariables.GameTexturesDictionary["playerAttackUp"];
                        break;

                    case "Down":
                        SpriteArray = SpriteArrayAttackVertical;
                        WorldPosition = new Vector2(WorldPosition.X - 16, WorldPosition.Y);
                        SpriteSheet = GlobalVariables.GameTexturesDictionary["playerAttackDown"];
                        break;

                    case "Left":
                        SpriteArray = SpriteArrayAttackHorizontal;
                        SpriteSheet = GlobalVariables.GameTexturesDictionary["playerAttackLeft"];
                        break;

                    case "Right":
                        SpriteArray = SpriteArrayAttackHorizontal;
                        SpriteSheet = GlobalVariables.GameTexturesDictionary["playerAttackRight"];
                        break;

                    default:
                        break;
                }

                //var actionBarElement = ActionBar.Items.FirstOrDefault(element => element.IsSelected);
                //if (!actionBarElement.IsFree && !IsAttacking)
                //{
                //    IsAttacking = true;
                //    inputManager.SaveLastKeyPressed(Keys.Space);
                //    attack = new Attack(WorldPosition, Direction)
                //    {
                //        IsAnimationPlaying = true
                //    };
                //}
            }
            else if (inputManager.IsLastKeyPressedEqual(Keys.Space))
            {
                IsAttacking = false;
                SpriteArray = SpriteArrayIdle;
            }
        }

        private void CollectPowerUp()
        {
            PowerUp.PowerUps.RemoveAll(element => element.IsCollided);
            //TODO: atribuir o tipo de powerup e as suas propriedades
        }

        private void CollisionDetection()
        {
            if (collisionHandler.HandleCollisionsEntities(this))
            {
                //TakeDmg(AttackDamage);
                //var knockBack = CalculateKnockBack(WorldPosition, 10);
                //ApplyKnockBack(knockBack);

                //switch (DirectionString)
                //{
                //    case "Up":
                //        SpriteArray = SpriteArrayHitUp;
                //        break;

                //    case "Down":
                //        SpriteArray = SpriteArrayHitDown;
                //        break;

                //    case "Left":
                //        SpriteArray = SpriteArrayHitLeft;
                //        break;

                //    case "Right":
                //        SpriteArray = SpriteArrayHitRight;
                //        break;

                //    default:
                //        break;
                //}
            }

            if (collisionHandler.HandleCollisionPowerUps(this))
                CollectPowerUp();

            if (collisionHandler.HandleCollisionsWorld(this))
                SetLastPosition();

            if (attack != null)
                collisionHandler.HandleAttackCollision(attack);

            if (collisionHandler.HandleWeaponsCollision(this))
                CollectWeapon();
        }

        private void CollectWeapon()
        {
            UI.UI.LoadWeaponUI(Weapon.Weapons.FirstOrDefault(x => x.IsCollided));
            Weapon.Weapons.RemoveAll(weapon => weapon.IsCollided);
        }

        #endregion
    }

}
