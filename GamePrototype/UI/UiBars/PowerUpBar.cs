using GamePrototype.UI.Singulars;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GamePrototype.UI.UiBars
{
    public class PowerUpBar
    {
        private static List<PowerUp> powerUps = new List<PowerUp>();

        public PowerUpBar(UI ui)
        {

        }

        public void AddPowerUp(PowerUp powerUp)
        {
            powerUps.Add(powerUp);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var powerUp in powerUps)
            {
                powerUp.Draw(spriteBatch);
            }
        }
    }
}
