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
        private Level level;

        public float Zoom { get; set; } = 3.5f; // Initial zoom level

        public Camera(Viewport _viewport, Vector2 _position)
        {
            viewport = _viewport;
            Zoom = 2.5f;
            rotation = 0f;
            position = _position;
        }

        public Matrix GetViewMatrix(Vector2 _position, Level _level)
        {
            level = _level;

            //X boundaries of the map
            int minimumWorldPositionX = (-level.WorldWidth * 4) / 18 * 8;
            int maximumWorldPositionX = (level.WorldWidth * 4) / 18 * 8;

            //Y boundaries of the map
            int minimumWorldPositionY = (-level.WorldHeight * 4) / 14 * 8;
            int maximumWorldPositionY = (level.WorldHeight * 4) / 14 * 8;
            
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

            Level.VisibleTiles = BaseTile.Tiles.Where(tile => IsTileInScreen(tile, viewport)).ToList();

            return Matrix.CreateTranslation(new Vector3(-_position, 0f))
             * Matrix.CreateRotationZ(rotation)
             * Matrix.CreateScale(Zoom)
             * Matrix.CreateTranslation(new Vector3(viewport.Width / 2f, viewport.Height / 2f, 0f));
        }

        private static bool IsTileInScreen(BaseTile tile, Viewport viewport)
        {
            Vector2 screenPosition = Vector2.Transform(tile.TilePosition, Transform);
            return (screenPosition.X >= -32 && screenPosition.X < viewport.Width &&
                    screenPosition.Y >= -32 && screenPosition.Y < viewport.Height);
        }

    }
}
