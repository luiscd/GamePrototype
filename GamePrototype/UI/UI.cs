using GamePrototype.Engine;
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

        private int TileSize = 16;

        private Vector2 ActionBarPosition { get; set; }
        private Vector2 PowerUpPostion { get; set; }

        public Rectangle ActionBarRectangle { get; set; }
        public Rectangle PowerUpRectangle { get; set; }


        // FPS variables
        private int frameCounter = 0;
        private float elapsedTime = 0;
        private int currentFPS = 0;
        private SpriteFont font;

        public UI(ContentManager Content)
        {
            ActionBarPosition = new Vector2(0, (int)(Game1.HEIGHT - TileSize * 4));
            ActionBarRectangle = new Rectangle((int)ActionBarPosition.X, (int)ActionBarPosition.Y, Game1.WIDTH / 2 - 3, TileSize + (TileSize / 2));

            PowerUpPostion = new Vector2(Game1.WIDTH - TileSize * 6, Game1.HEIGHT / 2);
            PowerUpRectangle = new Rectangle((int)PowerUpPostion.X, (int)PowerUpPostion.Y, TileSize * 2, TileSize * 2);

            actionBar = new ActionBar(this);
            powerUpBar = new PowerUpBar(this);
            font = Content.Load<SpriteFont>("Font");
        }

        public void Update(GameTime gameTime)
        {
            // Calculate elapsed time
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // If one second has elapsed, update FPS
            if (elapsedTime >= 1.0f)
            {
                currentFPS = frameCounter;
                frameCounter = 0;
                elapsedTime = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            //Draw ActionBar rectangle
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transformMatrix: camera.GetViewMatrixUI(ActionBarPosition));
            actionBar.Draw(spriteBatch);
            spriteBatch.End();

            //Draw PowerUps rectangle
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transformMatrix: camera.GetViewMatrixUI(PowerUpPostion));
            DrawRectangle(spriteBatch, PowerUpRectangle, Color.White, 2);
            //spriteBatch.DrawString(font, $"FPS: {currentFPS}", new Vector2(PowerUpRectangle.X + 10, PowerUpRectangle.Y + 10), Color.White);
            powerUpBar.Draw(spriteBatch);
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
