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
        public Rectangle EntityRectangle { get; set; }
        public int Radius { get; set; }
        public int SpriteSize { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D SpriteSheet { get; set; }


        public BaseEntity() { }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
        
    }
}
