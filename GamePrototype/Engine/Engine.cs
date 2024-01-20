using GamePrototype.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Engine
{
    public class Engine
    {
        Level level;

        public Engine(Level level)
        {
            this.level = level;
        }

        public int GetWorldEdgeX(int direction, int ratio)
        {
            return (level.WorldWidth * level.TileRadius * direction) + level.TileRadius * ratio;
        }

        public int GetWorldEdgeY(int direction, int ratio)
        {
            return (level.WorldHeight * level.TileRadius * direction) + level.TileRadius * ratio;
        }



    }
}
