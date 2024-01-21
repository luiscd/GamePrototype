using GamePrototype.Engine;
using GamePrototype.Entities.Player;
using GamePrototype.GameWorld;
using GamePrototype.GameWorld.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Linq;

namespace GamePrototype
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public int WIDTH = 1024;
        public int HEIGHT = 768;

        Texture2D spriteSheet;

        Level level;

        Player player;
        Camera camera;
        Engine.Engine engine;
        ConfigurationFileReader configReader;
        CollisionHandler collisionHandler;

        int spriteRadius = 8;

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
            configReader = new ConfigurationFileReader();
            collisionHandler = new CollisionHandler();
            level = new Level(spriteSheet);
            level.LoadLevel();
            engine = new Engine.Engine(level);

            var playerEntity = configReader.LoadEntities().FirstOrDefault(entity => entity.Type == 0);

            player = new Player()
            {
                SpriteSheet = spriteSheet,
                Speed = 0.10f,
                Direction = new Vector2(0, 0),
                WorldPosition = new Vector2(-spriteRadius, -spriteRadius),
                Name = playerEntity.Name,
                AttackDamage = playerEntity.AttackDamage,
                Health = playerEntity.Health,
                Mana = playerEntity.Mana,
                Level = 1
            };

            camera = new Camera(GraphicsDevice.Viewport, new Vector2(player.WorldPosition.X, player.WorldPosition.Y));
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

            player.Update(gameTime, engine);
            collisionHandler.HandleCollisions(player, Tile.Tiles);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transformMatrix: camera.GetViewMatrix(player, engine));

            level.Draw(_spriteBatch);
            player.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}