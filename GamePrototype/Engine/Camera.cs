using GamePrototype.Entities.Player;
using GamePrototype.GameWorld;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Engine
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        private Viewport viewport;

        public float Zoom { get; set; } = 3.5f; // Initial zoom level

        public Camera(Viewport viewport, Vector2 position)
        {
            this.viewport = viewport;

            // Initialize the camera at the center of the screen with the specified zoom level
            Transform = Matrix.CreateTranslation(new Vector3(-position, 0))
                        * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1.0f))
                        * Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0f));
        }

        public void Follow(Player player)
        {
            Transform = Matrix.CreateTranslation(new Vector3(-player.WorldPosition, 0))
                        * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1.0f))
                        * Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0f));
        }
    }
}
