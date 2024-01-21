using GamePrototype.Entities.Player;
using GamePrototype.GameWorld.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Engine
{
    public class CollisionHandler
    {
        public CollisionHandler()
        {
        }
         
        public void HandleCollisions(Player player, List<Tile> tiles)
        {
            foreach (var tile in tiles)
            {
                if (player.Intersects(tile))
                {
                    player.SetDirectionY(0);
                }
            }
        }

    }
}
