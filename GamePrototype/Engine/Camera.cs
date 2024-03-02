using GamePrototype.Entities.Player;
using GamePrototype.GameWorld;
using GamePrototype.GameWorld.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Linq;

namespace GamePrototype.Engine
{
    public class Camera
    {
        public static Matrix Transform { get; private set; }
        private Viewport viewport;
        private float rotation;
        private Vector2 position;
        private Engine engine;

        public float Zoom { get; set; } = 3f; // Initial zoom level
        public float UiZoom { get; set; } = 2f;

        private int minimumWorldPositionX;
        private int minimumWorldPositionY;

        private int maximumWorldPositionX;
        private int maximumWorldPositionY;

        public Camera(Viewport _viewport, Vector2 _position)
        {
            viewport = _viewport;
            rotation = 0f;
            position = _position;
        }

        public Matrix GetViewMatrix(Player _player, Engine _engine)
        {
            engine = _engine;
            Vector2 position = _player.WorldPosition;
            SetWorldBoundaries();
            position = CalculateWorldBoundaries(position);
                        
            Level.VisibleTiles = Tile.Tiles.Where(tile => IsTileInScreen(tile, viewport)).ToList();

            return Matrix.CreateTranslation(new Vector3(-position, 0f))
             * Matrix.CreateRotationZ(rotation)
             * Matrix.CreateScale(Zoom)
             * Matrix.CreateTranslation(new Vector3(viewport.Width / 2f, viewport.Height / 2f, 0f));
        }

        public Matrix GetViewMatrixUI(Vector2 position)
        {
            return Matrix.CreateTranslation(new Vector3(-position, 0f))
           * Matrix.CreateRotationZ(rotation)
           * Matrix.CreateScale(UiZoom)
           * Matrix.CreateTranslation(new Vector3(position, 0f));
        }

        private static bool IsTileInScreen(Tile tile, Viewport viewport)
        {
            Vector2 screenPosition = Vector2.Transform(tile.TilePosition, Transform);
            return (screenPosition.X >= -32 && screenPosition.X < viewport.Width &&
                    screenPosition.Y >= -32 && screenPosition.Y < viewport.Height);
        }

        private void SetWorldBoundaries()
        {
            ////X boundaries of the map
            minimumWorldPositionX = engine.GetWorldEdgeX(-1, 21);
            maximumWorldPositionX = engine.GetWorldEdgeX(1, -21);

            ////Y boundaries of the map
            minimumWorldPositionY = engine.GetWorldEdgeY(-1, 15);
            maximumWorldPositionY = engine.GetWorldEdgeY(1, -15);
        }

        private Vector2 CalculateWorldBoundaries(Vector2 _position)
        {
            if (_position.X <= minimumWorldPositionX)
            {
                _position.X = minimumWorldPositionX;
            }
            else if (_position.X >= maximumWorldPositionX)
            {
                _position.X = maximumWorldPositionX;
            }

            if (_position.Y <= minimumWorldPositionY)
            {
                _position.Y = minimumWorldPositionY;
            }
            else if (_position.Y >= maximumWorldPositionY)
            {
                _position.Y = maximumWorldPositionY;
            }

            return _position;
        }

    }
}
