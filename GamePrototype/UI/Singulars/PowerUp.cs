using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.UI.Singulars
{
    public class PowerUp
    {

        public static List<PowerUp> PowerUps = new List<PowerUp>();

        public Texture2D SpriteSheet { get; set; }
        public bool IsSelected { get; set; }
        public Vector2 Position { get; set; }
        public int TileSize { get; set; }
        public bool IsCollided { get; set; }

        public Rectangle[] SpriteArray { get; set; }

        public Rectangle CollisionBox { get; set; }

        private Animation animation;

        public PowerUp()
        {
            animation = new Animation()
            {
                TimeToUpdate = 0.20f
            };

            SpriteSheet = GlobalVariables.LoadSpriteSheet();

            SpriteArray = new Rectangle[6];
            SpriteArray[0] = new Rectangle(16, 208, 16, 16);
            SpriteArray[1] = new Rectangle(32, 208, 16, 16);
            SpriteArray[2] = new Rectangle(48, 208, 16, 16);
            SpriteArray[3] = new Rectangle(64, 208, 16, 16);
            SpriteArray[4] = new Rectangle(80, 208, 16, 16);
            SpriteArray[5] = new Rectangle(96, 208, 16, 16);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime, SpriteArray);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, Position, SpriteArray[animation.FrameIndex], Color.White);
        }

    }
}
