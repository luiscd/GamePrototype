using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.UI.UiBars
{
    public class StatusBar
    {
        private Texture2D spriteSheet;

        public Vector2 Position { get; set; }
        public Rectangle Sprite {  get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        public StatusBar()
        {
            spriteSheet = GlobalVariables.LoadSpriteSheet();
        }

        #region Public Methods

        /// <summary>
        /// Update Method
        /// </summary>
        /// <param name="gameTime"></param>
        public void Udpate(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draw Method
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, Position, Sprite, Color.White);
        }

        #endregion

        #region Private Methods

        #endregion  
    }
}
