using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Objects
{
    public abstract class Object
    {
        
        public static List<Object> Loot = new List<Object>();

        public Vector2 Position { get; set; }
        public int Radius { get; set; }
        public Rectangle Bounds { get; set; }
        public Rectangle Sprite { get; set; }   
        public Rectangle CollisionBox { get; set; }
        public bool IsCollided { get; set; }

        public Rectangle[] SpriteArray { get; set; }

        public Texture2D SpriteSheet { get; set; }

        private Animation animation;

        public Object()
        {
            SpriteSheet = GlobalVariables.LoadSpriteSheet();
            CollisionBox = new Rectangle((int)Position.X - 8, (int)Position.Y - 8, 16, 16);
            animation = new Animation();
        }

        public virtual void Update(GameTime gameTime)
        {
            animation.Update(gameTime, SpriteArray);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteSheet, Position, Sprite, Color.White);
        }
    }
}
