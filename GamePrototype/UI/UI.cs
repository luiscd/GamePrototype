using GamePrototype.Engine;
using GamePrototype.Objects.Weapons;
using GamePrototype.UI.Singulars;
using GamePrototype.UI.UiBars;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.UI
{
    public class UI
    {
        private ActionBar actionBar;
        private PowerUpBar powerUpBar;
        private StatusBar statusBar;

        private int TileSize = 16;

        private Vector2 actionBarPosition { get; set; }
        private Vector2 powerUpPostion { get; set; }

        public Rectangle ActionBarRectangle { get; set; }
        public Rectangle PowerUpRectangle { get; set; }

        static Sword sword;
        static LongSword longSword;
        static Hammer hammer;

        public UI()
        {
            actionBarPosition = new Vector2(0, (int)(Game1.HEIGHT - TileSize * 4));
            ActionBarRectangle = new Rectangle((int)actionBarPosition.X, (int)actionBarPosition.Y, Game1.WIDTH / 2 - 3, TileSize + (TileSize / 2));

            powerUpPostion = new Vector2(Game1.WIDTH - TileSize * 6, Game1.HEIGHT / 2);
            PowerUpRectangle = new Rectangle((int)powerUpPostion.X, (int)powerUpPostion.Y, TileSize * 2, TileSize * 2);
                        
            actionBar = new ActionBar(this);
            powerUpBar = new PowerUpBar(this);
        }

        public void Update(GameTime gameTime)
        {
            actionBar.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            //Draw ActionBar rectangle
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transformMatrix: camera.GetViewMatrixUI(actionBarPosition));
            actionBar.Draw(spriteBatch);
            sword?.Draw(spriteBatch);
            longSword?.Draw(spriteBatch);
            hammer?.Draw(spriteBatch);
            spriteBatch.End();

            //Draw PowerUps rectangle
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transformMatrix: camera.GetViewMatrixUI(powerUpPostion));
            DrawRectangle(spriteBatch, PowerUpRectangle, Color.White, 2);
            powerUpBar.Draw(spriteBatch);
            spriteBatch.End();
        }   

        public static void LoadWeaponUI(Weapon weapon)
        {
            var actionBarSlot = ActionBar.Items.FirstOrDefault(item => item.IsFree);
            
            if (actionBarSlot != null)
            {
                SendToActionBar(actionBarSlot, weapon);
            } 
            else
            {
                StoreToInventory(weapon);
            }          
        }

        private static void SendToActionBar(ItemBox actionBarSlot, Weapon actionBarObject)
        {
            actionBarSlot.IsFree = false;
            actionBarSlot.Dmg = actionBarObject.Damage;

            switch (actionBarObject)
            {
                case Sword:
                    sword = new Sword()
                    {
                        Position = actionBarSlot.Position
                    };
                    break;

                case LongSword:
                    longSword = new LongSword()
                    {
                        Position = actionBarSlot.Position
                    };
                    break;

                case Hammer:
                    hammer = new Hammer()
                    {
                        Position = actionBarSlot.Position
                    };
                    break;

                default:
                    break;
            }
        }

        private static void StoreToInventory(Objects.Object storeObject)
        {

        }

        private void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color, int lineWidth)
        {
            Texture2D _pointTexture;
            _pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            _pointTexture.SetData<Color>(new Color[] { Color.White });

            spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), color);
            spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), color);
        }

    }
}
