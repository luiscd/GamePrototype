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

        public float Zoom { get; set; } = 3.5f; // Initial zoom level
        public float UiZoom { get; set; } = 2f;

        public Camera(Viewport _viewport, Vector2 _position)
        {
            viewport = _viewport;
            Zoom = 3f;
            rotation = 0f;
            position = _position;
        }

        public Matrix GetViewMatrix(Player player, Engine engine)
        {
            this.engine = engine;
            Vector2 position = player.WorldPosition;

            ////X boundaries of the map
            int minimumWorldPositionX = engine.GetWorldEdgeX(-1, 21); 
            int maximumWorldPositionX = engine.GetWorldEdgeX(1, -21);

            ////Y boundaries of the map
            int minimumWorldPositionY = engine.GetWorldEdgeY(-1, 15); 
            int maximumWorldPositionY = engine.GetWorldEdgeY(1, -15);

            if (position.X <= minimumWorldPositionX)
            {
                position.X = minimumWorldPositionX;
            }
            else if (position.X >= maximumWorldPositionX)
            {
                position.X = maximumWorldPositionX;
            }

            if (position.Y <= minimumWorldPositionY)
            {
                position.Y = minimumWorldPositionY;
            }
            else if (position.Y >= maximumWorldPositionY)
            {
                position.Y = maximumWorldPositionY;
            }

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

    }
}
