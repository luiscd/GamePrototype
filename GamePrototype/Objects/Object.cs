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
    public class Object
    {
        public static List<Object> Weapons = new List<Object>();

        public Vector2 Position { get; set; }
        public int Radius { get; set; }
        public Rectangle Bounds { get; set; }
        public Rectangle Sprite { get; set; }   
        public Rectangle CollisionBox { get; set; }
        public int Damage { get;set; }
        public bool IsCollided { get; set; }

        private Texture2D spriteSheet; 

        public Object()
        {
            spriteSheet = GlobalVariables.LoadSpriteSheet();    
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, Position, Sprite, Color.White);
        }
    }
}
