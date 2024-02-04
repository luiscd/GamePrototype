﻿using GamePrototype.Engine;
using GamePrototype.Entities.Mob;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GamePrototype
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int WIDTH = 1024;
        public static int HEIGHT = 768;

        Texture2D spriteSheet;

        Screen screen;
        UI.UI ui;
        Camera camera;
        
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
            screen = new Screen(spriteSheet);
            ui = new UI.UI(spriteSheet);
            camera = new Camera(GraphicsDevice.Viewport, new Vector2(screen.player.WorldPosition.X, screen.player.WorldPosition.Y));
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

            screen.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transformMatrix: camera.GetViewMatrix(screen.player, screen.engine));
            screen.Draw(_spriteBatch);
            _spriteBatch.End();

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transformMatrix: camera.GetViewMatrixUI(ui.Position));
            ui.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}