using GamePrototype.UI.Singulars;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.UI.UiBars
{
    public class PowerUpBar
    {
        private static List<PowerUp> powerUps = new List<PowerUp>();

        public PowerUpBar(Texture2D spriteSheet, UI ui)
        {

        }

        public void AddPowerUp(PowerUp powerUp)
        {
            powerUps.Add(powerUp);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in powerUps)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
