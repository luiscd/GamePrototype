using Microsoft.Xna.Framework.Graphics;

namespace GamePrototype.Engine
{
    public class GlobalVariables
    {

        public Texture2D SpriteSheet { get; set; }

        public static Texture2D LoadSpriteSheet()
        {
            return Game1._Content.Load<Texture2D>("spriteSheet");
        }

    }
}
