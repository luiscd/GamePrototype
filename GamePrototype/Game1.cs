using GamePrototype.Engine;
using GamePrototype.Entities.Player;
using GamePrototype.GameWorld;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace GamePrototype
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public int WIDTH = 1024;
        public int HEIGHT = 768;

        Texture2D spriteSheet;

        Level level = new Level();

        Player player;
        Camera camera;

        int spriteRadius = 4;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = WIDTH;
            _graphics.PreferredBackBufferHeight = HEIGHT;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            spriteSheet = Content.Load<Texture2D>("spriteSheet");

            level.LoadLevel(spriteSheet);

            player = new Player()
            {
                SpriteSheet = spriteSheet,
                Speed = 0.10f,
                Direction = new Vector2(1, 1),
                SpriteRectangle = new Rectangle(0, 8, spriteRadius * 2, spriteRadius * 2),
                WorldPosition = new Vector2(-spriteRadius, -spriteRadius)
            };

            camera = new Camera(GraphicsDevice.Viewport, player.WorldPosition);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);
            camera.Follow(player);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transformMatrix: camera.Transform);

            level.Draw(_spriteBatch);
            player.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}