using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Engine
{
    public class Camera
    {
        private readonly Viewport viewport;

        public Vector2 Position { get; set; }
        public float Zoom { get; set; }

        public Camera(Viewport viewport)
        {
            this.viewport = viewport;
            Zoom = 4.5f;
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                                          Matrix.CreateScale(new Vector3(Zoom, Zoom, 1.0f)) *
                                          Matrix.CreateTranslation(new Vector3(viewport.Width * 0.0f, viewport.Height * 0.0f, 0f));
        }

    }
}
