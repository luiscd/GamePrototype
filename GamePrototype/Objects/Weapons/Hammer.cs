using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GamePrototype.Objects.Weapons
{
    public class Hammer : Object
    {
        private Texture2D spriteSheet;

        public Hammer()
        {
            spriteSheet = GlobalVariables.LoadSpriteSheet();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, Position, Sprite, Color.White);
        }
        
    }
}
