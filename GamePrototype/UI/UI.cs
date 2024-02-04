using GamePrototype.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.UI
{
    public class UI
    {
        private ActionBar actionBar;
        private int TileSize = 16;
        public Vector2 ActionBarPosition { get; set; }
        private  Vector2 PowerUpPostion { get; set; }

        public UI(Texture2D spriteSheet)
        {
            ActionBarPosition = new Vector2(0, Game1.HEIGHT - 3 * TileSize);
            PowerUpPostion = new Vector2(Game1.WIDTH - TileSize * 5, Game1.HEIGHT / 2);
            //Position = new Vector2(100, 100);
            actionBar = new ActionBar(spriteSheet);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            //Draw ActionBar rectangle
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transformMatrix: camera.GetViewMatrixUI(ActionBarPosition));
            DrawRectangle(spriteBatch, new Rectangle((int)ActionBarPosition.X, (int)ActionBarPosition.Y, Game1.WIDTH / 2 - 3, TileSize), Color.White, 2);
            spriteBatch.End();

            //Draw PowerUps rectangle
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transformMatrix: camera.GetViewMatrixUI(PowerUpPostion));
            DrawRectangle(spriteBatch, new Rectangle((int)PowerUpPostion.X, (int)PowerUpPostion.Y, TileSize * 2, TileSize * 2), Color.White, 2);
            spriteBatch.End();

            //actionBar.Draw(spriteBatch);    
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
